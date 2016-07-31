var cpNavigation = require('./controlpanel.base.navigation'),
    cpRoutes = require('./controlpanel.base.routes'),
    globalSettings = require('./globals.base.settings');

module.exports = function (appPath, overrides) {
    overrides = overrides || {};
    overrides.navigation = overrides.navigation || {};

    var settings = [];
    settings.push(cpNavigation(appPath, overrides.navigation));
    settings.push(cpRoutes(appPath));
    settings.push(globalSettings(appPath));
    return settings;
};