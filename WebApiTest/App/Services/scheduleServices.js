(function () {
    'use strict';

    var app = angular.module('scheduleServices', ['ngResource']);

    app.factory('Schedule', ['$resource',
      function ($resource) {
          return $resource('/api/schedule/', {}, {
              query: { method: 'GET', params: {}, isArray: true }
          });
      }]);


})();