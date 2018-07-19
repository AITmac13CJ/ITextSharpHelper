using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITextSharpHelper
{
    /// <summary>
    /// PDF模板操作
    /// </summary>
    public class PDFTemplateOpt : ITextSharpFacade
    {
        /// <summary>
        /// 文本
        /// </summary>
        /// <returns></returns>
        public override TextFactory TextFactory()
        {
            return new TextImpl();
        }

        /// <summary>
        /// 图片
        /// </summary>
        /// <returns></returns>
        public override ImageFactory ImageFactory()
        {
            return new ImageImpl();
        }


        /// <summary>
        /// 表格
        /// </summary>
        /// <returns></returns>
        public override TableFactory TableFactory()
        {
            return new TableImpl();
        }


        /// <summary>
        /// 水印
        /// </summary>
        /// <returns></returns>
        public override WatermarkFactory WatermarkFactory()
        {
            return new WatermarkImpl();
        }

        /// <summary>
        /// Base
        /// </summary>
        /// <returns></returns>
        public override PDFBaseFactory PDFBaseFactory()
        {
            return new PDFBaseImpl();
        }
    }
}
