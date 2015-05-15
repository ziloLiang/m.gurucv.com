using Macrosage.Mobile.GuruCV.helpers;
using Macrosage.Model.Base;
using Macrosage.Utility;
using Macrosage.Utility.Extensions;
using System;
using System.Web;
using System.Web.Mvc;

namespace Macrosage.Mobile.GuruCV.Controllers {
    /// <summary>
    /// 
    /// </summary>
    public class AccountController : Controller {

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login() {
            object result;
            try {
                var data = HttpContext.Request.Form.ToString().AppendRequestFormDataToken();
                var requestResult = HttpHelper.SendPost(string.Format("{0}/Account/Login", ResourceHelper.WebApiServiceDomain), data);
                if (requestResult.IndexOf("10000", System.StringComparison.Ordinal) > 0) {
                    CurrentUserHelpers.PublicByWriteLogin(requestResult);
                }
                return this.JsonNet(requestResult.ToDeserializeObject<object>());
            }
            catch (Exception ex) {
                result = JsonHelper.ResultJson(SystemError.StaticCode.Failure);
            }
            return this.JsonNet(result);
        }

        /// <summary>
        /// 验证用户是否登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AuthenicateUser() {
            object result;
            try {
                if (CurrentUserBase.Cv.Equals(0) || CurrentUserBase.CvNumber.Equals(0)) {
                    result = JsonHelper.ResultJson(SystemError.StaticCode.Failure, "你还没有登录，请先登录", new { isAuthenicated = false });
                }
                else {
                    result = JsonHelper.ResultJson(SystemError.StaticCode.Success, data: new { isAuthenicated = true });
                }
            }
            catch (Exception ex) {
                result = JsonHelper.ResultJson(SystemError.StaticCode.Failure);
            }
            return this.JsonNet(result);
        }
        
    }
}