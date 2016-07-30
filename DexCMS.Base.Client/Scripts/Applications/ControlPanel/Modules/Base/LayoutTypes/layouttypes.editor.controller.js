define([
    'controlpanel-app'
], function (app) {
    app.controller('layoutTypesEditorCtrl', [
        '$scope',
        'LayoutTypes',
        '$stateParams',
        '$state',
        'Upload',
        function ($scope, LayoutTypes, $stateParams, $state, Upload) {

            var id = $stateParams.id || null;

            $scope.title = (id == null ? "Add " : "Edit ") + "Layout Type";

            $scope.currentItem = { isActive: true };

            if (id != null) {
                LayoutTypes.getItem(id).then(function (response) {
                    $scope.currentItem = response.data;
                });
            }

            $scope.save = function (item) {
                if (item.layoutTypeID) {
                    LayoutTypes.updateItem(item.layoutTypeID, item).then(function (response) {
                        $state.go('layouttypes');
                    });
                } else {
                    LayoutTypes.createItem(item).then(function (response) {
                        $state.go('layouttypes');
                    });
                }
            };

            $scope.$watch('files', function () {
                $scope.upload($scope.files);
            });

            $scope.upload = function (files) {
                if (files && files.length) {
                    for (var i = 0; i < files.length; i++) {
                        $scope.tooLarge = false;
                        var file = files[i];
                        if (file.size < 4000000) {
                            Upload.upload({
                                url: '../api/fileupload/upload',
                                fields: { 'username': $scope.username },
                                file: file
                            }).progress(function (evt) {
                                var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
                                $scope.progressPercentage = progressPercentage + '%';
                            }).success(function (data, status, headers, config) {
                                $scope.currentItem.replacementFileName = data.originalName;
                                $scope.currentItem.temporaryFileName = data.temporaryName;
                            });
                        } else {
                            $scope.tooLarge = true;
                        }
                    }
                }
            };

            $scope.removeNewFile = function () {
                $scope.currentItem.replacementFileName = undefined;
                $scope.files = [];
            };
        }
    ]);
});