define([
    'controlpanel-app'
], function (app) {
    app.controller('settingGroupsListCtrl', [
        '$scope',
        'SettingGroups',
        '$window',
        'dexCMSControlPanelSettings',
        function ($scope, SettingGroups, $window, dexcmsSettings) {
            $scope.title = "View Setting Groups";

            $scope.table = {
                columns: [
                    { property: 'settingGroupID', title: 'ID' },
                    { property: 'settingGroupName', title: 'Name' },
                ],
                defaultSort: 'settingGroupID',
                functions: {
                    remove: function (id) {
                        if (confirm('Are you sure?')) {
                            SettingGroups.deleteItem(id).then(function (response) {
                                $window.location.reload();
                            });
                        }
                    }
                },
                filePrefix: 'Setting-Groups'
            };

            if (cpUser.isInstaller) {
                $scope.table.columns.push(
                {
                    property: '', title: '', disableSorting: true,
                    dataTemplate: dexcmsSettings.startingRoute + 'modules/base/settinggroups/_settinggroups.list.buttons.html'
                });
            }

            SettingGroups.getList().then(function (data) {
                $scope.table.promiseData = data;
            });
        }
    ]);
});