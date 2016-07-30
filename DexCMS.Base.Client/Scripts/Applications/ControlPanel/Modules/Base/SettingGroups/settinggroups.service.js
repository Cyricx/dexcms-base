define([
    'controlpanel-app'
], function (app) {
    app.service('SettingGroups', [
        '$http',
        '$resource',
        function ($http, $resource) {
            var baseUrl = '../api/settinggroups';

            return {
                //Create new record
                createItem: function (item) {
                    var request = $http({
                        method: "post",
                        url: baseUrl,
                        data: item
                    });
                    return request;
                },
                //Get Single Records
                getItem: function (id) {
                    return $http.get(baseUrl + "/" + id);
                },
                //Get All 
                getList: function () {
                    return $resource(baseUrl).query().$promise;
                },
                //Update the Record
                updateItem: function (id, item) {
                    var request = $http({
                        method: "put",
                        url: baseUrl + "/" + id,
                        data: item
                    });
                    return request;
                },
                //Delete the Record
                deleteItem: function (id) {
                    var request = $http({
                        method: "delete",
                        url: baseUrl + "/" + id
                    });
                    return request;
                },
            }
        }
    ]);
});