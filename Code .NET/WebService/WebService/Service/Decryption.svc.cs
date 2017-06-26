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

namespace WebService.Service
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Decryption" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Decryption.svc ou Decryption.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Decryption : IDecryption
    {
        private readonly string path = "D:\\temp.txt";

        public CompositeTypeDecrypt Decrypt(string tokenUser, string tokenApi, List<byte[]> files)
        {
            // Check Token User
            using (var dbContext = new UserTokenDBContext())
                if(!new DatabaseTokenValidator(dbContext).IsValid(tokenUser))
                    return new CompositeTypeDecrypt { IsDecrypted = false, InfoMessage = "User token invalid"};

            // Check number of files
            if (files.Count == 0)
                return new CompositeTypeDecrypt { IsDecrypted = false, InfoMessage = "No file selected" };

            var final = new CompositeTypeDecrypt();
            List<string> filesString = ConvertFromByteArrayToString(files);

            // Decrypt string files
            final.IsDecrypted = new DecryptXOR<string>().DoWork(filesString);

            // If the message is decrypted, return trues
            final.InfoMessage = "File decrypted successfully!";
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
    }
}
