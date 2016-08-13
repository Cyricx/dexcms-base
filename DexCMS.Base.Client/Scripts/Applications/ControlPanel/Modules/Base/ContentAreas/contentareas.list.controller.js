define([
    'controlpanel-app'
], function (app) {
    app.controller('contentAreasListCtrl', [
        '$scope',
        'ContentAreas',
        '$window',
        'dexCMSControlPanelSettings',
        function ($scope, ContentAreas, $window, dexcmsSettings) {
            $scope.title = "View Content Areas";

            $scope.table = {
                columns: [
                    { property: 'contentAreaID', title: 'ID' },
                    { property: 'name', title: 'Name' },
                    { property: 'urlSegment', title: 'Url' },
                    { property: 'isActive', title: 'Active?' },
                    {
                        property: '', title: '', disableSorting: true,
                        dataTemplate: dexcmsSettings.startingRoute + 'modules/base/contentareas/_contentareas.list.buttons.html'
                    },
                ],
                defaultSort: 'contentAreaID',
                functions: {
                    remove: function (id) {
                        if (confirm('Are you sure?')) {
                            ContentAreas.deleteItem(id).then(function (response) {
                                $window.location.reload();
                            });
                        }
                    }
                },
                filePrefix: 'Content-Areas'
            };

            ContentAreas.getList().then(function (data) {
                $scope.table.promiseData = data;
            });
        }
    ]);
});