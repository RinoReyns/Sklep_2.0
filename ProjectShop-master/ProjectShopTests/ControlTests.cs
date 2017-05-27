using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectShop;

namespace ProjectShop.Tests
{
    [TestClass()]
    public class ControlTests
    {
        [TestMethod()]
        public void CheckIfIsOnTheListByName()
        {
            var control = new Control();
            Assert.AreEqual(1, control.Check(new List<Product> { new Boot(), new Cd(), new Amp() }, "Amp"));
        }
        [TestMethod()]
        public void CheckIfIsNotOnTheListByName()
        {
            var control = new Control();
            Assert.AreEqual(0, control.Check(new List<Product> { new Boot(), new Nails(), new Amp() }, "Table"));
        }
        [TestMethod()]
        public void CheckIfIsOnTheListByMoreParameters()
        {
            var control = new Control();
            var testProduct = new Nails
            {
                Color = "Pink",
                SizeItem = "1mm"
            };
            Assert.AreNotEqual(-1, control.Check(new ObservableCollection<Product>() { new Micro(), new Nails(), new Door(), testProduct },
                                                "Nails", "Pink", "1mm"));
        }
        [TestMethod()]
        public void CheckIfIsNotOnTheListByMoreParameters()
        {
            var control = new Control();
            var testProduct = new Nails
            {
                Color = "Blue",
                SizeItem = "1mm"
            };
            Assert.AreEqual(-1, control.Check(new ObservableCollection<Product>() { new Guitar(), new Nails(), new Shoes(), testProduct },
                                                "Nails", "Pink", "1mm"));
        }

        [TestMethod()]
        public void FinalPriceTestIfEqual()
        {
            var control = new Control();
            Assert.AreEqual("51",control.FinalPrice(new ObservableCollection<Product>() { new Micro(), new Nails(), new Shoes()}));
        }

        [TestMethod()]
        public void FinalPriceTestIfNotEqual()
        {
            var control = new Control();
            Assert.AreNotEqual("54", control.FinalPrice(new ObservableCollection<Product>() { new Table(), new Dress(), new Shoes() }));
        }
    }
}

