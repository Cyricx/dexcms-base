define([
    'controlpanel-app',
    '../pagecontents/pagecontents.service',
    '../images/images.service',
], function (app) {
    app.controller('pageContentImagesListCtrl', [
        '$scope',
        'PageContentImages',
        '$stateParams',
        'PageContents',
        '$state',
        '$location',
        'Images',
        function ($scope, PageContentImages, $stateParams, PageContents, $state, $location, Images) {
            var id = $stateParams.id || null;
            $scope.title = "Loading..";
            $scope.pendingSave = false;
            $scope.maximumImages = null;
            PageContents.getItem(id).then(function (response) {
                $scope.title = "Manage Backgrounds for " + response.data.title;
                $scope.maximumImages = response.data.maximumImages;
            });

            PageContentImages.getSelected(id).then(function (response) {
                $scope.selected = response;
                Images.getListForPageContents(id).then(function (imageResponse) {
                    $scope.pageContentImages = imageResponse;
                    $scope.droppedLength = $scope.pageContentImages.length;
                });
            });

            $scope.saveButtonText = function () {
                if ($scope.selected && $scope.exceededLimit($scope.selected.length)) {
                    return 'Error';
                } else {
                    return 'Save Order';
                }
            }
            
            $scope.dropCallback = function (event, index, item) {
                $scope.pendingSave = true;
                $scope.droppedLength = $scope.pageContentImages.length;
                return item;
            };


            $scope.exceededLimit = function (currentCount) {
                if ($scope.maximumImages == null) {
                    return false;
                } else {
                    return currentCount > $scope.maximumImages;
                }
            }
            $scope.saveOrder = function () {
                var data = {
                    pageContentID: id,
                    pageContentImages: []
                };
                for (var i = 0; i < $scope.selected.length; i++) {
                    data.pageContentImages.push({
                        imageID: $scope.selected[i].imageID,
                        displayOrder: i
                    });
                }
                PageContentImages.updateItems(data).then(function (response) {
                    if ($location.search().fromadmin == "events") {
                        $state.go('events/:id', { id: id, settings: 'true' });
                    } else {
                        $state.go('pagecontents/:id', { id: id });
                    }
                });

            };

        }
    ]);
});