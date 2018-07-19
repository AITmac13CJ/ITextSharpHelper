using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITextSharpHelper
{
    public class PDFImage
    {
        /// <summary>
        /// 图片URL地址
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// 图片域宽
        /// </summary>
        public float FitWidth { get; set; }
        /// <summary>
        /// 图片域高
        /// </summary>
        public float FitHeight { get; set; }
        /// <summary>
        /// 绝对X坐标
        /// </summary>
        public float AbsoluteX { get; set; }
        /// <summary>
        /// 绝对Y坐标
        /// </summary>
        public float AbsoluteY { get; set; }

        /// <summary>
        /// 页码（初始为1）
        /// </summary>
        public int PageIndex { get; set; }
    }
}
