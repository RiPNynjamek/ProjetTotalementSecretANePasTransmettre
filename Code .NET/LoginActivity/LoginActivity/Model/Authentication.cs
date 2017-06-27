﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginActivity.Model
{
    class Authentication
    {

        public static string tokenUser;
        public static string InformationMessage;
        public static bool Authenticate(string Username, string Password)
        {
            string tokenApi = ConfigurationManager.AppSettings["appVersion"];
            AuthenticationService.AuthenticationClient client = new AuthenticationService.AuthenticationClient();
            try
            {
                var user = client.Authenticate(Username, Password, tokenApi);
                tokenUser = user.TokenUser;
                if (!user.IsAuthentified) InformationMessage = "Invalid credentials";
                return user.IsAuthentified;
            }
            catch
            {
                InformationMessage = "Web service unavailable";
                return false;
            }
        }
    }
}
