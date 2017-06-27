using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginActivity.Model
{
    class Information
    {
        public static List<string> GetCurrentUsers()
        {
            List<string> users = new List<string>();
            string tokenUser = Authentication.TokenUser;
            string tokenApi = ConfigurationManager.AppSettings["appVersion"];
            InformationService.InformationClient client = new InformationService.InformationClient();
            users = client.GetCurrentUsers(tokenUser, tokenApi);
            return users;
        }
    }
}
