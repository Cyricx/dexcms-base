define([
    'controlpanel-app'
], function (app) {
    app.controller('statesListCtrl', [
        '$scope',
        'States',
        'DTOptionsBuilder',
        'DTColumnBuilder',
        '$compile',
        '$window',
        function ($scope, States, DTOptionsBuilder, DTColumnBuilder, $compile, $window) {
            $scope.title = "View States";

            $scope.dtOptions = DTOptionsBuilder.fromFnPromise(function () {
                return States.getList();
            }).withBootstrap().withOption('createdRow', createdRow);

            $scope.dtColumns = [
                DTColumnBuilder.newColumn('stateID').withTitle('ID'),
                DTColumnBuilder.newColumn('name').withTitle('Name'),
                DTColumnBuilder.newColumn('countryName').withTitle('Country'),
                DTColumnBuilder.newColumn('abbreviation').withTitle('Abbrev'),
                DTColumnBuilder.newColumn(null).withTitle('').notSortable().renderWith(actionsHtml)
            ];

            function createdRow(row, data, dataIndex) {
                // Recompiling so we can bind Angular directive to the DT
                $compile(angular.element(row).contents())($scope);
            }

            function actionsHtml(data, type, full, meta) {
                var buttons = '<a class="btn btn-warning" ui-sref="states/:id({id:' + data.stateID + '})">' +
                   '   <i class="fa fa-edit"></i>' +
                   '</a>';
                if (!data.inUse) {
                    buttons += ' <button class="btn btn-danger" ng-click="delete(' + data.stateID + ')">' +
                   '   <i class="fa fa-trash-o"></i>' +
                   '</button>';
                } else {
                    buttons += ' <button class="btn btn-danger" ng-disabled="\'true\'">Currently in use</button';
                }
                return buttons;
            }

            $scope.delete = function (id) {
                if (confirm('Are you sure?')) {
                    States.deleteItem(id).then(function (response) {
                        $window.location.reload();
                    });
                }
            };
        }
    ]);
});