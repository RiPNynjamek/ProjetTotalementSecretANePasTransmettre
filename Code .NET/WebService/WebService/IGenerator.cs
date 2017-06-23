using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IGenerator" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IGenerator
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        CompositeTypeAuthenticate Authenticate(string username, string password, string tokenApi);
    }

    [DataContract]
    public class CompositeTypeAuthenticate
    {
        bool isAuthentified = true;
        string tokenUser = "Hello ";

        [DataMember]
        public bool IsAuthentified
        {
            get { return isAuthentified; }
            set { isAuthentified = value; }
        }

        [DataMember]
        public string TokenUser
        {
            get { return tokenUser; }
            set { tokenUser = value; }
        }
    }
}
