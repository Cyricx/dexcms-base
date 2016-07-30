define([
    'controlpanel-app'
], function (app) {
    app.controller('settingDataTypesListCtrl', [
        '$scope',
        'SettingDataTypes',
        'DTOptionsBuilder',
        'DTColumnBuilder',
        '$compile',
        '$window',
        function ($scope, SettingDataTypes, DTOptionsBuilder, DTColumnBuilder, $compile, $window) {
            $scope.title = "View Setting Data Types";

            $scope.dtOptions = DTOptionsBuilder.fromFnPromise(function () {
                return SettingDataTypes.getList();
            }).withBootstrap().withOption('createdRow', createdRow);

            $scope.dtColumns = [
                DTColumnBuilder.newColumn('settingDataTypeID').withTitle('ID'),
                DTColumnBuilder.newColumn('name').withTitle('Name'),
               // DTColumnBuilder.newColumn(null).withTitle('').notSortable().renderWith(actionsHtml)
            ];

            function createdRow(row, data, dataIndex) {
                // Recompiling so we can bind Angular directive to the DT
                $compile(angular.element(row).contents())($scope);
            }

            function actionsHtml(data, type, full, meta) {
                var buttons = '<a class="btn btn-warning" ui-sref="settingdatatypes/:id({id:' + data.settingDataTypeID + '})">' +
                   '   <i class="fa fa-edit"></i>' +
                   '</a>';

                if (data.settingCount == 0) {
                    buttons += ' <button class="btn btn-danger" ng-click="delete(' + data.settingDataTypeID + ')">' +
                   '   <i class="fa fa-trash-o"></i>' +
                   '</button>';
                } else {
                    buttons += ' <button class="btn btn-danger" ng-disabled="\'true\'">Currently in use</button';
                }
                return buttons;
            }

            $scope.delete = function (id) {
                if (confirm('Are you sure?')) {
                    SettingDataTypes.deleteItem(id).then(function (response) {
                        $window.location.reload();
                    });
                }
            };

        }
    ]);
});