"use strict";

define(['app-config', 'accountServices'], function (app) {

    app.register.controller('main-index', ['$scope', '$rootScope', 'accountService', function ($scope, $rootScope, accountService) {

        $scope.initializeController = function() {
            accountService.authenicateUser($scope.initializeApplicationComplete, $scope.initializeApplicationError);
        };

        $scope.initializeApplicationComplete = function (response) {

            if (response.result == 10000 && response.data.isAuthenicated == false)
                $scope.appLogin();
            else if (response.result == 10000 && response.data.isAuthenicated == true) {
                window.location = "/main.html#/message/index";
            } else {
                $scope.appLogin();
            }

        };

        $scope.initializeApplicationError = function (response) {
            alert("当前身份验证失败，请重新验证...");
            setTimeout(function () {
                window.location = "#Account/Login";
            }, 10);
        };

        $scope.appLogin = function() {
            // set timeout needed to prevent AngularJS from raising a digest error
            setTimeout(function() {
                window.location = "#Account/Login";
            }, 10);
        };
    }]);
});


