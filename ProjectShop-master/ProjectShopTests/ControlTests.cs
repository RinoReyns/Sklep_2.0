using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectShop;

namespace ProjectShop.Tests
{
    [TestClass()]
    public class ControlTests
    {
        [TestMethod()]
        public void CheckIfIsOnTheList()
        {
            Control control = new Control();
            var productList = new List<Product> { new Boot(), new Cd(), new Amp() };
            var state = control.Check(productList, "Amp");
            Assert.AreEqual(1, state);
        }
        [TestMethod()]
        public void CheckIfIsNotOnTheList()
        {
            Control control = new Control();
            var productList = new List<Product> { new Boot(), new Cd(), new Amp() };
            var state = control.Check(productList, "Table");
            Assert.AreEqual(0, state);
        }


    }
}

