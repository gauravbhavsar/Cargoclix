(function () {
    'use strict';

    angular
        .module('scheduleApp')
        .controller('scheduleController', scheduleController);

    scheduleController.$inject = ['$scope', 'schedule'];

    function scheduleController($scope, schedule) {
        $scope.schedule = schedule.query();
    }
})();