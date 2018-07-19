using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITextSharpHelper
{
    public abstract class TextFactory
    {
        /// <summary>
        /// 填充文本域
        /// </summary>
        /// <param name="Source"></param> 
        /// <param name="Parameters"></param>
        public abstract void FillDomain(BaseModel Source, Dictionary<string, string> Parameters);
    }
}
