using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebService.Service
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Decryption" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Decryption.svc ou Decryption.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Decryption : IDecryption
    {
        public CompositeTypeDecrypt Decrypt(string tokenUser, string tokenApi, List<byte[]> files)
        {
            var final = new CompositeTypeDecrypt();
            final.DecryptedFile = files[0];
            return final;
        }
    }
}
