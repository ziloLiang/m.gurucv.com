﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrosage.Model.Base.Notice
{
     [Serializable]
    public class AnnexModel
    {
        /// <summary>
        /// 附件主键
        /// </summary>
        [JsonProperty("annexId")]
        public long AnnexId { get; set; }
        /// <summary>
        /// 私信主键
        /// </summary>
        [JsonProperty("letterId")]
        public long LetterId { get; set; }
        /// <summary>
        /// 发布人id
        /// </summary>
        [JsonProperty("cvNumber")]
        public long CvNumber { get; set; }
        /// <summary>
        /// 附件名称
        /// </summary>
        [JsonProperty("annexName")]
        public string AnnexName { get; set; }
        /// <summary>
        /// 附件大小（单位：kb）
        /// </summary>
        [JsonProperty("annexSize")]
        public double AnnexSize { get; set; }
        /// <summary>
        /// 附件类型文字 1.image，2.word，3.excel，4.flash，5.media，6.file
        /// </summary>
        [JsonProperty("annexTypeString")]
        public string AnnexTypeString { get; set; }
        /// <summary>
        /// Url
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
        /// <summary>
        /// AddTime
        /// </summary>
        [JsonProperty("addTime")]
        public DateTime AddTime { get; set; }
    }
}
