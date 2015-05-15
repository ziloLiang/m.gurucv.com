using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrosage.Model.Base.Notice
{
        [Serializable]
   public class NoticeActionModel
    {
        /// <summary>
        /// 私信主键
        /// </summary>
        public long LetterId { get; set; }
        /// <summary>
        /// 用户操作种类 0同操作 1确定操作
        /// </summary>
        public bool NoticeActionType { get; set; }
        /// <summary>
        /// 私信操作状态 1同意 0不同意
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// AddTime
        /// </summary>
        public DateTime AddTime { get; set; }
    }
}
