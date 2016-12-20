define([
    'controlpanel-app'
], function (app) {
    app.controller('settingsListCtrl', [
        '$scope',
        'Settings',
        '$window',
        'dexCMSControlPanelSettings',
        function ($scope, Settings, $window, dexcmsSettings) {
            $scope.title = "View Settings";
            $scope.isInstaller = cpUser.isInstaller;

            $scope.table = {
                columns: [
                    { property: 'settingID', title: 'ID' },
                    { property: 'name', title: 'Name' },
                    {
                        property: 'value', title: 'Value',
                        dataFunctions: function (value, item) {
                            switch (item.settingDataTypeID) {
                                case 2:
                                    //console.log(new Date(data));
                                    return new Date(value).toLocaleDateString();
                                case 4:
                                    return '[Html content not displayed]';
                                case 9:
                                    return '********';

                                default:
                                    return value;
                            }
                        },
                        cssClass: 'col-xs-4'
                    },
                    { property: 'settingDataTypeName', title: 'Data Type' },
                    { property: 'settingGroupName', title: 'Setting Group' }
                ],
                defaultSort: 'settingID',
                functions: {
                    remove: function (id) {
                        if (confirm('Are you sure?')) {
                            Settings.deleteItem(id).then(function (response) {
                                $window.location.reload();
                            });
                        }
                    }
                },
                filePrefix: 'Settings'
            };

            if (cpUser.isInstaller) {
                $scope.table.columns.push(
                    {
                        property: '', title: '', disableSorting: true,
                        dataTemplate: dexcmsSettings.startingRoute + 'modules/base/settings/_settings.list.buttons.html'
                    });
            } else {
                $scope.table.columns.push(
                    {
                        property: '', title: '', disableSorting: true,
                        dataTemplate: dexcmsSettings.startingRoute + 'modules/base/settings/_settings.list.editonly.buttons.html'
                    });
            }

            Settings.getList().then(function (data) {
                $scope.table.promiseData = data;
            });
        }
    ]);
});