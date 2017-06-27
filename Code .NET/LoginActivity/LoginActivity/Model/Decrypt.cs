using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoginActivity.Model
{
    class Decrypt
    {
        public static string InformationMessage;

        public static bool Decrypter(List<string> files)
        {
            if (files == null)
            {
                InformationMessage = "No file selected";
                return false;
            }
            List<byte[]> filesBytes = new List<byte[]>();
            foreach (var item in files)
            {
                System.IO.FileStream dd = System.IO.File.OpenRead(item);
                byte[] Bytes = new byte[dd.Length];
                dd.Read(Bytes, 0, Bytes.Length);
                filesBytes.Add(Bytes);
            }
            string tokenApi = ConfigurationManager.AppSettings["appVersion"];
            string tokenUser = Authentication.tokenUser;

            DecryptionService.DecryptionClient client = new DecryptionService.DecryptionClient();
            try
            {
                var retour = client.Decrypt(tokenUser, tokenApi, filesBytes);
                InformationMessage = retour.InfoMessage;
                return retour.IsDecrypted;
            }
            catch
            {
                InformationMessage = "Web service unavailable";
                return false;
            }
        }
    }
}
