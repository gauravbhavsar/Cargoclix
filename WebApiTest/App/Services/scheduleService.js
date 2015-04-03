(function () {
    'use strict';

    var scheduleService = angular.module('scheduleService', ['ngResource']);

    scheduleService.service('schedule', ['$resource',
    function ($resource) {
        return $resource('/api/schedule/1', {}, {
            query: { method: 'GET', params: {}, isArray: false }
        });
    }]);


})();