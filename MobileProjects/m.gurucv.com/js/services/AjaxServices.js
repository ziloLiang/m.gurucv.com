
define(['app-config'], function (app) {

    app.register.service('ajaxService', ['$http', 'blockUI', function ($http, blockUI) {

        this.AjaxPost = function (data, route, successFunction, errorFunction,message) {
            blockUI.start();
            setTimeout(function () {
                $http.post(route, data).success(function (response, status, headers, config) {
                    blockUI.stop();
                    successFunction(response, status);
                }).error(function (response) {
                    blockUI.stop();
                    if (response.IsAuthenicated == false) {
                        window.location = "/index.html";
                    }
                    errorFunction(response);
                });
            }, 1000);
        };

        this.AjaxPostWithNoAuthenication = function (data, route, successFunction, errorFunction, message) {
            blockUI.start(message);
            //console.log(blockUI.state());
            setTimeout(function () {
                $http.post(route, data).success(function (response, status, headers, config) {
                    blockUI.stop();
                    successFunction(response, status);
                }).error(function (response) {
                    blockUI.stop();
                    errorFunction(response);
                });
            }, 1000);

        };

        this.AjaxGet = function (route, successFunction, errorFunction, message) {
            blockUI.start(message);
            setTimeout(function () {
                $http({ method: 'GET', url: route }).success(function (response, status, headers, config) {
                    blockUI.stop();
                    successFunction(response, status);
                }).error(function (response) {
                    blockUI.stop();
                    if (response.IsAuthenicated == false) {
                        window.location = "/index.html";
                    }
                    errorFunction(response);
                });
            }, 1000);

        };

        this.AjaxGetWithData = function (data, route, successFunction, errorFunction, message) {
            blockUI.start(message);
            setTimeout(function () {
                $http({ method: 'GET', url: route, params: data }).success(function (response, status, headers, config) {
                    blockUI.stop();
                    successFunction(response, status);
                }).error(function (response) {
                    blockUI.stop();
                    if (response.IsAuthenicated == false) {
                        window.location = "/index.html";
                    }
                    errorFunction(response);
                });
            }, 1000);
        };

        this.AjaxGetWithNoBlock = function (data, route, successFunction, errorFunction) {
            setTimeout(function () {
                $http({ method: 'GET', url: route, params: data }).success(function (response, status, headers, config) {
                    successFunction(response, status);
                }).error(function (response) {;
                    if (response.IsAuthenicated == false) {
                        window.location = "/index.html";
                    }
                    errorFunction(response);
                });
            }, 0);
        };
    }]);
});


