using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITextSharpHelper
{
    public class PDFBaseImpl : PDFBaseFactory
    {
        /// <summary>
        /// 打开模板文档
        /// </summary>
        /// <param name="TemplatePath"></param> 
        /// <param name="SaveFilePath"></param>
        /// <returns></returns>
        public override BaseModel OpenDocument(string TemplatePath, string SaveFilePath)
        {
            PdfReader pdfReader = new PdfReader(TemplatePath);
            PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(SaveFilePath, FileMode.OpenOrCreate));
            return new BaseModel { Reader = pdfReader, Stamper = pdfStamper };
        }

        /// <summary>
        /// 保存文档
        /// </summary>
        /// <param name="Source"></param>
        public override void SaveDocument(BaseModel Source)
        {
            Source.Stamper.Close();
            Source.Reader.Close();
            Source.Stamper = null;
            Source.Reader = null;
        }
    }
}
