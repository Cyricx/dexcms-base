define([
    'controlpanel-app'
], function (app) {
    app.service('ContentBlockOrders', [
        '$resource',
        '$http',
        function ($resource, $http) {
            var baseUrl = '../api/contentblockorder';

            return {
                //Update the Record
                updateItems: function (items) {
                    var postData = {};
                    for (var i = 0; i < items.length; i++) {
                        var contentBlock = items[i];
                        postData['ContentBlockID' + (i + 1)] = contentBlock.contentBlockID;
                        postData['DisplayOrder' + (i + 1)] = i;
                    }
                    var request = $http({
                        method: "put",
                        url: baseUrl + "/",
                        data: postData
                    });
                    return request;
                }
            }
        }
    ]);
});