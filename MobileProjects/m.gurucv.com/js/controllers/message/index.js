"use strict";

define(['app-config', 'messageServices'], function (app) {

    app.register.controller('message-index', ['$scope', '$rootScope', 'messageService',
        function ($scope, $rootScope, messageService) {
            $scope.total = 100;
        }]);
});
