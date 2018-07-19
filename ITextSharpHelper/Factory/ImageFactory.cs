using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITextSharpHelper
{
    public abstract class ImageFactory
    {
        /// <summary>
        /// 批量添加图片
        /// </summary>
        /// <param name="Source"></param> 
        /// <param name="ImageList"></param>
        public abstract void AddImages(BaseModel Source, List<PDFImage> ImageList);
    }
}
