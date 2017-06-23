using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginActivity.Model
{
    class Authentication
    {
        public static bool Authenticate(string Username, string Password)
        {
            string tokenApi = ConfigurationManager.AppSettings["appVersion"];
            AuthenticationService.AuthenticationClient client = new AuthenticationService.AuthenticationClient();
            var user = client.Authenticate(Username, Password, tokenApi);
            return user.IsAuthentified;
        }
    }
}
