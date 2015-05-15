using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrosage.Model.Base.Notice
{
        [Serializable]
    public class ImportantLetterModel
    {
        /// <summary>
        /// 重要私信主键
        /// </summary>
        public long ImportantId { get; set; }
        /// <summary>
        /// 发送人咕噜号
        /// </summary>
        public long CvNumber { get; set; }
        /// <summary>
        /// 收件人咕噜号
        /// </summary>
        public long ReceiveCvNumber { get; set; }
        /// <summary>
        /// AddTime
        /// </summary>
        public DateTime AddTime { get; set; }
    }
}
