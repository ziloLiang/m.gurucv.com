using System.Web.Mvc;

namespace Macrosage.Mobile.GuruCV.Filters {
    /// <summary>
    /// 用于处理用户操作权限的过滤器
    /// </summary>
    public class UserAuthorizeAttribute : PublicUserAuthorizeAttribute {
        /// <summary>7
        /// 重写基类在Action之前执行的方法
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            //Trace.WriteLine(String.Format("OnActionExecuting:{0}", CurrentUser.CvNumber));
            //判断cookie是否存在 如果不存在则跳转到 登录页面 

            //if (RequireOwnerIsLogin && CurrentUser.CvNumber.Equals(0)) {
            //    var returnUrl = WebUtility.UrlEncode(HttpContext.Current.Request.Url.AbsoluteUri);
            //    var dic = new RouteValueDictionary();
            //    if (!returnUrl.IsNull())
            //        dic.Add("ReturnUrl", returnUrl);
            //    if (!filterContext.HttpContext.Request.IsAjaxRequest()) {
            //        filterContext.Result = new RedirectResult(CacheUrlHelper.Action("Login", "Account", null, dic));
            //    }
            //    else {
            //        //filterContext.Result = new ContentResult() { Content = JsonHelper.CreateResultJson(SystemError.StaticCode.DefaultMessage, "15000", "该操作执行失败,可能您登陆时间已过期或其他原因。") };
            //        filterContext.Result = new JsonResult() {
            //            Data = JsonHelper.ResultJson(SystemError.StaticCode.DefaultMessage, "该操作执行失败,可能您登陆时间已过期或其他原因。", new {
            //                returnUrl = CacheUrlHelper.Action("Login", "Account", null, dic)
            //            })
            //        };
            //    }
            //}
            //else {
            //    if (!filterContext.HttpContext.Request.IsAjaxRequest()) {
            //        var result =
            //            MemcachedHelper.GetData<CvLoginCacheModel>(string.Format(MsCacheName.GetOnlineUser,
            //                CurrentUser.CvNumber));
            //        if (!result.IsNull() && !result.IsDefaultSet) {
            //            filterContext.Result = new RedirectResult(string.Format("{0}/step-baseinfo?t={1}", ResourceHelper.RegWizardDomain, CurrentUser.InfoSource));
            //        }
            //    }
            //}

            base.OnActionExecuting(filterContext);
        }
    }
}