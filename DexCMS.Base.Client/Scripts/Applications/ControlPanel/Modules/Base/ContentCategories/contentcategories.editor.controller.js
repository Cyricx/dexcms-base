define([
    'controlpanel-app'
], function (app) {
    app.controller('contentCategoriesEditorCtrl', [
        '$scope',
        'ContentCategories',
        '$stateParams',
        '$state',
        function ($scope, ContentCategories, $stateParams, $state) {

            var id = $stateParams.id || null;

            $scope.title = (id == null ? "Add " : "Edit ") + "Content Categories";

            $scope.currentItem = { isActive: true };

            if (id != null) {
                ContentCategories.getItem(id).then(function (response) {
                    $scope.currentItem = response.data;
                });
            }

            $scope.save = function (item) {
                if (item.contentCategoryID) {
                    ContentCategories.updateItem(item.contentCategoryID, item).then(function (response) {
                        $state.go('contentcategories');
                    });
                } else {
                    ContentCategories.createItem(item).then(function (response) {
                        $state.go('contentcategories');
                    });
                }
            }
        }
    ]);
});