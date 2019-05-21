# 代码适用声明

1. **GitHub 只是本段代码的 托管平台 —— 权利归原作者所有。GitHub 无权替原作者 决定此源码是否被用于 美国政府的科技霸凌。**

2. **作者本不想 参与政治较力，希望技术中立，开源共享，为全世界的技术发展尽一份力。**

3. **作者对美国人民没有敌意，但不希望看到 自己本想中立的开源代码 成为 任何国家科技霸凌的帮凶。**

4. **特此声明：在美国政府胁迫本该中立的开源社区，使之成为科技霸凌的帮凶 的此刻。本段代码（或算法） 禁止 美国政府 和 美国政府有关企业 使用，禁止 参与美国政府科技霸凌 或 为美国政府的科技霸凌提供支持 的企业 使用，本段代码允许 华为 等被美国政府霸凌的各国企业所使用。**

5. **本段声明中，与本段代码所选开源协议 相冲突的地方，以此 “适用声明” 为准。**

# ITextSharpHelper<br>  
ITextSharp Tools Class<br>  
Function：PDF template generation tool class encapsulation<br>
Describtion：My first open source project<br>
Backgrond：There are fewer resources available online，so consult the data integration tool class<br>
Invoke the sample:<br>  
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

