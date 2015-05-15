using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrosage.Model.Base.Notice
{
        [Serializable]
   public  class LetterRelationModel
    {
        /// <summary>
        /// 发送私信主键
        /// </summary>
        public long LetterId { get; set; }
        /// <summary>
        /// 接收人咕噜号
        /// </summary>
        public long ReceiveCvNumber { get; set; }
        /// <summary>
        /// 接收人是否阅读，默认false
        /// </summary>
        public bool IsRead { get; set; }
        /// <summary>
        /// 接收人删除该私信，默认false
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// AddTime
        /// </summary>
        public DateTime AddTime { get; set; }
    }
}
