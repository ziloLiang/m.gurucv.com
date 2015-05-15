define(['app-config', 'ajaxService'], function (app) {

    app.register.service('accountService', ['ajaxService', function (ajaxService) {

        this.login = function (user, successFunction, errorFunction) {
            ajaxService.AjaxPostWithNoAuthenication(user, "/api/account/Login", successFunction, errorFunction,"登陆中...");
        };

        this.authenicateUser = function (successFunction, errorFunction) {
            ajaxService.AjaxGet("/api/account/AuthenicateUser", successFunction, errorFunction);
        };

        this.getUser = function (successFunction, errorFunction) {
            ajaxService.AjaxGet("/api/account/GetUser", successFunction, errorFunction);
        };

        this.logout = function (successFunction, errorFunction) {
            ajaxService.AjaxGet("/api/account/Logout", successFunction, errorFunction);
        };
    }]);
});