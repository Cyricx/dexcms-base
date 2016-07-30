define([
    'controlpanel-app'
], function (app) {
    app.controller('settingDataTypesEditorCtrl', [
        '$scope',
        'SettingDataTypes',
        '$stateParams',
        '$state',
        function ($scope, SettingDataTypes, $stateParams, $state) {

            var id = $stateParams.id || null;

            $scope.title = (id == null ? "Add " : "Edit ") + "Setting Data Type";

            $scope.currentItem = {};

            if (id != null) {
                SettingDataTypes.getItem(id).then(function (response) {
                    $scope.currentItem = response.data;
                });
            }

            $scope.save = function (item) {
                if (item.settingDataTypeID) {
                    SettingDataTypes.updateItem(item.settingDataTypeID, item).then(function (response) {
                        $state.go('settingdatatypes');
                    });
                } else {
                    SettingDataTypes.createItem(item).then(function (response) {
                        $state.go('settingdatatypes');
                    });
                }
            }
        }
    ]);
});