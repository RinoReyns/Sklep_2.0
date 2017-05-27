using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;

namespace ProjectShop
{
    /// <summary>
    /// Klasa odpowiedzialna za zapis danych użytkownika oraz końcowego zamówienia do pliku PDF.
    /// Klasa wykorzystuje zewnętrzną bibliotekę "itextsharp.dll".
    /// </summary>
    public static class PdfCreator
    {
        /// <summary>
        /// Konstruktor klasy odpowiedzialnej za zapis zamówienia do pliku PDF.
        /// </summary>
        /// <param name="T">Lista produktów wybranych przez użytkownika.</param>
        /// <param name="person">Dane użytkowniak do zamówienia.</param>
        public static void PDF_Creator(ObservableCollection<Product> T, Person person)
        {
           
              var control = new Control();
              var path = IfExistFile();


               var doc = new Document(PageSize.LETTER, 10, 10, 42, 35);
               var wri = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));

               var arial = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\arial.ttf", "iso-8859-2", BaseFont.EMBEDDED);
               var font = new Font(arial, 15f);
               var font2 = new Font(arial, 13f);

               doc.Open();
               const int row = 7;
               var table = new PdfPTable(row) {WidthPercentage = 100};

               var paragraph = new Paragraph(" Name: " + person.Name + "\n Surename: " + person.Surename + "\n Address: " 
                   + person.Address + "\n Telephone: " + person.Telephone + "\n",font2) { };
               paragraph.Alignment = 1;
               var paragraph2 = new Paragraph
                {
                    SpacingBefore = 10f,
                    SpacingAfter = 12f
                };
                var paragraph3 = new Paragraph(" Final Price: " + control.FinalPrice(T) + "$", font2);


                var cell0 = new PdfPCell(new Phrase("Order", font2));
                var cell1 = new PdfPCell(new Phrase("Product", font2));
                var cell2 = new PdfPCell(new Phrase("Quantity", font2));
                var cell3 = new PdfPCell(new Phrase("Price", font2));
                var cell4 = new PdfPCell(new Phrase("Color", font2));
                var cell5 = new PdfPCell(new Phrase("Producent", font2));
                var cell6 = new PdfPCell(new Phrase("Size", font2));
                var cell7 = new PdfPCell(new Phrase("Extra warrenty", font2));


               cell0.BackgroundColor = new BaseColor(0, 200, 0);
               cell0.Colspan = row;
               cell0.HorizontalAlignment = cell1.HorizontalAlignment = cell2.HorizontalAlignment = cell3.HorizontalAlignment = cell4.HorizontalAlignment 
                   = cell5.HorizontalAlignment = cell6.HorizontalAlignment = cell7.HorizontalAlignment = 1;

               table.AddCell(cell0);
               table.AddCell(cell1);
               table.AddCell(cell2);
               table.AddCell(cell3);
               table.AddCell(cell4);
               table.AddCell(cell5);
               table.AddCell(cell6);
               table.AddCell(cell7);


               foreach (var item in T)
               {
                   var cellT1 = new PdfPCell(new Phrase(item.Name,font2));
                   var cellT2 = new PdfPCell(new Phrase(item.Quantity.ToString(),font2));
                   var cellT3 = new PdfPCell(new Phrase(item.Price.ToString(),font2));
                   var cellT4 = new PdfPCell(new Phrase(item.Color,font2));
                   var cellT5 = new PdfPCell(new Phrase(item.Producent,font2));
                   var cellT6 = new PdfPCell(new Phrase(item.SizeItem,font2));
                   var cellT7 = new PdfPCell(new Phrase(item.WithWarrentyElementsCounter.ToString(),font2));


                   cellT1.HorizontalAlignment = cellT2.HorizontalAlignment = cellT3.HorizontalAlignment = cellT4.HorizontalAlignment = cellT5.HorizontalAlignment =
                   cellT6.HorizontalAlignment = cellT7.HorizontalAlignment = 1;

                   table.AddCell(cellT1);
                   table.AddCell(cellT2);
                   table.AddCell(cellT3);
                   table.AddCell(cellT4);
                   table.AddCell(cellT5);
                   table.AddCell(cellT6);
                   table.AddCell(cellT7);
               }

               doc.Add(paragraph);
               doc.Add(paragraph2);
               doc.Add(table);
               doc.Add(paragraph3);
               doc.Close();
               Process.Start(path);
           }
            
        private static string IfExistFile()
           {
               string path = "Order.pdf ";
               int numberOfOrder = 1;
               do
               {
                   if (File.Exists(path))
                   {
                       path = "Order" + numberOfOrder + ".pdf";
                       numberOfOrder++;
                   }
                   else
                       numberOfOrder = -1;
               }
               while (numberOfOrder != -1);
               return path;
        }
    }
}

