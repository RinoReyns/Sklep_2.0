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
               var font2 = new Font(arial, 13f);

               doc.Open();
               const int row = 7;
               var table = new PdfPTable(row) {WidthPercentage = 100};

               var paragraph =
                    new Paragraph(" Name: " + person.Name + "\n Surename: " + person.Surename + "\n Address: "
                              + person.Address + "\n Telephone: " + person.Telephone + "\n", font2) {Alignment = 1};
               var paragraph2 = new Paragraph
                {
                    SpacingBefore = 10f,
                    SpacingAfter = 12f
                };
                var paragraph3 = new Paragraph(" Final Price: " + control.FinalPrice(T) + "$", font2);

               table.AddCell(new PdfPCell
               {
                   Phrase = new Phrase("Order", font2),
                   BackgroundColor = new BaseColor(0, 200, 0),
                   Colspan = row,
                   HorizontalAlignment = 1
               });

               table.AddCell(new PdfPCell
               {
                   Phrase = new Phrase("Product", font2),
                   HorizontalAlignment = 1
               });

               table.AddCell(new PdfPCell
               {
                   Phrase = new Phrase("Quantity", font2),
                   HorizontalAlignment = 1
               });
               table.AddCell(new PdfPCell
               {
                   Phrase = new Phrase("Price", font2),
                   HorizontalAlignment = 1

               });
               table.AddCell( new PdfPCell
               {
                   Phrase = new Phrase("Color", font2),
                   HorizontalAlignment = 1
               });
               table.AddCell(new PdfPCell
               {
                   Phrase = new Phrase("Producent", font2),
                   HorizontalAlignment = 1
               });
               table.AddCell(new PdfPCell
               {
                   Phrase = new Phrase("Size", font2),
                   HorizontalAlignment = 1
               });
               table.AddCell( new PdfPCell
               {
                   Phrase = new Phrase("Extra warrenty", font2),
                   HorizontalAlignment = 1
               });


               foreach (var item in T)
               {
                   table.AddCell(new PdfPCell
                   {
                       Phrase = new Phrase(item.Name, font2),
                       HorizontalAlignment = 1
                   });
                   table.AddCell(new PdfPCell
                   {
                       Phrase = new Phrase(item.Quantity.ToString(), font2),
                       HorizontalAlignment = 1
                   });
                   table.AddCell(new PdfPCell
                   {
                       Phrase = new Phrase(item.Price.ToString(), font2),
                       HorizontalAlignment = 1
                   });
                   table.AddCell(new PdfPCell
                   {
                       Phrase = new Phrase(item.Color, font2),
                       HorizontalAlignment = 1
                   });
                   table.AddCell(new PdfPCell
                   {
                       Phrase = new Phrase(item.Producent, font2),
                       HorizontalAlignment = 1
                   });
                   table.AddCell(new PdfPCell
                   {
                       Phrase = new Phrase(item.SizeItem, font2),
                       HorizontalAlignment = 1
                   });
                   table.AddCell(new PdfPCell
                   {
                       Phrase = new Phrase(item.WithWarrentyElementsCounter.ToString(), font2),
                       HorizontalAlignment = 1
                   });
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
               var path = "Order.pdf ";
               var numberOfOrder = 1;
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

