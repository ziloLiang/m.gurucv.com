"use strict";

define(['app-config', 'accountServices'], function (app) {

    app.register.controller('loginController', ['$scope', '$rootScope', 'accountService',
        function ($scope, $rootScope, accountService) {
            $scope.login = function () {
                $rootScope.IsloggedIn = false;
                var user = $scope.createLoginCredentials();
                accountService.login(user, $scope.loginCompleted, $scope.loginError);
            };
            $scope.loginCompleted = function (response) {
                if (response.result==10000) {
                    window.location = "/main.html#/message/index";
                } else {
                    alert(response.msg);
                }
            };
            $scope.loginError = function (response) {
                alert("登录失败");
            };
            $scope.createLoginCredentials = function () {
                var user = new Object();
                user.loginName = $scope.userName;
                user.loginPwd = $scope.passWord;
                return user;
            };
        }]);
});
