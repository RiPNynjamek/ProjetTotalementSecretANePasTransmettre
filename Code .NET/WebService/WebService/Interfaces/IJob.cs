using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Interfaces
{
    interface IJob<T>
    {
        bool DoWork(List<T> objet);
    }
}
