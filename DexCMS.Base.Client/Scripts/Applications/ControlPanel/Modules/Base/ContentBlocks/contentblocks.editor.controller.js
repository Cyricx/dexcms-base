define([
    'controlpanel-app',
    '../pagecontents/pagecontents.service'
], function (app) {
    app.controller('contentBlocksEditorCtrl', [
        '$scope',
        'ContentBlocks',
        '$stateParams',
        '$location',
        '$state',
        'PageContents',
        '$window',
        function ($scope, ContentBlocks, $stateParams, $location, $state, PageContents, $window) {

            var id = $stateParams.id || null;

            $scope.title = (id == null ? "Add " : "Edit ") + "Content Block";

            $scope.currentItem = {};

            if (id != null) {
                ContentBlocks.getItem(id).then(function (response) {
                    $scope.currentItem = response.data;
                });
            } else {
                $scope.currentItem.pageContentID = $stateParams.parentId;
                $scope.currentItem.displayOrder = 2;
            }

            $scope.save = function (item) {
                if (item.contentBlockID) {
                    ContentBlocks.updateItem(item.contentBlockID, item).then(function (response) {
                        redirect(item);
                    });
                } else {
                    ContentBlocks.createItem(item).then(function (response) {
                        redirect(item);
                    });
                }
            }

            var redirect = function (item) {
                if ($location.search().frompage === "true") {
                    PageContents.getItem(item.pageContentID).then(function (response) {
                        $window.location.href = '/' +
                            (response.data.pageArea ? response.data.pageArea + "/" : "") +
                            response.data.pageController + "/" + response.data.pageAction;
                    });
                } else if ($location.search().fromadmin == "events") {
                    $state.go('events/:id', { id: item.pageContentID});
                } else {
                    $state.go('pagecontents/:id', {id:item.pageContentID});
                }

            }

        }
    ]);
});