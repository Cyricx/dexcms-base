define([
    'controlpanel-app'
], function (app) {
    app.service('PageContentImages', [
        '$resource',
        '$http',
        function ($resource, $http) {
            var baseUrl = '../api/pagecontentimages';

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
                //Get Selected
                getSelected: function (id) {
                    return $resource(baseUrl + "/" + id).query().$promise;
                },
                //Get All 
                getList: function () {
                    return $resource(baseUrl).query().$promise;
                },

                updateItems: function (items) {
                    console.log('updating');
                    console.log(items);
                    var postData = { pageContentID: items.pageContentID, pageContentImages: [] };
                    for (var i = 0; i < items.pageContentImages.length; i++) {
                        var image = items.pageContentImages[i];
                        postData.pageContentImages.push({
                            imageID: image.imageID,
                            displayOrder: image.displayOrder
                        });
                    }
                    var request = $http({
                        method: "put",
                        url: baseUrl + "/",
                        data: postData
                    });
                    return request;
                },

                //Delete the Record
                deleteItem: function (id, pageContentID) {
                    var request = $http({
                        method: "delete",
                        url: baseUrl + "/" + id + "/" + pageContentID
                    });
                    return request;
                },
            }
        }
    ]);
});