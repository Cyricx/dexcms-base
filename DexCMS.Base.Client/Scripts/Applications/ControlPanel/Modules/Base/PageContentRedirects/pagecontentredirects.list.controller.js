define([
    'controlpanel-app'
], function (app) {
    app.controller('pageContentRedirectsListCtrl', [
        '$scope',
        'PageContentRedirects',
        '$window',
        'dexCMSControlPanelSettings',
        function ($scope, PageContentRedirects, $window, dexcmsSettings) {
            $scope.title = "View Redirects";

            $scope.table = {
                columns: [
                    { property: 'pageContentRedirectID', title: 'ID' },
                    { property: 'url', title: 'Url' },
                    { property: 'pageContent.heading', title: 'Content' },
                    {
                        property: '', title: '', disableSorting: true,
                        dataTemplate: dexcmsSettings.startingRoute + 'modules/base/pagecontentredircts/_pagecontentredirects.list.buttons.html'
                    },
                ],
                defaultSort: 'pageContentRedirectID',
                functions: {
                    remove: function (id) {
                        if (confirm('Are you sure?')) {
                            PageContentRedirects.deleteItem(id).then(function (response) {
                                $window.location.reload();
                            });
                        }
                    }
                },
                filePrefix: 'Page-Content-Redirects'
            };

            PageContentRedirects.getList().then(function (data) {
                $scope.table.promiseData = data;
            });
        }
    ]);
});