define([
    'controlpanel-app'
], function (app) {
    app.controller('contentSubCategoriesListCtrl', [
        '$scope',
        'ContentSubCategories',
        'DTOptionsBuilder',
        'DTColumnBuilder',
        '$compile',
        '$window',
        function ($scope, ContentSubCategories, DTOptionsBuilder, DTColumnBuilder, $compile, $window) {
            $scope.title = "View Content SubCategories";

            $scope.dtOptions = DTOptionsBuilder.fromFnPromise(function () {
                return ContentSubCategories.getList();
            }).withBootstrap().withOption('createdRow', createdRow);

            $scope.dtColumns = [
                DTColumnBuilder.newColumn('contentSubCategoryID').withTitle('ID'),
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
                var buttons = '<a class="btn btn-warning" ui-sref="contentsubcategories/:id({id:' + data.contentSubCategoryID + '})">' +
                   '   <i class="fa fa-edit"></i>' +
                   '</a>';
                if (data.contentCount == 0) {
                    buttons += ' <button class="btn btn-danger" ng-click="delete(' + data.contentSubCategoryID + ')">' +
                   '   <i class="fa fa-trash-o"></i>' +
                   '</button>';
                } else {
                    buttons += ' <button class="btn btn-danger" ng-disabled="\'true\'">Currently in use</button';
                }
                return buttons;
            }

            $scope.delete = function (id) {
                if (confirm('Are you sure?')) {
                    ContentSubCategories.deleteItem(id).then(function (response) {
                        $window.location.reload();
                    });
                }
            };
        }
    ]);
});