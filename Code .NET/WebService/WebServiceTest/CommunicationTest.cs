using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebServiceTest
{
    [TestClass]
    public class CommunicationTest
    {
        [TestMethod]
        public void SendMailTest()
        {
            Assert.IsTrue(WebService.Business.Communication<string>.SendMail("antoine.delia@viacesi.fr", "Test", "message"));
        }
    }
}
