using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Model
{
    public class DecryptMessage
    {
        public string Message { get; set; }
        public string Key { get; set; }

        public DecryptMessage()
        {

        }

        public DecryptMessage(string message, string key)
        {
            this.Message = message;
            this.Key = key;
        }
    }
}