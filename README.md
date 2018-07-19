# ITextSharpHelper
ITextSharp Tools Class
The Sample：
FillText:
    string templatePath = "E:\\ITextSharp\\1.pdf"; //Source Url
    string saveFilePath = "E:\\ITextSharp\\2.pdf"; //Target Url
    string imageUrl = "C:\\Users\\Eternal\\Pictures\\cap.png";  //Image Url
    Dictionary<string, string> dicPra = new Dictionary<string, string>();  //will Replace Field
    dicPra.Add("UserName", " YuCong"); //Field 1
    dicPra.Add("Remark", "Hahaha!You are pig! big pig!");  //Field 2
    var source = Base.OpenDocument(templatePath, saveFilePath); //Open Source File, Get PdfReader and PdfStamper Object 
    Text.FillDomain(source, dicPra); //Text Replace
    Watermark.AddText(source, "hello watermark"); //Add Watermark
    Image.AddImages(source, new List<PDFImage>() {   //Insert Image List
                new PDFImage { 
                    ImageUrl = imageUrl ,  //Url
                    AbsoluteX = 168.66F,  //X
                    AbsoluteY =  1.8f,   //Y
                    FitHeight = 200,    //Height
                    FitWidth = 300,     //Width
                    PageIndex =1      //Page Number
                }
            });
    Base.SaveDocument(source);    // Close File And Save
