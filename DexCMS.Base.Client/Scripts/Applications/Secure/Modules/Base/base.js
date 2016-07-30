define([
    'angular',
    './base.settings'
], function (angular, settings) {
    var globalBaseApp = angular.module('dexCMSGlobalsBase', []);

    globalBaseApp.constant('dexCMSGlobalsBaseSettings', settings);

    return globalBaseApp;
})