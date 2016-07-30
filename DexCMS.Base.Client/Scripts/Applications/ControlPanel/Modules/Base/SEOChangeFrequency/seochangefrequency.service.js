define([
    'controlpanel-app'
], function (app) {
    app.service('SeoChangeFrequency', function () {
        return {
            getList: function () {
                return [
                    { id: 0, name: 'Always' },
                    { id: 1, name: 'Hourly'},
                    { id: 2, name: 'Daily'},
                    { id: 3, name: 'Weekly'},
                    { id: 4, name: 'Monthly'},
                    { id: 5, name: 'Yearly'},
                    { id: 6, name: 'Never' }
                ];
            }
        };
    });
});