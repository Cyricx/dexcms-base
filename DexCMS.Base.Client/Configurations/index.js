var cpNavigation = require('./controlpanel.base.navigation'),
    cpRoutes = require('./controlpanel.base.routes');

module.exports = function (appPath, overrides) {
    overrides = overrides || {};
    overrides.navigation = overrides.navigation || {};

    var settings = [];
    settings.push(cpNavigation(appPath, overrides.navigation));
    settings.push(cpRoutes(appPath));
    return settings;
};