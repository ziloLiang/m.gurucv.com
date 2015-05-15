using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrosage.Model.ViewModel.Relation
{
    [Serializable]
    public class FriendGroupModel
    {
        /// <summary>
        /// 好友分组主键
        /// </summary>
        [JsonProperty("friendGroupId")]
        public long FriendGroupId { get; set; }
        /// <summary>
        /// 个人咕噜号id
        /// </summary>
        [JsonProperty("cvNumber")]
        public long CvNumber { get; set; }
        /// <summary>
        /// 分组名称
        /// </summary>
        [JsonProperty("groupName")]
        public string GroupName { get; set; }
        /// <summary>
        /// 分组中人数（在增加、转移好友时更新此字段）
        /// </summary>
        [JsonProperty("groupNumber")]
        public int GroupNumber { get; set; }
        /// <summary>
        /// 分组排序（按增加顺序递增）
        /// </summary>
        [JsonProperty("sort"), JsonIgnore]
        public int Sort { get; set; }
        /// <summary>
        /// AddTime
        /// </summary>
        [JsonProperty("cvNumber"), JsonIgnore]
        public string AddTime { get; set; }
    }
}
