"use strict";

define(['angularAMD', 'angular-route', 'blockUI'], function (angularAmd) {
    var app = angular.module("webapp", ['ngRoute', 'blockUI']);

    app.config(function ($httpProvider) {
        //$httpProvider.defaults.headers.common['X-Requested-With'] = 'XMLHttpRequest';
        // Use x-www-form-urlencoded Content-Type
        $httpProvider.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';
        $httpProvider.defaults.withCredentials = true;
        /**
           * The workhorse; converts an object to x-www-form-urlencoded serialization.
           * @param {Object} obj
           * @return {String}
           */
        var param = function (obj) {
            var query = '', name, value, fullSubName, subName, subValue, innerObj, i;
            for (name in obj) {
                value = obj[name];
                if (value instanceof Array) {
                    for (i = 0; i < value.length; ++i) {
                        subValue = value[i];
                        fullSubName = name + '[' + i + ']';
                        innerObj = {};
                        innerObj[fullSubName] = subValue;
                        query += param(innerObj) + '&';
                    }
                }
                else if (value instanceof Object) {
                    for (subName in value) {
                        subValue = value[subName];
                        fullSubName = name + '[' + subName + ']';
                        innerObj = {};
                        innerObj[fullSubName] = subValue;
                        query += param(innerObj) + '&';
                    }
                }
                else if (value !== undefined && value !== null)
                    query += encodeURIComponent(name) + '=' + encodeURIComponent(value) + '&';
            }
            return query.length ? query.substr(0, query.length - 1) : query;
        };
        // Override $http service's default transformRequest
        $httpProvider.defaults.transformRequest = [function (data) {
            return angular.isObject(data) && String(data) !== '[object File]' ? param(data) : data;
        }];
    });

    //app.config(function (blockUIConfigProvider) {

    //    // Change the default overlay message
    //    blockUIConfigProvider.message("处理中...");
    //    // Change the default delay to 100ms before the blocking is visible
    //    blockUIConfigProvider.delay(1);
    //    // Disable automatically blocking of the user interface
    //    blockUIConfigProvider.autoBlock(false);

    //});

    app.config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when("/", angularAmd.route({
                templateUrl: function (rp) { return 'Views/main/index.html'; },
                controllerUrl: "js/controllers/main/index"
            }))
            .when("/:section/:tree", angularAmd.route({
                templateUrl: function (rp) { return 'views/' + rp.section + '/' + rp.tree + '.html'; },
                resolve: {
                    load: ['$q', '$rootScope', '$location', function ($q, $rootScope, $location) {
                        var path = $location.path();
                        var parsePath = path.split("/");
                        var parentPath = parsePath[1];
                        var controllerName = parsePath[2];
                        var loadController ="js/controllers/"+ parentPath + "/" + controllerName;
                        var deferred = $q.defer();
                        require([loadController], function () {
                            $rootScope.$apply(function () {
                                deferred.resolve();
                            });
                        });
                        return deferred.promise;
                    }]
                }
            }))
            .when("/:section/:tree/:id", angularAmd.route({
                templateUrl: function (rp) { return 'views/' + rp.section + '/' + rp.tree + '.html'; },
                resolve: {
                    load: ['$q', '$rootScope', '$location', function ($q, $rootScope, $location) {
                        var path = $location.path();
                        var parsePath = path.split("/");
                        var parentPath = parsePath[1];
                        var controllerName = parsePath[2];
                        var loadController = "js/controllers/" + parentPath + "/" + controllerName;
                        var deferred = $q.defer();
                        require([loadController], function () {
                            $rootScope.$apply(function () {
                                deferred.resolve();
                            });
                        });
                        return deferred.promise;
                    }]
                }
            }))
            .otherwise({ redirectTo: '/' });
    }
    ]);

    var indexController = function ($scope, $rootScope, $http, $location, blockUI) {

        $scope.$on('$routeChangeStart', function (scope, next, current) {
            if ($rootScope.IsloggedIn == true) {
                $scope.authenicateUser($location.path(), $scope.authenicateUserComplete, $scope.authenicateUserError);
            }
        });

        $scope.$on('$routeChangeSuccess', function (scope, next, current) {

        });

        $scope.initializeController = function() {
            if ($location.path() != "") {
                $scope.initializeApplication($scope.authenicateUserComplete, $scope.authenicateUserError);
            }
        };

        $scope.initializeApplication = function (successFunction, errorFunction) {
            $scope.authenicateUser($location.path(), successFunction, errorFunction);
        };

        $scope.authenicateUser = function (route, successFunction, errorFunction) {
            var authenication = new Object();
            authenication.route = route;
            $scope.AjaxGetWithData(authenication, "/api/account/AuthenicateUser", successFunction, errorFunction);
        };

        $scope.authenicateUserComplete = function (response) {
            if (response.result == 10000 && response.data.isAuthenicated == false)
                window.location = "#Account/Login";
            else if (response.result == 10000 && response.data.isAuthenicated == true) {
                $rootScope.IsloggedIn = true;
            } else {
                window.location = "#Account/Login";
            }
        };

        $scope.authenicateUserError = function (response) {
            alert("ERROR= " + response.data.isAuthenicated);
        };

        $scope.AjaxGet = function (route, successFunction, errorFunction) {
            blockUI.start();
            setTimeout(function () {
                $http({ method: 'GET', url: route }).success(function (response, status, headers, config) {
                    blockUI.stop();
                    successFunction(response, status);
                }).error(function (response) {
                    blockUI.stop();
                    errorFunction(response);
                });
            }, 10);
        };

        $scope.AjaxGetWithData = function (data, route, successFunction, errorFunction) {
            blockUI.start();
            setTimeout(function () {
                $http({ method: 'GET', url: route, params: data }).success(function (response, status, headers, config) {
                    blockUI.stop();
                    successFunction(response, status);
                }).error(function (response) {
                    blockUI.stop();
                    errorFunction(response);
                });
            }, 10);
        };
    };

    indexController.$inject = ['$scope', '$rootScope', '$http', '$location', 'blockUI'];
    app.controller("indexController", indexController);

    //angularAmd.bootstrap(app);

    return app;
});