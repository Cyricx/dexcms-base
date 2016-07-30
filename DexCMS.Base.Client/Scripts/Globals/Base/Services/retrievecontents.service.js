define([
    '../base'
], function (module) {
    module.service('RetrieveContents', ['$http', function ($http) {

        return {
            getContent: function (contentName) {
                return $http.get('../../../api/retrievecontents/' + contentName);
            }
        }
    }]);
});