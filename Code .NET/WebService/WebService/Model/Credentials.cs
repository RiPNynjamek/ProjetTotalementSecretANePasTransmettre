using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Model
{
    public class Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string TokenApi { get; set; }

        public Credentials()
        {

        }

        public Credentials(string username, string password, string tokenApi)
        {
            this.Username = username;
            this.Password = password;
            this.TokenApi = tokenApi;
        }
    }
}