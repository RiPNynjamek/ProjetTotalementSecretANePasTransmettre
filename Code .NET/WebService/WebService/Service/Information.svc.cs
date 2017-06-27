using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.Entity;
using WebService.Database;
using WebService.Business;

namespace WebService.Service
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Information" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Information.svc ou Information.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Information : IInformation
    {
        private readonly int DefaultSecondsUntilTokenExpires = 300;
        public List<string> GetCurrentUsers(string tokenUser, string tokenApi)
        {
            // Check Token User
            using (var dbContext = new UserTokenDBContext())
                if (!new DatabaseTokenValidator(dbContext).IsValid(tokenUser))
                    return null;
            List<string> currentUsers = new List<string>();
            using (var dbContext = new UserTokenDBContext())
            {
                var validator = new Business.DatabaseTokenValidator(dbContext);
                currentUsers = dbContext.Token.Where(t => DbFunctions.DiffSeconds(t.CreateTime, DateTime.Now) < DefaultSecondsUntilTokenExpires).Select(t => t.User.Username).ToList();
            }
            return currentUsers;
        }
    }
}
