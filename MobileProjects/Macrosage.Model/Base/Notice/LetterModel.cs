using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrosage.Model.Base.Notice
{
        [Serializable]
    public class LetterModel
    {
        /// <summary>
        /// 私信主键
        /// </summary>
        public long LetterId { get; set; }
        /// <summary>
        /// 个人咕噜号
        /// </summary>
        public long CvNumber { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 私信内容
        /// </summary>
        public string Contents { get; set; }
        /// <summary>
        /// 是否带有附件，默认false
        /// </summary>
        public bool IsAnnex { get; set; }
        /// <summary>
        /// 私信类型
        /// </summary>
        public bool LetterType { get; set; }
        /// <summary>
        /// 私信类型 0默认值 1好友验证 2在职员工导入 3面试通知 4录用通知
        /// </summary>
        public int NoticeType { get; set; }
        /// <summary>
        /// AddTime
        /// </summary>
        public DateTime AddTime { get; set; }
    }
}
