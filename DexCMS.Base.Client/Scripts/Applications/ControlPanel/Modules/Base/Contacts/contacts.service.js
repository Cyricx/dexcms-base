define([
    'controlpanel-app'
], function (app) {
    app.service('Contacts', [
        '$resource',
        '$http',
        'DexCmsDateCleaner',
        function ($resource, $http, DateCleaner) {
            var baseUrl = '../api/contacts';

            var _forServer = function (item) {
                var adjustedItem = angular.copy(item);

                adjustedItem.submitDate = DateCleaner.preServerProcess(adjustedItem.submitDate);

                return adjustedItem;
            };

            var _fromServer = function (item) {
                item.submitDate = DateCleaner.correctTimeZone(item.submitDate);
            };

            return {
                //Create new record
                createItem: function (item) {
                    var request = $http({
                        method: "post",
                        url: baseUrl,
                        data: _forServer(item)
                    });
                    return request;
                },
                //Get Single Records
                getItem: function (id) {
                    return $http.get(baseUrl + "/" + id).then(function (response) {
                        _fromServer(response.data);
                        return response;
                    });
                },
                //Get All 
                getList: function () {
                    return $resource(baseUrl).query().$promise.then(function (response) {
                        angular.forEach(response, function (data) {
                            _fromServer(data);
                        });
                        return response;
                    });
                },
                //Update the Record
                updateItem: function (id, item) {
                     var request = $http({
                        method: "put",
                        url: baseUrl + "/" + id,
                        data: _forServer(item)
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