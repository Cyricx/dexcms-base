define([
    'controlpanel-app'
], function (app) {
    app.controller('pageContentsListCtrl', [
        '$scope',
        'PageContents',
        '$window',
        'dexCMSControlPanelSettings',
        function ($scope, PageContents, $window, dexcmsSettings) {
            $scope.title = "View Page Contents";

            $scope.table = {
                columns: [
                    { property: 'pageContentID', title: 'ID' },
                    { property: 'heading', title: 'Title' },
                    { property: 'pageTitle', title: 'Page Title' },
                    { property: 'contentAreaName', title: 'Area' },
                    { property: 'contentCategoryName', title: 'Category' },
                    { property: 'contentSubCategoryName', title: 'SubCategory' },
                    { property: 'urlSegment', title: 'Url' },
                    {
                        property: '', title: '', disableSorting: true,
                        dataTemplate: dexcmsSettings.startingRoute + 'modules/base/pagecontents/_pagecontents.list.buttons.html'
                    },
                ],
                defaultSort: 'pageContentID',
                functions: {
                    remove: function (id) {
                        if (confirm('Are you sure?')) {
                            PageContents.deleteItem(id).then(function (response) {
                                $window.location.reload();
                            });
                        }
                    }
                },
                filePrefix: 'Page-Contents'
            };

            PageContents.getList().then(function (data) {
                $scope.table.promiseData = data;
            });
        }
    ]);
});