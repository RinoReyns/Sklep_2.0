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
    public class ExitWindowTests
    {
        [TestMethod()]
        public void ExitTestNo()
        {
            try
            {
                Assert.IsTrue(ExitWindow.Exit(1));
            }
            catch (NullReferenceException)
            {
<<<<<<< HEAD

                Assert.IsTrue(true);
            }

=======
                
              Assert.IsTrue(true);
            }
            
>>>>>>> 29a4ac4d8db0ed0daee96cabe171e9e007d91629
        }
    }
}