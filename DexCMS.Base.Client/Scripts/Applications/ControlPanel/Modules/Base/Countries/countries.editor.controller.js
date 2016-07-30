define([
    'controlpanel-app'
], function (app) {
    app.controller('countriesEditorCtrl', [
        '$scope',
        'Countries',
        '$stateParams',
        '$state',
        function ($scope, Countries, $stateParams, $state) {

            var id = $stateParams.id || null;

            $scope.title = (id == null ? "Add " : "Edit ") + "Country";

            $scope.currentItem = {};

            if (id != null) {
                Countries.getItem(id).then(function (response) {
                    $scope.currentItem = response.data;
                });
            }

            $scope.save = function (item) {
                if (item.countryID) {
                    Countries.updateItem(item.countryID, item).then(function (response) {
                        $state.go('countries');
                    });
                } else {
                    Countries.createItem(item).then(function (response) {
                        $state.go('countries');
                    });
                }
            }
        }
    ]);
});