(function () {
    'use strict';

    angular
        .module('scheduleApp')
        .controller('scheduleController', scheduleController);

    scheduleController.$inject = ['$scope', 'Schedules'];

    function moviesController($scope, Schedules) {
        $scope.schedules = Schedules.query();
    }
})();