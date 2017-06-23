using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Model;

namespace WebService.Interfaces
{
    public interface ICredentialsValidator
    {
        bool IsValid(Credentials creds);
    }
}
