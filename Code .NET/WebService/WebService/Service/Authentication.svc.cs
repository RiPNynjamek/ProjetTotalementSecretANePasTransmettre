using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebService.Business;
using WebService.Database;
using WebService.Interfaces;
using WebService.Model;

namespace WebService.Service
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Authentication" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Authentication.svc ou Authentication.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Authentication : IAuthentication
    {
        public CompositeTypeAuthenticate Authenticate(string username, string password, string tokenApi)
        {
            var final = new CompositeTypeAuthenticate();
            Credentials creds = new Credentials(username, password, tokenApi);
            //Check in DB if user is valid
            using (var dbContext = new UserTokenDBContext())
            {
                ICredentialsValidator validator = new DatabaseCredentialsValidator(dbContext);
                if (validator.IsValid(creds))
                {
                    final.IsAuthentified = true;
                    final.TokenUser = new DatabaseTokenBuilder(dbContext).Build(creds);
                }
                else
                {
                    final.IsAuthentified = false;
                    //throw new InvalidCredentialException("Invalid credentials");
                }
            }
            return final;
        }
    }
}
