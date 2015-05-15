using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Macrosage.Utility;
using Macrosage.Utility.Cache;

namespace Macrosage.Model.Base {
   public   class CurrentUserBase {

        /// <summary>
        /// 当前登录用户的信息
        /// </summary>
        public static CvLoginCacheModel UserInfo {
            get {
                var model = MemcachedHelper.GetData<CvLoginCacheModel>(string.Format(MsCacheName.GetOnlineUser,
                    Cv));
                return model ?? new CvLoginCacheModel();
            }
        }

        /// <summary>
        /// 获取当前登录用户的id
        /// </summary>
        /// <value>The uid.</value>
        public static Guid Uid {
            get {
                return UserInfo.Uid;
            }
        }

        /// <summary>
        /// 获取当前用户的咕噜号
        /// </summary>
        /// <value>The cv number.</value>
        public static Int64 CvNumber {
            get {
                return UserInfo.CvNumber;
            }
        }

        /// <summary>
        /// 从Cookie中获取当前用户的咕噜号
        /// </summary>
        /// <value>The cv number.</value>
        public static Int64 Cv {
            get {
                return MsCookie.GetCookie("loginUser", "GuruNum").ToInt64();
            }
        }

        /// <summary>
        /// 获取当前用户的生日
        /// </summary>
        /// <value>The birthday.</value>
        public static string Birthday {
            get {
                return UserInfo.Birthday;
            }
        }

        /// <summary>
        /// 获取当前用户的邮箱
        /// </summary>
        /// <value>The birthday.</value>
        public static string Email {
            get {
                return UserInfo.Email;
            }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        /// <value>The name.</value>
        public static string Name {
            get {
                return UserInfo.Name;
            }
        }

        /// <summary>
        /// 中图
        /// </summary>
        /// <value>The middle.</value>
        public static string Middle {
            get {
                var middle = UserInfo.HeadPhotos ?? string.Format("/image/{0}_per_middle.jpg", UserInfo.Uid);
                return Utils.GetImageFullPathString(middle, true);
            }
        }

        /// <summary>
        /// 平台Id
        /// </summary>
        public static Int32 PlatformId {
            get {
                return UserInfo.PlId;
            }
        }

        /// <summary>
        /// 注册来源标识
        /// </summary>
        public static Int32 InfoSource {
            get {
                return UserInfo.InfoSource;
            }
        }


    }
}
