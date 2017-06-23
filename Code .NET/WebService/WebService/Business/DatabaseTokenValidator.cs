using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Database;
using WebService.Interfaces;

namespace WebService.Business
{
    public class DatabaseTokenValidator : ITokenValidator
    {
        private readonly UserTokenDBContext _DBContext;

        public DatabaseTokenValidator(UserTokenDBContext dbContext)
        {
            _DBContext = dbContext;
        }

        public bool IsValid(string tokentext)
        {
            var token = _DBContext.Token.SingleOrDefault(t => t.Token1 == tokentext);
            return token != null;
        }
    }
}