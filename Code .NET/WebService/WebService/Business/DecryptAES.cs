using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Interfaces;

namespace WebService.Business
{
    public class DecryptAES<T> : IDecryptJob<T>
    {
        public bool DoWork(List<T> objet)
        {
            return true;
        }
    }
}