define([
    'controlpanel-app'
], function (app) {
    app.controller('contentCategoriesListCtrl', [
        '$scope',
        'ContentCategories',
        '$window',
        'dexCMSControlPanelSettings',
        function ($scope, ContentCategories, $window, dexcmsSettings) {
            $scope.title = "View Content Categories";

            $scope.table = {
                columns: [
                    { property: 'contentCategoryID', title: 'ID' },
                    { property: 'name', title: 'Name' },
                    { property: 'urlSegment', title: 'Url' },
                    { property: 'isActive', title: 'Active?' },
                    {
                        property: '', title: '', disableSorting: true,
                        dataTemplate: dexcmsSettings.startingRoute + 'modules/base/contentcategories/_contentcategories.list.buttons.html'
                    },
                ],
                defaultSort: 'contentCategoryID',
                functions: {
                    remove: function (id) {
                        if (confirm('Are you sure?')) {
                            ContentCategories.deleteItem(id).then(function (response) {
                                $window.location.reload();
                            });
                        }
                    }
                },
                filePrefix: 'Content-Categories'
            };

            ContentCategories.getList().then(function (data) {
                $scope.table.promiseData = data;
            });

            function actionsHtml(data, type, full, meta) {
                var buttons = '<a class="btn btn-warning" ui-sref="contentcategories/:id({id:' + data.contentCategoryID + '})">' +
                   '   <i class="fa fa-edit"></i>' +
                   '</a>';
                if (data.contentCount == 0) {
                    buttons += ' <button class="btn btn-danger" ng-click="delete(' + data.contentCategoryID + ')">' +
                   '   <i class="fa fa-trash-o"></i>' +
                   '</button>';
                } else {
                    buttons += ' <button class="btn btn-danger" ng-disabled="\'true\'">Currently in use</button';
                }
                return buttons;
            }

            $scope.delete = function (id) {
                if (confirm('Are you sure?')) {
                    ContentCategories.deleteItem(id).then(function (response) {
                        $window.location.reload();
                    });
                }
            };
        }
    ]);
});