define([
    'controlpanel-app'
], function (app) {
    app.controller('settingDataTypesListCtrl', [
        '$scope',
        'SettingDataTypes',
        '$window',
        'dexCMSControlPanelSettings',
        function ($scope, SettingDataTypes, $window, dexcmsSettings) {
            $scope.title = "View Setting Data Types";

            $scope.table = {
                columns: [
                    { property: 'settingDataTypeID', title: 'ID' },
                    { property: 'name', title: 'Name' },
                ],
                defaultSort: 'settingDataTypeID',
                functions: {
                    remove: function (id) {
                        if (confirm('Are you sure?')) {
                            SettingDataTypes.deleteItem(id).then(function (response) {
                                $window.location.reload();
                            });
                        }
                    }
                },
                filePrefix: 'Setting-Datatypes'
            };

            if (cpUser.isInstaller) {
                $scope.table.columns.push(
                {
                    property: '', title: '', disableSorting: true,
                    dataTemplate: dexcmsSettings.startingRoute + 'modules/base/settingdatatypes/_settingdatatypes.list.buttons.html'
                });
            }

            SettingDataTypes.getList().then(function (data) {
                $scope.table.promiseData = data;
            });
        }
    ]);
});