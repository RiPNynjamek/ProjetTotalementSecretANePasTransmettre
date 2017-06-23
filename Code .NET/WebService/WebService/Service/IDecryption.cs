using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebService.Service
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IDecryption" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IDecryption
    {
        [OperationContract]
        CompositeTypeDecrypt Decrypt(string tokenUser, string tokenApi, List<byte[]> files);
    }

    [DataContract]
    public class CompositeTypeDecrypt
    {
        bool isDecrypted = false;
        byte[] decryptedFile = null;
        string key = "";
        byte[] reportFile = null;
        string email = "";

        [DataMember]
        public bool IsDecrypted
        {
            get { return isDecrypted; }
            set { isDecrypted = value; }
        }

        [DataMember]
        public byte[] DecryptedFile
        {
            get { return decryptedFile; }
            set { decryptedFile = value; }
        }

        [DataMember]
        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        [DataMember]
        public byte[] ReportFile
        {
            get { return reportFile; }
            set { reportFile = value; }
        }

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}
