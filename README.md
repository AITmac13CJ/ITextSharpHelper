# ITextSharpHelper<br>  
ITextSharp Tools Class<br>  
The Sample：<br>  
FillText:<br>  
>　　string templatePath = "E:\\ITextSharp\\1.pdf"; //Source Url<br>  
　　string saveFilePath = "E:\\ITextSharp\\2.pdf"; //Target Url<br>  
  　　string imageUrl = "C:\\Users\\Eternal\\Pictures\\cap.png";  //Image Url<br>  
    　　Dictionary<string, string> dicPra = new Dictionary<string, string>();  //will Replace Field<br>  
      　　dicPra.Add("UserName", " YuCong"); //Field 1<br>  
        　　dicPra.Add("Remark", "Hahaha!You are pig! big pig!");  //Field 2<br>  
          　　var source = Base.OpenDocument(templatePath, saveFilePath); //Open Source File, Get PdfReader and PdfStamper<br>
            　　Text.FillDomain(source, dicPra); //Text Replace<br>  
    　　Watermark.AddText(source, "hello watermark"); //Add Watermark<br>  
    　　Image.AddImages(source, new List<PDFImage>() {   //Insert Image List<br>  
        　　        new PDFImage {<br>  
  　　　　ImageUrl = imageUrl ,  //Url<br>  
              　　     　　 AbsoluteX = 168.66F,  //X<br>  
                  　　　　  AbsoluteY =  1.8f,   //Y<br>  
                   　　　　 FitHeight = 200,    //Height<br>  
                    　　　　FitWidth = 300,     //Width<br>  
                   　　 　　PageIndex =1      //Page Number<br>  
                　　}<br>  
            　　});<br>  
    　　Base.SaveDocument(source);    // Close File And Save<br>  

