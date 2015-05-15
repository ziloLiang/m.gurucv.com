using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Mvc;

namespace Macrosage.Utility.Extensions.Result {
    /// <summary>
    /// 按 Newtonsoft.Json 格式输出返回结果
    /// </summary>
    public class JsonNetResult : JsonResult {

        public override void ExecuteResult(ControllerContext context) {
            if (context == null) {
                throw new ArgumentNullException("context");
            }
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = !String.IsNullOrEmpty(ContentType) ? ContentType : "application/json";
            if (ContentEncoding != null) {
                response.ContentEncoding = ContentEncoding;
            }
            if (Data != null) {
#if DEBUG
                response.Write(JsonConvert.SerializeObject(Data, Formatting.Indented));
#else
                response.Write(JsonConvert.SerializeObject(Data));
#endif
            }
        }
    }
}

