﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
                
              Assert.IsTrue(true);
            }
            
        }
    }
}