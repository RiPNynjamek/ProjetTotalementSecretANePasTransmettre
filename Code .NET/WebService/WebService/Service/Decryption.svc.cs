using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebService.Database;
using WebService.Business;
using System.Diagnostics;
using System.Threading;
using Newtonsoft.Json;

namespace WebService.Service
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Decryption" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Decryption.svc ou Decryption.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Decryption : IDecryption
    {
        private readonly string path = "D:\\temp.txt";

        public CompositeTypeDecrypt Decrypt(string tokenUser, string tokenApi, List<byte[]> files)
        {
            #region Verification
            // Check Token User
            using (var dbContext = new UserTokenDBContext())
                if (!new DatabaseTokenValidator(dbContext).IsValid(tokenUser))
                    return new CompositeTypeDecrypt { IsDecrypted = false, InfoMessage = "User token invalid" };

            // Check number of files
            if (files.Count == 0)
                return new CompositeTypeDecrypt { IsDecrypted = false, InfoMessage = "No file selected" };

            #endregion

            var final = new CompositeTypeDecrypt();
            //List<string> filesString = ConvertFromByteArrayToString(files);
            List<string> filesString = ConvertBinaryToString(files);

            // Files decryption
            var decryption = new DecryptXOR<string>();
            final.IsDecrypted = decryption.DoWork(filesString);

            if(final.IsDecrypted)
            {
                var response = JsonConvert.DeserializeObject<Model.DecryptMessageResponse>(DecryptXOR<string>.FinalMessage);
                final.Email = response.Mail;
                final.Key = response.Key;
                final.Confidence = response.Confidence;
                // Send mail
                var userMail = new UserTokenDBContext().Token.Where(t => t.Token1.Equals(tokenUser)).Select(u => u.User.Mail).FirstOrDefault();
                Communication<string>.SendMail(userMail, "Subject", "The mail you are looking for is " + final.Email + "using the key : " + final.Key);
            }

            final.InfoMessage = decryption.InformationMessage;
            DecryptXOR<string>.IsDecrypted = false;
            return final;
        }

        private List<string> ConvertFromByteArrayToString(List<byte[]> files)
        {
            List<string> fileString = new List<string>();
            foreach (var item in files)
            {
                File.WriteAllBytes(path, item);
                string contents = File.ReadAllText(path, Encoding.GetEncoding("iso-8859-1"));
                fileString.Add(contents);
                File.Delete(path);
            }
            return fileString;
        }

        public List<string> ConvertBinaryToString(List<byte[]> files)
        {
            List<string> fileString = new List<string>();
            string myString;
            //string file = @"C:\Users\Adrien\Desktop\phase1_crypt\P1C.txt";

            foreach(var item in files)
            {
                myString = Convert.ToBase64String(item);
                fileString.Add(myString);
            }
            return fileString;
        }
    }
}
