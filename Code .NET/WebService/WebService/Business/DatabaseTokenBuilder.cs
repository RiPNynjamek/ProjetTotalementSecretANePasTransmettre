using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Interfaces;
using WebService.Database;
using System.Security.Cryptography;
using System.Security.Authentication;

namespace WebService.Business
{
    public class DatabaseTokenBuilder : ITokenBuilder
    {
        public static int TokenSize = 100;
        private readonly UserTokenDBContext _DBContext;

        public DatabaseTokenBuilder(UserTokenDBContext dbContext)
        {
            _DBContext = dbContext;
        }

        public string Build(Model.Credentials creds)
        {
            if (!new DatabaseCredentialsValidator(_DBContext).IsValid(creds))
            {
                throw new AuthenticationException();
            }
            var tokenByUser = _DBContext.Token.FirstOrDefault(u => u.User.Username.Equals(creds.Username));
            if (tokenByUser != null) return tokenByUser.Token1;

            var token = BuildSecureToken(TokenSize);
            var user = _DBContext.User.SingleOrDefault(u => u.Username.Equals(creds.Username, StringComparison.CurrentCultureIgnoreCase));
            _DBContext.Token.Add(new Token { Token1 = token, User = user, CreateTime = DateTime.Now });
            _DBContext.SaveChanges();
            return token;
        }

        private string BuildSecureToken(int length)
        {
            var buffer = new byte[length];
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                rngCryptoServiceProvider.GetNonZeroBytes(buffer);
            }
            return Convert.ToBase64String(buffer);
        }
    }
}