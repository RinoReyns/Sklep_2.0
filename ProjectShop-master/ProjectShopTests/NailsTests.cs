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
    public class NailsTests
    {
        [TestMethod()]
        public void CountTestWithWarrenty()
        {
            var nails = new Nails();
            Assert.AreEqual(27.5, nails.Count(5, 1, true));
        }
        [TestMethod()]
        public void CountTestWithout()
        {
            var nails = new Nails();
            Assert.AreEqual(2.5, nails.Count(5, 1, false));
        }
    }
}