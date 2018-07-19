using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITextSharpHelper
{
    public abstract class TableFactory
    {
        /// <summary>
        /// 添加表格
        /// </summary>
        /// <param name="TemplatePath"></param>
        /// <param name="SaveFilePath"></param>
        /// <param name="Parameter"></param>
        public abstract void Add(string TemplatePath, string SaveFilePath, string Parameter);
    }
}
