using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Interfaces
{
    interface ICommunicateJob<T> : IJob<T>
    {
        void Send(string message);
        void Receive();
    }
}
