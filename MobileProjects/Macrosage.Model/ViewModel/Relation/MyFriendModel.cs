using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrosage.Model.ViewModel.Relation
{
    [Serializable]
    public class MyFriendModel
    {
        /// <summary>
        /// 好友所在分组（0为无分组，默认为0）
        /// </summary>
        public long FriendGroupId { get; set; }
        /// <summary>
        /// 个人咕噜号id
        /// </summary>
        public long CvNumber { get; set; }
        /// <summary>
        /// 好友咕噜号id
        /// </summary>
        public long FriendCvNumber { get; set; }
        /// <summary>
        /// 好友状态 0.删除 1.正常 2.黑名单 3.回收站
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// AddTime
        /// </summary>
        public DateTime AddTime { get; set; }
    }
}
