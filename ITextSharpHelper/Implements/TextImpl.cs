using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITextSharpHelper
{
    internal class TextImpl : TextFactory
    {
        /// <summary>
        /// 填充文本域
        /// </summary>
        /// <param name="Source"></param> 
        /// <param name="Parameters"></param>
        public override void FillDomain(BaseModel Source, Dictionary<string, string> Parameters)
        {
            try
            {
                var pdfStamper = Source.Stamper;
                //读出所有文本域
                AcroFields pdfFormFields = pdfStamper.AcroFields;
                pdfStamper.FormFlattening = true;

                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                BaseFont simheiBase = BaseFont.CreateFont(@"C:\Windows\Fonts\simhei.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                pdfFormFields.AddSubstitutionFont(simheiBase);

                //遍历填充
                foreach (KeyValuePair<string, string> parameter in Parameters)
                {
                    if (pdfFormFields.Fields[parameter.Key] != null)
                    {
                        pdfFormFields.SetField(parameter.Key, parameter.Value);
                    }
                }
            }
            catch
            {
            }
        }
    }
}
