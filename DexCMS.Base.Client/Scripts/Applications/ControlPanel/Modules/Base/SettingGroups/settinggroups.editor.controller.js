define([
    'controlpanel-app'
], function (app) {
    app.controller('settingGroupsEditorCtrl', [
        '$scope',
        'SettingGroups',
        '$stateParams',
        '$state',
        function ($scope, SettingGroups, $stateParams, $state) {

            var id = $stateParams.id || null;

            $scope.title = (id == null ? "Add " : "Edit ") + "Setting Group";

            $scope.currentItem = {};

            if (id != null) {
                SettingGroups.getItem(id).then(function (response) {
                    $scope.currentItem = response.data;
                });
            }

            $scope.save = function (item) {
                if (item.settingGroupID) {
                    SettingGroups.updateItem(item.settingGroupID, item).then(function (response) {
                        $state.go('settinggroups');
                    });
                } else {
                    SettingGroups.createItem(item).then(function (response) {
                        $state.go('settinggroups');
                    });
                }
            }
        }
    ]);
});