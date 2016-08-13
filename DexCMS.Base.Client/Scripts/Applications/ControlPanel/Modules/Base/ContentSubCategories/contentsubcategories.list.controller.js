define([
    'controlpanel-app'
], function (app) {
    app.controller('contentSubCategoriesListCtrl', [
        '$scope',
        'ContentSubCategories',
        '$window',
        'dexCMSControlPanelSettings',
        function ($scope, ContentSubCategories, $window, dexcmsSettings) {
            $scope.title = "View Content SubCategories";

            $scope.table = {
                columns: [
                    { property: 'contentSubCategoryID', title: 'ID' },
                    { property: 'name', title: 'Name' },
                    { property: 'urlSegment', title: 'Url' },
                    { property: 'isActive', title: 'Active?' },
                    {
                        property: '', title: '', disableSorting: true,
                        dataTemplate: dexcmsSettings.startingRoute + 'modules/base/contentsubcategories/_contentsubcategories.list.buttons.html'
                    },
                ],
                defaultSort: 'contentSubCategoryID',
                functions: {
                    remove: function (id) {
                        if (confirm('Are you sure?')) {
                            ContentSubCategories.deleteItem(id).then(function (response) {
                                $window.location.reload();
                            });
                        }
                    }
                },
                filePrefix: 'Content-Subcategories'
            };

            ContentSubCategories.getList().then(function (data) {
                $scope.table.promiseData = data;
            });
        }
    ]);
});