using System;
using System.Web.Mvc;

namespace Macrosage.Mobile.GuruCV.Filters {

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class PublicUserAuthorizeAttribute : ActionFilterAttribute {
        /// <summary>
        /// 用户是否需要登录
        /// </summary>
        /// 
        public bool RequireOwnerIsLogin { get; set; }
    }

}