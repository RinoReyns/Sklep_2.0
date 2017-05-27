using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectShop.Tests
{
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        public void CountTestWithWarrenty()
        {
            var testProduct = new Boot();
            Assert.AreEqual(550,testProduct.Count(5,testProduct.Price,true));
        }
        [TestMethod()]
        public void CountTestWithoutWarrenty()
        {
            var testProduct = new Boot();
            Assert.AreEqual(500, testProduct.Count(5, testProduct.Price, false));
        }
    }
}