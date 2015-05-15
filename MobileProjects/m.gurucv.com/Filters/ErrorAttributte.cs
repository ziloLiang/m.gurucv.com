using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Macrosage.Utility;

namespace Macrosage.Mobile.GuruCV.Filters {
    /// <summary>
    /// 记录错误日志的过滤器ErrorAttributte
    /// </summary>
    public class ErrorAttributte : HandleErrorAttribute {
        /// <summary>
        /// 在发生异常时调用。
        /// </summary>
        /// <param name="filterContext">操作-筛选器上下文。</param>
        public override void OnException(ExceptionContext filterContext) {
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");
            Exception objError = filterContext.Exception;
            var errorMessage = new List<string>
            {
                String.Concat("1.异常页：", HttpContext.Current.Request.Url.ToString()),
                String.Concat("2.来源页面：",(HttpContext.Current.Request.UrlReferrer == null)? "非来源页面进入": HttpContext.Current.Request.UrlReferrer.AbsoluteUri),
                String.Concat("3.异常信息：", objError.Message),
                String.Concat("4.触发异常IP：", Utils.GetIP()),
                String.Concat("5.异常位置：", objError.StackTrace)
            };
            Utils.ErrorLog("Global", string.Join("\r\n", errorMessage));

            if (filterContext.IsChildAction || filterContext.ExceptionHandled)
                return;

            var httpException = objError as HttpException;
            if (filterContext.HttpContext.Request.IsAjaxRequest()) {
                filterContext.Result = new JsonResult() {
                    Data = JsonHelper.ResultJson(SystemError.StaticCode.DefaultMessage,
                        httpException.IsNull()
                            ? "异常..."
                            : string.Format("Http Status Code :{0}", httpException.GetHttpCode()))
                };
            }
            else {
                var page = "index";
                if (!httpException.IsNull()) {
                    switch (httpException.GetHttpCode()) {
                        case 404:
                            page = "HttpError404";
                            break;
                        case 500:
                            page = "HttpError500";
                            break;
                        default:
                            page = "General";
                            break;
                    }
                }
                filterContext.Result = new RedirectResult(string.Format("/error/{0}", page));
            }

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}
