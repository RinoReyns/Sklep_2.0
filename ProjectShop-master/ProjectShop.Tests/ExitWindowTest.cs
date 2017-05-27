// <copyright file="ExitWindowTest.cs">Copyright ©  2016</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectShop;

namespace ProjectShop.Tests
{
    /// <summary>This class contains parameterized unit tests for ExitWindow</summary>
    [PexClass(typeof(ExitWindow))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class ExitWindowTest
    {
        /// <summary>Test stub for Exit(Int32)</summary>
        [PexMethod]
        public bool ExitTest(int i)
        {
            bool result = ExitWindow.Exit(i);
            return result;
            // TODO: add assertions to method ExitWindowTest.ExitTest(Int32)
        }
    }
}
