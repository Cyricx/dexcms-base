define([
    'controlpanel-app'
], function (app) {
    app.controller('contentAreasEditorCtrl', [
        '$scope',
        'ContentAreas',
        '$stateParams',
        '$state',
        function ($scope, ContentAreas, $stateParams, $state) {

            var id = $stateParams.id || null;

            $scope.title = (id == null ? "Add " : "Edit ") + "Content Area";

            $scope.currentItem = { isActive: true };

            if (id != null) {
                ContentAreas.getItem(id).then(function (response) {
                    $scope.currentItem = response.data;
                });
            }

            $scope.save = function (item) {
                if (item.contentAreaID) {
                    ContentAreas.updateItem(item.contentAreaID, item).then(function (response) {
                        $state.go('contentareas');
                    });
                } else {
                    ContentAreas.createItem(item).then(function (response) {
                        $state.go('contentareas');
                    });
                }
            }
        }
    ]);
});