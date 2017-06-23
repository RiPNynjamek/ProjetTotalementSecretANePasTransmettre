using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Interfaces
{
    public interface ITokenValidator
    {
        bool IsValid(string token);
    }
}
