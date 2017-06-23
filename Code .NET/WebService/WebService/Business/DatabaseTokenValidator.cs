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
        // Todo: Set this from a web.config appSettting value
        public static double DefaultSecondsUntilTokenExpires = 1800;

        private readonly UserTokenDBContext _DBContext;

        public DatabaseTokenValidator(UserTokenDBContext dbContext)
        {
            _DBContext = dbContext;
        }

        public bool IsValid(string tokentext)
        {
            var token = _DBContext.Token.SingleOrDefault(t => t.Token1 == tokentext);
            return token != null && !IsExpired(token);
        }

        internal bool IsExpired(Token token)
        {
            var span = DateTime.Now - token.CreateTime;
            return span.TotalSeconds > DefaultSecondsUntilTokenExpires;
        }
    }
}