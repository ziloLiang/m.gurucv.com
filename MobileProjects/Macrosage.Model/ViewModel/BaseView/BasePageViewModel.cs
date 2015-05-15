using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrosage.Model.ViewModel.BaseView
{
    /// <summary>
    /// 列表型分页
    /// </summary>
     [Serializable]
    public class BasePageViewModel
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        [JsonProperty("pageIndex")]
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页的数量
        /// </summary>
        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        [JsonProperty("pageCount")]
        public int PageCount { get; set; }

        /// <summary>
        /// 总数据条数
        /// </summary>
        [JsonProperty("dataCount")]
        public int DataCount { get; set; }

        /// <summary>
        /// 数据集合
        /// </summary>
        [JsonProperty("list")]
        public Object List { get; set; }
    }
}
