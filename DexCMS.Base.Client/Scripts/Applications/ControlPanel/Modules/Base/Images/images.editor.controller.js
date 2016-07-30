define([
    'controlpanel-app'
], function (app) {
    app.controller('imagesEditorCtrl', [
        '$scope',
        'Images',
        '$stateParams',
        '$state',
        'Upload',
        function ($scope, Images, $stateParams, $state, Upload) {

            var id = $stateParams.id || null;

            $scope.title = (id == null ? "Add " : "Edit ") + "Image";

            $scope.currentItem = {};

            if (id != null) {
                Images.getItem(id).then(function (response) {
                    $scope.currentItem = response.data;
                });
            }

            $scope.save = function (item) {
                if (item.imageID) {
                    Images.updateItem(item.imageID, item).then(function (response) {
                        $state.go('images');
                    });
                } else {
                    Images.createItem(item).then(function (response) {
                        $state.go('images');
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