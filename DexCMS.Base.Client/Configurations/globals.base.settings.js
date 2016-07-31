module.exports = function (appPath) {
    return {
        name: 'GlobalsBaseSettings',
        dest: appPath + '/globals/base/config/dexcms.globals.base.settings.json',
        options: {
            startingRoute: '../../../' + appPath + '/globals/base/'
        }
    };
};