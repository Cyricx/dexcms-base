define([
    'controlpanel-app'
], function (app) {
    app.controller('settingsListCtrl', [
        '$scope',
        'Settings',
        'DTOptionsBuilder',
        'DTColumnBuilder',
        '$compile',
        '$window',
        function ($scope, Settings, DTOptionsBuilder, DTColumnBuilder, $compile, $window) {
            $scope.title = "View Settings";

            $scope.dtOptions = DTOptionsBuilder.fromFnPromise(function () {
                return Settings.getList();
            }).withBootstrap().withOption('createdRow', createdRow);

            $scope.dtColumns = [
                DTColumnBuilder.newColumn('settingID').withTitle('ID'),
                DTColumnBuilder.newColumn('name').withTitle('Name'),
                DTColumnBuilder.newColumn('value').withTitle('Value').renderWith(renderValue),
                DTColumnBuilder.newColumn('settingDataTypeName').withTitle('Data Type'),
                DTColumnBuilder.newColumn('settingGroupName').withTitle('Setting Group'),
                DTColumnBuilder.newColumn(null).withTitle('').notSortable().renderWith(actionsHtml)
            ];

            function createdRow(row, data, dataIndex) {
                // Recompiling so we can bind Angular directive to the DT
                $compile(angular.element(row).contents())($scope);
            }

            function renderValue(data, type, full, meta) {
                switch (full.settingDataTypeID) {
                    case 2:
                        //console.log(new Date(data));
                        return new Date(data).toLocaleDateString();
                    case 4:
                        return '[Html content not displayed]';
                    case 9:
                        return '********';
    
                    default:
                        return data;
                }
            }

            function actionsHtml(data, type, full, meta) {
                var buttons = '<a class="btn btn-warning" ui-sref="settings/:id({id:' + data.settingID + '})">' +
                   '   <i class="fa fa-edit"></i>' +
                   '</a>';

                    buttons += ' <button class="btn btn-danger" ng-click="delete(' + data.settingID + ')">' +
                   '   <i class="fa fa-trash-o"></i>' +
                   '</button>';

                return buttons;
            }

            $scope.delete = function (id) {
                if (confirm('Are you sure?')) {
                    Settings.deleteItem(id).then(function (response) {
                        $window.location.reload();
                    });
                }
            };
        }
    ]);
});