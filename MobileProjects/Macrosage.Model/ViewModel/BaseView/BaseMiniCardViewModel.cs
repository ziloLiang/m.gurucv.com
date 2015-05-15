using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrosage.Model.ViewModel.BaseView
{
    /// <summary>
    /// 用户基础信息，公用
    /// </summary>
     [Serializable]
    public class BaseMiniCardViewModel
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// 咕噜号 
        /// </summary>
        [JsonProperty("cvNumber")]
        public long CvNumber { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        [JsonProperty("headPhotos")]
        public string HeadPhotos { get; set; }
    }
}
