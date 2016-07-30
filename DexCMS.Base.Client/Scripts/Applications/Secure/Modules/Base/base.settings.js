define([
    'json!./config/dexcms.globals.base.settings.json'
], function (settings) {
    settings = settings || {};

    settings.startingRoute = settings.startingRoute || '../../../scripts/dexcmsapps/globals/base/';

    return settings;

});