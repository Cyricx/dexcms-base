define([
    'controlpanel-app'
], function (app) {
    app.controller('countriesListCtrl', [
        '$scope',
        'Countries',
        'DTOptionsBuilder',
        'DTColumnBuilder',
        '$compile',
        '$window',
        function ($scope, Countries, DTOptionsBuilder, DTColumnBuilder, $compile, $window) {
            $scope.title = "View Countries";

            $scope.dtOptions = DTOptionsBuilder.fromFnPromise(function () {
                return Countries.getList();
            }).withBootstrap().withOption('createdRow', createdRow);

            $scope.dtColumns = [
                DTColumnBuilder.newColumn('countryID').withTitle('ID'),
                DTColumnBuilder.newColumn('name').withTitle('Name'),
                DTColumnBuilder.newColumn(null).withTitle('').notSortable().renderWith(actionsHtml)
            ];

            function createdRow(row, data, dataIndex) {
                // Recompiling so we can bind Angular directive to the DT
                $compile(angular.element(row).contents())($scope);
            }

            function actionsHtml(data, type, full, meta) {
                var buttons = '<a class="btn btn-warning" ui-sref="countries/:id({id:' + data.countryID + '})">' +
                   '   <i class="fa fa-edit"></i>' +
                   '</a>';
                if (data.stateCount == 0) {
                    buttons += ' <button class="btn btn-danger" ng-click="delete(' + data.countryID + ')">' +
                   '   <i class="fa fa-trash-o"></i>' +
                   '</button>';
                } else {
                    buttons += ' <button class="btn btn-danger" ng-disabled="\'true\'">Currently in use</button';
                }
                return buttons;
            }

            $scope.delete = function (id) {
                if (confirm('Are you sure?')) {
                    Countries.deleteItem(id).then(function (response) {
                        $window.location.reload();
                    });
                }
            };
        }
    ]);
});