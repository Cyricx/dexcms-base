define([
    'controlpanel-app'
], function (app) {
    app.controller('contactTypesListCtrl', [
        '$scope',
        'ContactTypes',
        '$window',
        'dexCMSControlPanelSettings',
        function ($scope, ContactTypes, $window, dexcmsSettings) {
            $scope.title = "View Contact Types";

            $scope.table = {
                columns: [
                    { property: 'contactTypeID', title: 'ID' },
                    { property: 'name', title: 'Name' },
                    { property: 'isActive', title: 'Active?' },
                    {
                        property: '', title: '', disableSorting: true,
                        dataTemplate: dexcmsSettings.startingRoute + 'modules/base/contacttypes/_contacttypes.list.buttons.html'
                    },
                ],
                defaultSort: 'contactTypeID',
                functions: {
                    remove: function (id) {
                        if (confirm('Are you sure?')) {
                            ContactTypes.deleteItem(id).then(function (response) {
                                $window.location.reload();
                            });
                        }
                    }
                },
                filePrefix: 'Contact-Types'
            };

            ContactTypes.getList().then(function (data) {
                $scope.table.promiseData = data;
            });
        }
    ]);
});