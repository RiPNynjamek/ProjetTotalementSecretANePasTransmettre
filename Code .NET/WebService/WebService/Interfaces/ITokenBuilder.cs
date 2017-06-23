using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Model;

namespace WebService.Interfaces
{
    interface ITokenBuilder
    {
        string Build(Credentials creds);
    }
}
