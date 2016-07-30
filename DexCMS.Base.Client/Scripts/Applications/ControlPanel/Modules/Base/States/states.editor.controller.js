define([
    'controlpanel-app',
    '../countries/countries.service'
], function (app) {
    app.controller('statesEditorCtrl', [
        '$scope',
        'States',
        '$stateParams',
        '$state',
        'Countries',
        function ($scope, States, $stateParams, $state, Countries) {

            var id = $stateParams.id || null;

            $scope.title = (id == null ? "Add " : "Edit ") + "State";

            $scope.currentItem = {};

            Countries.getList().then(function (response) {
                $scope.countries = response;
            });

            if (id != null) {
                States.getItem(id).then(function (response) {
                    $scope.currentItem = response.data;
                });
            }

            $scope.save = function (item) {
                if (item.stateID) {
                    States.updateItem(item.stateID, item).then(function (response) {
                        $state.go('states');
                    });
                } else {
                    States.createItem(item).then(function (response) {
                        $state.go('states');
                    });
                }
            }
        }
    ]);
});