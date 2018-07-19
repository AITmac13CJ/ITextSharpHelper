using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITextSharpHelper 
{
    public class BaseModel
    {
        public PdfReader Reader { get; set; }

        public PdfStamper Stamper { get; set; }
    }
}
