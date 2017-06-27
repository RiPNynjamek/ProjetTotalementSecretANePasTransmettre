using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebServiceTest
{
    [TestClass]
    public class DecryptXORTest
    {
        [TestMethod]
        public void EncryptDecryptWithKeyTest()
        {
            string debut = "antoine";
            string key = "delias";
            string intermediaire = WebService.Business.DecryptXOR<string>.EncryptDecryptWithKey(debut, key);
            Assert.AreEqual(debut, WebService.Business.DecryptXOR<string>.EncryptDecryptWithKey(intermediaire, key));
        }
    }
}
