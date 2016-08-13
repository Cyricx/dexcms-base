define([
    'controlpanel-app'
], function (app) {
    app.controller('contactsListCtrl', [
        '$scope',
        'Contacts',
        '$window',
        '$filter',
        'dexCMSControlPanelSettings',
        function ($scope, Contacts, $window, $filter, dexcmsSettings) {
            $scope.title = "View Contacts";

            var _getDateValue = function (value, item) {
                return $filter('date')(value, "MM/dd/yyyy h:mm a");
            };

            $scope.table = {
                columns: [
                    { property: 'contactID', title: 'ID' },
                    { property: 'name', title: 'Name' },
                    { property: 'phone', title: 'Phone' },
                    { property: 'email', title: 'Email' },
                    { property: 'submitDate', title: 'Date', dataFunction: _getDateValue },
                    {
                        property: '', title: '', disableSorting: true,
                        dataTemplate: dexcmsSettings.startingRoute + 'modules/base/contacts/_contacts.list.buttons.html'
                    },
                ],
                defaultSort: 'submitDate',
                defaultSortDescending: true,
                functions: {
                    remove: function (id) {
                        if (confirm('Are you sure?')) {
                            Contacts.deleteItem(id).then(function (response) {
                                $window.location.reload();
                            });
                        }
                    }
                },
                filePrefix:'Contacts'
            };

            Contacts.getList().then(function (data) {
                $scope.table.promiseData = data;
            });

        }
    ]);
});