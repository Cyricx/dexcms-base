define([
    'controlpanel-app'
], function (app) {
    app.controller('settingGroupsListCtrl', [
        '$scope',
        'SettingGroups',
        'DTOptionsBuilder',
        'DTColumnBuilder',
        '$compile',
        '$window',
        function ($scope, SettingGroups, DTOptionsBuilder, DTColumnBuilder, $compile, $window) {
            $scope.title = "View Setting Groups";

            $scope.dtOptions = DTOptionsBuilder.fromFnPromise(function () {
                return SettingGroups.getList();
            }).withBootstrap().withOption('createdRow', createdRow);

            $scope.dtColumns = [
                DTColumnBuilder.newColumn('settingGroupID').withTitle('ID'),
                DTColumnBuilder.newColumn('settingGroupName').withTitle('Name'),
               // DTColumnBuilder.newColumn(null).withTitle('').notSortable().renderWith(actionsHtml)
            ];

            function createdRow(row, data, dataIndex) {
                // Recompiling so we can bind Angular directive to the DT
                $compile(angular.element(row).contents())($scope);
            }

            function actionsHtml(data, type, full, meta) {
                var buttons = '<a class="btn btn-warning" ui-sref="settinggroups/:id({id:' + data.settingGroupID + '})">' +
                   '   <i class="fa fa-edit"></i>' +
                   '</a>';
                if (data.settingCount == 0) {
                    buttons += ' <button class="btn btn-danger" ng-click="delete(' + data.settingGroupID + ')">' +
                   '   <i class="fa fa-trash-o"></i>' +
                   '</button>';
                } else {
                    buttons += ' <button class="btn btn-danger" ng-disabled="\'true\'">Currently in use</button';
                }
                return buttons;
            }

            $scope.delete = function (id) {
                if (confirm('Are you sure?')) {
                    SettingGroups.deleteItem(id).then(function (response) {
                        $window.location.reload();
                    });
                }
            };
        }
    ]);
});