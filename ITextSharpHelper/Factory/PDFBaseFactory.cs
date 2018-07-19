using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITextSharpHelper
{
    /// <summary>
    /// PDF基础操作工厂类
    /// </summary>
    public abstract class PDFBaseFactory
    {
        /// <summary>
        /// 打开模板文档
        /// </summary>
        /// <param name="TemplatePath"></param>
        /// <param name="SaveFilePath"></param>
        /// <returns>BaseModel</returns>
        public abstract BaseModel OpenDocument(string TemplatePath, string SaveFilePath);

        /// <summary>
        /// 保存文档
        /// </summary> 
        /// <param name="Source"></param>
        public abstract void SaveDocument(BaseModel Source);
    }
}
