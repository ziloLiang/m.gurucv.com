using Macrosage.Utility.Extensions.Result;
using System.Web.Mvc;

namespace Macrosage.Utility.Extensions {
    /// <summary>
    /// 
    /// </summary>
    public static class ControllerExtensions {
        /// <summary>
        /// Extension methods for the controller to allow jsonp.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static JsonpResult Jsonp(this Controller controller, object data) {
            JsonpResult result = new JsonpResult {
                Data = data,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            return result;
        }

        /// <summary>
        /// Extension methods for the controller to allow JsonNet.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static JsonNetResult JsonNet(this Controller controller, object data) {
            JsonNetResult result = new JsonNetResult {
                Data = data,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            return result;
        }
    }
}
