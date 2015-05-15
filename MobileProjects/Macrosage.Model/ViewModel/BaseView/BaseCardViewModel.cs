using Macrosage.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrosage.Model.ViewModel.BaseView
{
      [Serializable]
  public  class BaseCardViewModel
    {
        /// <summary>
        /// CvNumber
        /// </summary>
        [JsonProperty("cvNumber")]
        public long CvNumber { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Title1String
        /// </summary>
        [JsonProperty("title1String")]
        public string Title1String { get; set; }

        /// <summary>
        /// Title2String
        /// </summary>
        [JsonProperty("title2String")]
        public string Title2String { get; set; }

        /// <summary>
        /// CurrentCityString
        /// </summary>
        [JsonProperty("currentCityString")]
        public string CurrentCityString { get; set; }

        private string _webUrl;

        [JsonProperty("webUrl")]
        public virtual string WebUrl
        {
            set { _webUrl = value; }
            get
            {
                return _webUrl.IsNull()
                    ? null
                    : (_webUrl.IndexOf("http://", StringComparison.CurrentCultureIgnoreCase) > -1
                        ? _webUrl
                        : string.Format("{0}/{1}", ResourceHelper.GuruCVShowDomain, _webUrl));
            }
        }

        ///// <summary>
        ///// Email
        ///// </summary>
        //[JsonProperty("email")]
        //[JsonIgnore]
        //public string Email { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        [JsonProperty("phone")]
        [JsonIgnore]
        public string Phone { get; set; }

        /// <summary>
        /// HeadPhotos
        /// </summary>
        [JsonProperty("headPhotos")]
        public string HeadPhotos { get; set; }

        /// <summary>
        /// 微名言
        /// </summary>
        [JsonProperty("microMotto")]
        public string MicroMotto { get; set; }

        /// <summary>
        /// 浏览次数
        /// </summary>
        [JsonProperty("browseNum")]
        public int BrowseNum { get; set; }


        /// <summary>
        /// 二维码
        /// </summary>
        [JsonProperty("qrCodeString")]
        public string QrCodeString { get; set; }

        /// <summary>
        /// 是否是好友
        /// </summary>
        [JsonProperty("isFriend")]
        public bool IsFriend { get; set; }
    }
}
