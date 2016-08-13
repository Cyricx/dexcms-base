define([
    'controlpanel-app'
], function (app) {
    app.controller('layoutTypesListCtrl', [
        '$scope',
        'LayoutTypes',
        '$window',
        'dexCMSControlPanelSettings',
        function ($scope, LayoutTypes, $window, dexcmsSettings) {
            $scope.title = "View Layout Types";

            $scope.table = {
                columns: [
                    { property: 'layoutTypeID', title: 'ID' },
                    { property: 'name', title: 'Name' },
                    { property: 'cssClass', title: 'Css' },
                    {
                        property: '', title: '', disableSorting: true,
                        dataTemplate: dexcmsSettings.startingRoute + 'modules/base/layouttypes/_layouttypes.list.buttons.html'
                    },
                ],
                defaultSort: 'layoutTypeID',
                functions: {
                    remove: function (id) {
                        if (confirm('Are you sure?')) {
                            LayoutTypes.deleteItem(id).then(function (response) {
                                $window.location.reload();
                            });
                        }
                    }
                },
                filePrefix: 'Layout-Types'
            };

            LayoutTypes.getList().then(function (data) {
                $scope.table.promiseData = data;
            });
        }
    ]);
});