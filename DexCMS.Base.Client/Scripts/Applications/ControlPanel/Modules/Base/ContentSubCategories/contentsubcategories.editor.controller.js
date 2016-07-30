define([
    'controlpanel-app'
], function (app) {
    app.controller('contentSubCategoriesEditorCtrl', [
        '$scope',
        'ContentSubCategories',
        '$stateParams',
        '$state',
        function ($scope, ContentSubCategories, $stateParams, $state) {

            var id = $stateParams.id || null;

            $scope.title = (id == null ? "Add " : "Edit ") + "Content SubCategories";

            $scope.currentItem = { isActive: true };

            if (id != null) {
                ContentSubCategories.getItem(id).then(function (response) {
                    $scope.currentItem = response.data;
                });
            }

            $scope.save = function (item) {
                if (item.contentSubCategoryID) {
                    ContentSubCategories.updateItem(item.contentSubCategoryID, item).then(function (response) {
                        $state.go('contentsubcategories');
                    });
                } else {
                    ContentSubCategories.createItem(item).then(function (response) {
                        $state.go('contentsubcategories');
                    });
                }
            }
        }
    ]);
});