define([
    'controlpanel-app'
], function (app) {
    app.controller('pageTypesListCtrl', [
        '$scope',
        'PageTypes',
        '$window',
        'dexCMSControlPanelSettings',
        function ($scope, PageTypes, $window, dexcmsSettings) {
            $scope.title = "View Page Types";

            $scope.table = {
                columns: [
                    { property: 'pageTypeID', title: 'ID' },
                    { property: 'name', title: 'Name' },
                    { property: 'isActive', title: 'Active?' },
                    {
                        property: '', title: '', disableSorting: true,
                        dataTemplate: dexcmsSettings.startingRoute + 'modules/base/pagetypes/_pagetypes.list.buttons.html'
                    },
                ],
                defaultSort: 'pageTypeID',
                functions: {
                    remove: function (id) {
                        if (confirm('Are you sure?')) {
                            PageTypes.deleteItem(id).then(function (response) {
                                $window.location.reload();
                            });
                        }
                    }
                },
                filePrefix: 'Page-Types'
            };

            PageTypes.getList().then(function (data) {
                $scope.table.promiseData = data;
            });

        }
    ]);
});