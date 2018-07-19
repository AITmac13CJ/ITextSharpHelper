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
    internal class ImageImpl : ImageFactory
    {
        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="Source"></param> 
        /// <param name="ImageList"></param>
        public override void AddImages(BaseModel Source, List<PDFImage> ImageList)
        {
            try
            {
                var pdfReader = Source.Reader;
                var pdfStamper = Source.Stamper;

                //页面高度（cm）
                float pageHeight = 29.7f;

                foreach (var pdfImage in ImageList)
                {
                    //获取PDF指定页面内容
                    var pdfContentByte = pdfStamper.GetOverContent(pdfImage.PageIndex);
                    Uri uri = null;
                    Image img = null;
                    var imageUrl = pdfImage.ImageUrl;

                    //如果使用网络路径则先将图片转化位绝对路径
                    if (imageUrl.StartsWith("http"))
                    {
                        var absolutePath = System.Web.HttpContext.Current.Server.MapPath("..") + imageUrl;
                        uri = new Uri(absolutePath);
                        img = Image.GetInstance(uri);
                    }
                    else
                    {
                        //如果直接使用图片文件则直接创建iTextSharp的Image对象
                        if (!string.IsNullOrWhiteSpace(imageUrl))
                        {
                            img = Image.GetInstance(imageUrl);
                        }
                    }

                    if (img != null)
                    {
                        //设置高度和宽度
                        img.ScaleAbsolute(pdfImage.FitWidth, pdfImage.FitHeight); 
                        //计算Y轴, 页面高度-Y轴高度 为图片距底部高度，/2.54*72后将cm转为pt，最后减去图片自身高度，即为Y轴坐标
                        float absoluteY = (pageHeight - pdfImage.AbsoluteY) / 2.54f * 72f - pdfImage.FitHeight;
                        //设置图片位置的X轴和Y轴
                        img.SetAbsolutePosition(pdfImage.AbsoluteX, absoluteY);
                        pdfContentByte.AddImage(img);
                    }
                }
            }
            catch
            {
            }
        }
    }
}
