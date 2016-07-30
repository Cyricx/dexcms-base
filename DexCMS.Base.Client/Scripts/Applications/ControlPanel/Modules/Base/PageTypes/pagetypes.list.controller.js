define([
    'controlpanel-app'
], function (app) {
    app.controller('pageTypesListCtrl', [
        '$scope',
        'PageTypes',
        'DTOptionsBuilder',
        'DTColumnBuilder',
        '$compile',
        '$window',
        function ($scope, PageTypes, DTOptionsBuilder, DTColumnBuilder, $compile, $window) {
            $scope.title = "View Page Types";

            $scope.dtOptions = DTOptionsBuilder.fromFnPromise(function () {
                return PageTypes.getList();
            }).withBootstrap().withOption('createdRow', createdRow);

            $scope.dtColumns = [
                DTColumnBuilder.newColumn('pageTypeID').withTitle('ID'),
                DTColumnBuilder.newColumn('name').withTitle('Name'),
                DTColumnBuilder.newColumn('isActive').withTitle('Active?'),
                DTColumnBuilder.newColumn(null).withTitle('').notSortable().renderWith(actionsHtml)
            ];

            function createdRow(row, data, dataIndex) {
                // Recompiling so we can bind Angular directive to the DT
                $compile(angular.element(row).contents())($scope);
            }

            function actionsHtml(data, type, full, meta) {
                var buttons = '<a class="btn btn-warning" ui-sref="pagetypes/:id({id:' + data.pageTypeID + '})">' +
                   '   <i class="fa fa-edit"></i>' +
                   '</a>';
                if (data.contentCount == 0) {
                    buttons += ' <button class="btn btn-danger" ng-click="delete(' + data.pageTypeID + ')">' +
                   '   <i class="fa fa-trash-o"></i>' +
                   '</button>';
                } else {
                    buttons += ' <button class="btn btn-danger" ng-disabled="\'true\'">Currently in use</button';
                }
                return buttons;
            }

            $scope.delete = function (id) {
                if (confirm('Are you sure?')) {
                    PageTypes.deleteItem(id).then(function (response) {
                        $window.location.reload();
                    });
                }
            };
        }
    ]);
});