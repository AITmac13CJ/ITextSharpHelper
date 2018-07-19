using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ITextSharpHelper
{
    internal class TableImpl : TableFactory
    {
        /// <summary>
        /// 添加表格（目前文档中只看到document对象来操作表格，关于同步操作某一模板文件时如何使用同一实例还未实现，如果你有好的方法还请指教）
        /// </summary>
        /// <param name="TemplatePath"></param>
        /// <param name="SaveFilePath"></param>
        /// <param name="Parameter">html字符串</param>
        public override void Add(string TemplatePath, string SaveFilePath, string Parameter)
        {
            Document doc = new Document();
            try
            { 
                doc = new Document(PageSize.LETTER);

                PdfReader reader = new PdfReader(SaveFilePath);

                FileStream temFs = new FileStream(SaveFilePath, FileMode.OpenOrCreate);
                PdfWriter PWriter = PdfWriter.GetInstance(doc, temFs);


                BaseFont bf1 = BaseFont.CreateFont("C:\\Windows\\Fonts\\SIMSUN.TTC,1", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font CellFont = new iTextSharp.text.Font(bf1, 12);
                doc.Open();

                PdfContentByte cb = PWriter.DirectContent;
                for (int pageNumber = 1; pageNumber < reader.NumberOfPages + 1; pageNumber++)
                {
                    doc.SetPageSize(reader.GetPageSizeWithRotation(1));

                    PdfImportedPage page = PWriter.GetImportedPage(reader, pageNumber);
                    int rotation = reader.GetPageRotation(pageNumber);
                    cb.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
                    doc.NewPage();
                }

                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(Parameter);
                XmlNodeList xnlTable = xmldoc.SelectNodes("table");
                if (xnlTable.Count > 0)
                {
                    foreach (XmlNode xn in xnlTable)
                    {
                        //添加表格与正文之间间距
                        doc.Add(new Phrase("\n\n"));

                        // 由html标记和属性解析表格样式
                        var xmltr = xn.SelectNodes("tr");
                        foreach (XmlNode xntr in xmltr)
                        {
                            var xmltd = xntr.SelectNodes("td");
                            PdfPTable newTable = new PdfPTable(xmltd.Count);
                            foreach (XmlNode xntd in xmltd)
                            {
                                PdfPCell newCell = new PdfPCell(new Paragraph(1, xntd.InnerText, CellFont));
                                newTable.AddCell(newCell);//表格添加内容
                                var tdStyle = xntd.Attributes["style"];//获取单元格样式
                                if (tdStyle != null)
                                {
                                    string[] styles = tdStyle.Value.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                                    Dictionary<string, string> dicStyle = new Dictionary<string, string>();
                                    foreach (string strpar in styles)
                                    {
                                        string[] keyvalue = strpar.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                                        dicStyle.Add(keyvalue[0], keyvalue[1]);
                                    }

                                    //设置单元格宽度
                                    if (dicStyle.Select(sty => sty.Key.ToLower().Equals("width")).Count() > 0)
                                    {
                                        newCell.Width = float.Parse(dicStyle["width"]);
                                    }
                                    //设置单元格高度
                                    if (dicStyle.Select(sty => sty.Key.ToLower().Equals("height")).Count() > 0)
                                    {
                                        //newCell.Height = float.Parse(dicStyle["height"]);
                                    }

                                }
                            }
                            doc.Add(newTable);
                        }
                    }

                }

                doc.Close();
                temFs.Close();
                PWriter.Close();
            }
            catch
            {
            }
            finally
            {
                doc.Close();
            }
        }
    }
}
