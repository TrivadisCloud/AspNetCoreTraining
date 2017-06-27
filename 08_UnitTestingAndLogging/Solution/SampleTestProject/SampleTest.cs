using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingAndLogging.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace SampleTestProject
{
    [TestClass]
    public class SampleTest
    {
        [TestMethod]
        public void HomeControllerIndexTest()
        {
            var controller = new HomeController();
            var result = controller.Index();
            Assert.IsTrue(result is IActionResult);

        }
    }
}
