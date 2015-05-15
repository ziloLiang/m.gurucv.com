using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Macrosage.Model.Base;
using Macrosage.Utility;

namespace Macrosage.Mobile.GuruCV.helpers {
    public class CurrentUserHelpers {

        /// <summary>
        /// 登陆成功向客户端写入信息
        /// </summary>
        /// <param name="result"></param>
        public static void PublicByWriteLogin(string result) {
            var obj = result.ToDeserializeObject<dynamic>();
            if (obj.result == 10000) {
                string cv = obj.data.cv.Value.ToString();
                MsCookie.WriteCookie("loginUser", "GuruNum", cv, Utils.GetAppSettings("CacheTime").ToInt32(), ResourceHelper.GuruCVTopDomain);
            }
        }

        /// <summary>
        /// 第三方服务登陆[同步Cookie]
        /// </summary>
        /// <param name="list"></param>
        public static void PublicByThirdParty(List<string> list) {
            MsCookie.WriteCookie("loginUser", "GuruNum", list[1], Utils.GetAppSettings("CacheTime").ToInt32(), ResourceHelper.GuruCVTopDomain);
        }

        /// <summary>
        /// 刷新用户数据
        /// </summary>
        public static void RefreshCvData(string cv = null) {
            try {
                var dic = new Dictionary<string, object>()
                {
                    {"cvNumber", cv.IsNotNull()?cv: CurrentUserBase.CvNumber.ToStrings()},
                    {"plId", ResourceHelper.ProjectId}
                };
                HttpHelper.SendPost(string.Format("{0}/Account/RefreshCvData", ResourceHelper.WebApiServiceDomain), dic.ToRequestFormDataAuth());
            }
            catch (Exception) { }
        }

    }
}