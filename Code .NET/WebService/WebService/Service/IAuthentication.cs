using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebService.Service
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IAuthentication" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IAuthentication
    {
        [OperationContract]
        CompositeTypeAuthenticate Authenticate(string username, string password, string tokenApi);

    }

    [DataContract]
    public class CompositeTypeAuthenticate
    {
        bool isAuthentified = false;
        string tokenUser = "";

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
