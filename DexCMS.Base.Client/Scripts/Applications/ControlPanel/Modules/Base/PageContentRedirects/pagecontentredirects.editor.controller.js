define([
    'controlpanel-app',
    '../pagecontents/pagecontents.service'
], function (app) {
    app.controller('pageContentRedirectsEditorCtrl', [
        '$scope',
        'PageContentRedirects',
        '$stateParams',
        '$state',
        'PageContents',
        function ($scope, PageContentRedirects, $stateParams, $state, PageContents) {

            var id = $stateParams.id || null;

            $scope.title = (id == null ? "Add " : "Edit ") + "Redirect";

            $scope.currentItem = { };

            if (id != null) {
                PageContentRedirects.getItem(id).then(function (response) {
                    $scope.currentItem = response.data;
                });
            }
            
            PageContents.getList().then(function (response) {
                $scope.pageContents = response;
            });

            $scope.save = function (item) {
                if (item.pageContentRedirectID) {
                    PageContentRedirects.updateItem(item.pageContentRedirectID, item).then(function (response) {
                        $state.go('pagecontentredirects');
                    });
                } else {
                    PageContentRedirects.createItem(item).then(function (response) {
                        $state.go('pagecontentredirects');
                    });
                }
            };
        }
    ]);
});