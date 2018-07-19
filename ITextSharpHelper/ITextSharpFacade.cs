using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITextSharpHelper
{
    /// <summary>
    /// ITextSharp抽象工厂
    /// 提供基本元素的工厂类
    /// 可扩展PDF，Excel，Word等
    /// </summary>
    public abstract class ITextSharpFacade
    {
        /// <summary>
        /// PDF基础工厂
        /// </summary>
        /// <returns></returns>
        public abstract PDFBaseFactory PDFBaseFactory();

        /// <summary>
        /// 文本工厂
        /// </summary>
        /// <returns></returns>
        public abstract TextFactory TextFactory();

        /// <summary>
        /// 图片工厂
        /// </summary>
        /// <returns></returns>
        public abstract ImageFactory ImageFactory();

        /// <summary>
        /// 表格工厂
        /// </summary>
        /// <returns></returns>
        public abstract TableFactory TableFactory();

        /// <summary>
        /// 水印工厂
        /// </summary>
        /// <returns></returns>
        public abstract WatermarkFactory WatermarkFactory();
    }
}
