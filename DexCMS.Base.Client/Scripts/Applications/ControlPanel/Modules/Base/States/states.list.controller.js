define([
    'controlpanel-app'
], function (app) {
    app.controller('statesListCtrl', [
        '$scope',
        'States',
        '$window',
        'dexCMSControlPanelSettings',
        function ($scope, States, $window, dexcmsSettings) {
            $scope.title = "View States";

            $scope.table = {
                columns: [
                    { property: 'stateID', title: 'ID' },
                    { property: 'name', title: 'Name' },
                    { property: 'countryName', title: 'Country' },
                    { property: 'abbreviation', title: 'Abbrev' },
                    {
                        property: '', title: '', disableSorting: true,
                        dataTemplate: dexcmsSettings.startingRoute + 'modules/base/states/_states.list.buttons.html'
                    }
                ],
                defaultSort: 'stateID',
                functions: {
                    remove: function (id) {
                        if (confirm('Are you sure?')) {
                            States.deleteItem(id).then(function (response) {
                                $window.location.reload();
                            });
                        }
                    }
                },
                filePrefix: 'States'
            };

            States.getList().then(function (data) {
                $scope.table.promiseData = data;
            });
        }
    ]);
});