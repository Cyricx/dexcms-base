define([
    'controlpanel-app'
], function (app) {
    app.controller('contactTypesEditorCtrl', [
        '$scope',
        'ContactTypes',
        '$stateParams',
        '$state',
        function ($scope, ContactTypes, $stateParams, $state) {

            var id = $stateParams.id || null;

            $scope.title = (id == null ? "Add " : "Edit ") + "Contact Type";

            $scope.currentItem = {};

            if (id != null) {
                ContactTypes.getItem(id).then(function (response) {
                    $scope.currentItem = response.data;
                });
            }

            $scope.save = function (item) {
                if (item.contactTypeID) {
                    ContactTypes.updateItem(item.contactTypeID, item).then(function (response) {
                        $state.go('contacttypes');
                    });
                } else {
                    ContactTypes.createItem(item).then(function (response) {
                        $state.go('contacttypes');
                    });
                }
            }
        }
    ]);
});