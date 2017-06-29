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
        public static string InformationMessage;
        public static List<string> GetCurrentUsers()
        {
            List<string> users = new List<string>();
            string tokenUser = Authentication.TokenUser;
            string tokenApi = ConfigurationManager.AppSettings["appVersion"];
            InformationService.InformationClient client = new InformationService.InformationClient();
            try
            {
                users = client.GetCurrentUsers(tokenUser, tokenApi);
                return users;

            }
            catch (Exception)
            {
                InformationMessage = "Web service unavailable";
                return null;
            }
        }
    }
}
