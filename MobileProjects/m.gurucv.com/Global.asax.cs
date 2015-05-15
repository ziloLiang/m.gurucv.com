﻿using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Combres;
using Macrosage.Mobile.GuruCV;

namespace Macrosage.UI.Mobile {
    public class Global : HttpApplication {
        void Application_Start(object sender, EventArgs e) {
            MvcHandler.DisableMvcResponseHeader = true;
            //RouteTable.Routes.AddCombresRoute("Combres");
            // 在应用程序启动时运行的代码
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }

    }
}