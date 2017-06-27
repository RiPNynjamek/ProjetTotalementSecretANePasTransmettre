using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Model
{
    public class DecryptMessageResponse
    {
        public string Mail { get; set; }
        public string Key { get; set; }

        public DecryptMessageResponse()
        {

        }

        public DecryptMessageResponse(string mail, string key)
        {
            this.Mail = mail;
            this.Key = key;
        }
    }
}