define([
    'controlpanel-app'
], function (app) {
    app.controller('contactsDetailsCtrl', [
        '$scope',
        'Contacts',
        '$stateParams',
        function ($scope, Contacts, $stateParams) {

            var id = $stateParams.id || null;

            $scope.title = "View Contact";

            $scope.currentItem = {};

            if (id != null) {
                Contacts.getItem(id).then(function (response) {
                    $scope.currentItem = response.data;
                    $scope.currentItem.submitDate = new Date($scope.currentItem.submitDate);
                });
            }
        }
    ]);
});