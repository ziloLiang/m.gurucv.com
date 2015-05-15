using System;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Macrosage.Utility.Extensions.Result {
    /// <summary>
    /// Jsonp方式跨域提交数据
    /// </summary>
    public class JsonpResult : JsonResult {
        private const string JsonpCallbackName = "callback";
        private const string CallbackApplicationType = "application/json";//application/x-javascript

        /// <summary>
        /// Enables processing of the result of an action method by a custom type that inherits from the <see cref="T:System.Web.Mvc.ActionResult"/> class.
        /// </summary>
        /// <param name="context">The context within which the result is executed.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="context"/> parameter is null.</exception>
        public override void ExecuteResult(ControllerContext context) {
            if (context == null) {
                throw new ArgumentNullException("context");
            }
            if ((JsonRequestBehavior == JsonRequestBehavior.DenyGet) &&
                  String.Equals(context.HttpContext.Request.HttpMethod, "GET")) {
                throw new InvalidOperationException();
            }
            var response = context.HttpContext.Response;
            response.ContentType = !String.IsNullOrEmpty(ContentType) ? ContentType : CallbackApplicationType;
            if (ContentEncoding != null)
                response.ContentEncoding = this.ContentEncoding;
            if (Data != null) {
                var request = context.HttpContext.Request;
#if DEBUG
                string buffer = request[JsonpCallbackName] != null
                     ? String.Format("{0}({1})", request[JsonpCallbackName], JsonConvert.SerializeObject(Data, Formatting.Indented))
                     : JsonConvert.SerializeObject(Data, Formatting.Indented);
#else
                string buffer = request[JsonpCallbackName] != null
                    ? String.Format("{0}({1})", request[JsonpCallbackName], JsonConvert.SerializeObject(Data))
                    : JsonConvert.SerializeObject(Data);
#endif
                response.Write(buffer);
            }
        }
    }
}
