define([
    'controlpanel-app',
    'underscore',
    '../settingdatatypes/settingdatatypes.service',
    '../settinggroups/settinggroups.service'
], function (app, _) {
    app.controller('settingsEditorCtrl', [
        '$scope',
        'Settings',
        '$stateParams',
        '$state',
        'SettingDataTypes',
        'SettingGroups',
        'dexCMSControlPanelSettings',
        'Upload',
        function ($scope, Settings, $stateParams, $state, SettingDataTypes, SettingGroups, dexcmsSettings, Upload) {

            var id = $stateParams.id || null;
            $scope.isInstaller = cpUser.isInstaller;
            $scope.baseUrl = dexcmsSettings.baseUrl;

            $scope.title = (id == null ? "Add " : "Edit ") + "Setting";

            $scope.currentItem = {};

            if (id != null) {
                Settings.getItem(id).then(function (response) {
                    $scope.currentItem = response.data;
                    if ($scope.currentItem.settingDataTypeID == 2) {
                        $scope.currentItem.value = new Date($scope.currentItem.value);
                    }
                });
            } else if (!$scope.isInstaller) {
                $state.go('settings');
            }

            $scope.save = function (item) {
                if (item.settingID) {
                    Settings.updateItem(item.settingID, item).then(function (response) {
                        $state.go('settings');
                    });
                } else {
                    Settings.createItem(item).then(function (response) {
                        $state.go('settings');
                    });
                }
            };

            SettingDataTypes.getList().then(function (response) {
                $scope.settingDataTypes = response;
            });

            SettingGroups.getList().then(function (response) {
                $scope.settingGroups = response;
            });
            
            $scope.flipValue = function (currentItem) {
                if (currentItem.value === 'true') {
                    currentItem.value = 'false';
                } else {
                    currentItem.value = 'true';
                }
            }

            $scope.setDataTypeName = function (item) {
                if (item.settingDataTypeID) {
                    item.value = null;
                    var settingDataType = _.find($scope.settingDataTypes, { settingDataTypeID: item.settingDataTypeID });
                    if (settingDataType) {
                        item.settingDataTypeName = settingDataType.name;
                    }
                }
            };

            //! File
            $scope.$watch('file', function () {
                $scope.uploadFile($scope.file);
            });
            $scope.removeNewFile = function () {
                $scope.currentItem.replacementFileName = undefined;
                $scope.file = {};
            };
            $scope.uploadFile = function (file) {
                $scope.upload(file, 'File');
            }

            //! Image
            $scope.$watch('image', function () {
                $scope.uploadImage($scope.image);
            });
            $scope.removeNewImage = function () {
                $scope.currentItem.replacementImageName = undefined;
                $scope.image = {};
            };

            $scope.uploadImage = function (file) {
                $scope.upload(file, 'Image');
            }

            $scope.upload = function (file, fileType) {
                if (file) {
                    $scope.tooLarge = false;
                    if (file.size < 4000000) {
                        Upload.upload({
                            url: '../api/fileupload/upload',
                            fields: { 'username': $scope.username },
                            file: file
                        }).progress(function (evt) {
                            var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
                            $scope.progressPercentage = progressPercentage + '%';
                        }).success(function (data, status, headers, config) {
                            if (fileType === 'File') {
                                $scope.currentItem.replacementFileName = data.originalName;
                                $scope.currentItem.temporaryFileName = data.temporaryName;
                                $scope.currentItem.value = "Pending";
                            } else {
                                $scope.currentItem.replacementImageName = data.originalName;
                                $scope.currentItem.temporaryImageName = data.temporaryName;
                                $scope.currentItem.value = "Pending";
                            }
                        });
                    } else {
                        $scope.tooLarge = true;
                    }
                }
            };


        }
    ]);
});