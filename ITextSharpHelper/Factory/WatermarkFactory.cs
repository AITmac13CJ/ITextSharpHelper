using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITextSharpHelper
{
    public abstract class WatermarkFactory
    {
        /// <summary>
        /// 添加文字水印
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="WaterMarkName"></param>
        /// <returns></returns>
        public abstract void AddText(BaseModel Source, string WaterMarkName);
    }
}
