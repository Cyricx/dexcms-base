define([
    'controlpanel-app'
], function (app) {
    app.controller('pageTypesEditorCtrl', [
        '$scope',
        'PageTypes',
        '$stateParams',
        '$state',
        function ($scope, PageTypes, $stateParams, $state) {

            var id = $stateParams.id || null;

            $scope.title = (id == null ? "Add " : "Edit ") + "Page Type";

            $scope.currentItem = { isActive: true };

            if (id != null) {
                PageTypes.getItem(id).then(function (response) {
                    $scope.currentItem = response.data;
                });
            }

            $scope.save = function (item) {
                if (item.pageTypeID) {
                    PageTypes.updateItem(item.pageTypeID, item).then(function (response) {
                        $state.go('pagetypes');
                    });
                } else {
                    PageTypes.createItem(item).then(function (response) {
                        $state.go('pagetypes');
                    });
                }
            }
        }
    ]);
});