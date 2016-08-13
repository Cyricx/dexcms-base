define([
    'controlpanel-app'
], function (app) {
    app.controller('countriesListCtrl', [
        '$scope',
        'Countries',
        '$window',
        'dexCMSControlPanelSettings',
        function ($scope, Countries, $window, dexcmsSettings) {
            $scope.title = "View Countries";

            $scope.table = {
                columns: [
                    { property: 'countryID', title: 'ID' },
                    { property: 'name', title: 'Name' },
                    {
                        property: '', title: '', disableSorting: true,
                        dataTemplate: dexcmsSettings.startingRoute + 'modules/base/countries/_countries.list.buttons.html'
                    },
                ],
                defaultSort: 'countryID',
                functions: {
                    remove: function (id) {
                        if (confirm('Are you sure?')) {
                            Countries.deleteItem(id).then(function (response) {
                                $window.location.reload();
                            });
                        }
                    }
                },
                filePrefix: 'Countries'
            };

            Countries.getList().then(function (data) {
                $scope.table.promiseData = data;
            });
        }
    ]);
});