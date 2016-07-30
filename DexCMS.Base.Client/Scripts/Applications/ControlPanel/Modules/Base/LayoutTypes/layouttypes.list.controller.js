define([
    'controlpanel-app'
], function (app) {
    app.controller('layoutTypesListCtrl', [
        '$scope',
        'LayoutTypes',
        'DTOptionsBuilder',
        'DTColumnBuilder',
        '$compile',
        '$window',
        function ($scope, LayoutTypes, DTOptionsBuilder, DTColumnBuilder, $compile, $window) {
            $scope.title = "View Layout Types";

            $scope.dtOptions = DTOptionsBuilder.fromFnPromise(function () {
                return LayoutTypes.getList();
            }).withBootstrap().withOption('createdRow', createdRow);

            $scope.dtColumns = [
                DTColumnBuilder.newColumn('layoutTypeID').withTitle('ID'),
                DTColumnBuilder.newColumn('name').withTitle('Name'),
                DTColumnBuilder.newColumn('cssClass').withTitle('Css'),
                DTColumnBuilder.newColumn(null).withTitle('').notSortable().renderWith(actionsHtml)
            ];

            function createdRow(row, data, dataIndex) {
                // Recompiling so we can bind Angular directive to the DT
                $compile(angular.element(row).contents())($scope);
            }

            function actionsHtml(data, type, full, meta) {
                var buttons = '<a class="btn btn-warning" ui-sref="layouttypes/:id({id:' + data.layoutTypeID + '})">' +
                   '   <i class="fa fa-edit"></i>' +
                   '</a>';
                if (data.pageContentsCount == 0) {
                    buttons += ' <button class="btn btn-danger" ng-click="delete(' + data.layoutTypeID + ')">' +
                   '   <i class="fa fa-trash-o"></i>' +
                   '</button>';
                } else {
                    buttons += ' <button class="btn btn-danger" ng-disabled="\'true\'">Currently in use</button';
                }
                return buttons;
            }

            $scope.delete = function (id) {
                if (confirm('Are you sure?')) {
                    LayoutTypes.deleteItem(id).then(function (response) {
                        $window.location.reload();
                    });
                }
            };
        }
    ]);
});