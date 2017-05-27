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
<<<<<<< HEAD
            Assert.AreEqual(27.5, nails.Count(5, 1, true));
=======
            Assert.AreEqual( 27.5 ,nails.Count(5, 1, true)); 
>>>>>>> 29a4ac4d8db0ed0daee96cabe171e9e007d91629
        }
        [TestMethod()]
        public void CountTestWithout()
        {
            var nails = new Nails();
            Assert.AreEqual(2.5, nails.Count(5, 1, false));
        }
    }
}