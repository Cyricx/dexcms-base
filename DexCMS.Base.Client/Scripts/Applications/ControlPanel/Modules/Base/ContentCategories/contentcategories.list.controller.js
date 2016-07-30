define([
    'controlpanel-app'
], function (app) {
    app.controller('contentCategoriesListCtrl', [
        '$scope',
        'ContentCategories',
        'DTOptionsBuilder',
        'DTColumnBuilder',
        '$compile',
        '$window',
        function ($scope, ContentCategories, DTOptionsBuilder, DTColumnBuilder, $compile, $window) {
            $scope.title = "View Content Categories";

            $scope.dtOptions = DTOptionsBuilder.fromFnPromise(function () {
                return ContentCategories.getList();
            }).withBootstrap().withOption('createdRow', createdRow);

            $scope.dtColumns = [
                DTColumnBuilder.newColumn('contentCategoryID').withTitle('ID'),
                DTColumnBuilder.newColumn('name').withTitle('Name'),
                DTColumnBuilder.newColumn('urlSegment').withTitle('Url'),
                DTColumnBuilder.newColumn('isActive').withTitle('Active?'),
                DTColumnBuilder.newColumn(null).withTitle('').notSortable().renderWith(actionsHtml)
            ];

            function createdRow(row, data, dataIndex) {
                // Recompiling so we can bind Angular directive to the DT
                $compile(angular.element(row).contents())($scope);
            }

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