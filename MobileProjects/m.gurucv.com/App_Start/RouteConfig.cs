using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Macrosage.Mobile.GuruCV {
    public class RouteConfig {

        private const String ApiPrefix = "api/";

        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            RegisterRoutesByAccount(routes);

            RegisterRoutesByMessage(routes);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional }
            );
        }

        #region Account

        /// <summary>
        /// 账户
        /// </summary>
        /// <param name="routes"></param>
        protected static void RegisterRoutesByAccount(RouteCollection routes) {
            //用户登录
            routes.MapRoute(
                name: "Api/Account/Login",
                url: ApiPrefix + "Account/Login",
                defaults: new { controller = "Account", action = "Login" }
                );

            //校验是否验证通过
            routes.MapRoute(
                name: "Api/Account/AuthenicateUser",
                url: ApiPrefix + "Account/AuthenicateUser",
                defaults: new { controller = "Account", action = "AuthenicateUser" }
                );
        }

        #endregion

        #region Message

        /// <summary>
        /// 沟通
        /// </summary>
        /// <param name="routes"></param>
        protected static void RegisterRoutesByMessage(RouteCollection routes) {

        }

        #endregion

    }
}
