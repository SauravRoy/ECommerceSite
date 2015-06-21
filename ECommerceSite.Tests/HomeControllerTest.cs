using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ECommerceSite.Controllers;
using Moq;
using CommonUtils;
using System.Web.Mvc;

namespace ECommerceSite.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestDetailsView()
        {

            // Using MOQ for Mocking Dependencies .
            var _logger = new Mock<ILogger>();
            var _mail = new Mock<IMail>();

            var controller = new HomeController(_logger.Object, _mail.Object);
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);

        }
    }
}
