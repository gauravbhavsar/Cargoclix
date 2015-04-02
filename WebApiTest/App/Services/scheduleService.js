(function () {
    'use strict';

    var scheduleService = angular.module('scheduleService', ['ngResource']);

    scheduleService.factory('schedule', ['$resource',
    function ($resource) {
        return $resource('/api/schedule/', {}, {
            query: { method: 'GET', params: {}, isArray: true }
        });
    }]);


})();