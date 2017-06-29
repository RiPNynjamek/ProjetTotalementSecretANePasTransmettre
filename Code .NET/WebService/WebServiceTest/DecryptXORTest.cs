using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace WebServiceTest
{
    [TestClass]
    public class DecryptXORTest
    {
        [TestMethod]
        public void EncryptDecryptWithKeyTest()
        {
            string debut = "Je suis une maison et je prends mon avion dans une heure. Contactez moi à cette adresse : antoine.1996.31@gmail.com merci beaucoup !";
            string key = "aaaayz";
            string intermediaire = WebService.Business.DecryptXOR<string>.EncryptDecryptWithKey(debut, key);
            Assert.AreEqual(debut, WebService.Business.DecryptXOR<string>.EncryptDecryptWithKey(intermediaire, key));
        }

        [TestMethod]
        public void BinaryToText()
        {
            byte[] fileBytes = File.ReadAllBytes("D:\\P1E.txt");
            StringBuilder sb = new StringBuilder();

            foreach (byte b in fileBytes)
            {
                sb.Append(b.ToString("X2"));
            }

            File.WriteAllText("D:\\yolo.txt", sb.ToString());

        }

        public Byte[] GetBytesFromBinaryString(String binary)
        {
            var list = new List<Byte>();

            for (int i = 0; i < binary.Length; i += 8)
            {
                String t = binary.Substring(i, 8);

                list.Add(Convert.ToByte(t, 2));
            }

            return list.ToArray();
        }
    }
}
