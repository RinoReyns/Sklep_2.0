using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectShop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectShop.Tests
{
    [TestClass()]
    public class PdfCreatorTests
    {
        [TestMethod()]
        public void PDF_CreatorTest()
        {
            try
            {
               PdfCreator.PDF_Creator(new ObservableCollection<Product>() { new Guitar(), new Nails(), new Shoes()},
                   new Person
                   {
                       Name = "Tadek",
                       Surename = "Kowal",
                       Address = "Malta 2/30",
                       Telephone = "888999000"
                   });
            }
            catch (Exception)
            {

                Assert.Fail();
            }
        }
    }
}