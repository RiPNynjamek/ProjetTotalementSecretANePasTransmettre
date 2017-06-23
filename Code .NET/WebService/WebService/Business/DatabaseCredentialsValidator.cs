using System;
using System.Collections.Generic;
using System.Linq;
using WebService.Database;
using WebService.Interfaces;
using System.Web;

namespace WebService.Business
{
    public class DatabaseCredentialsValidator : ICredentialsValidator
    {
        private readonly UserTokenDBContext _DBContext;

        public DatabaseCredentialsValidator(UserTokenDBContext dbContext)
        {
            _DBContext = dbContext;
        }

        public bool IsValid(Model.Credentials creds)
        {
            var user = _DBContext.User.SingleOrDefault(u => u.Username.Equals(creds.Username, StringComparison.CurrentCultureIgnoreCase));
            var tokenApi = _DBContext.TokenApi.SingleOrDefault(t => t.TokenApi1.Equals(creds.TokenApi));
            return user != null && String.Equals(user.Password, creds.Password) && tokenApi != null;
        }
    }
}