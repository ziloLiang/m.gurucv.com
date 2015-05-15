using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrosage.Utility {
    public class Utils : UtilsBase {

        /// <summary>
        /// 根据图片文件名返回服务器全路径带Http形式的
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="removeClientCookie"></param>
        /// <returns></returns>
        public static String GetImageFullPathString(string filePath, bool removeClientCookie = false) {
            return filePath.IsNull() ? null : string.Format("{0}{1}{2}", ResourceHelper.Img1Server, filePath, removeClientCookie ? string.Format("?t={0}", Guid.NewGuid()) : null);
        }

        /// <summary>
        /// 文件大小转换
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string ConvertFileSize(double size)
        {
            string m_strSize = "";
            double FactSize = size;
            if (FactSize < 1024.00)
                m_strSize = FactSize.ToString("F2") + "B";
            else if (FactSize >= 1024.00 && FactSize < 1048576)
                m_strSize = (FactSize / 1024.00).ToString("F2") + "KB";
            else if (FactSize >= 1048576 && FactSize < 1073741824)
                m_strSize = (FactSize / 1024.00 / 1024.00).ToString("F2") + "MB";
            else if (FactSize >= 1073741824)
                m_strSize = (FactSize / 1024.00 / 1024.00 / 1024.00).ToString("F2") + "GB";
            return m_strSize;
        }
    }
}
