using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using WebService.Interfaces;

namespace WebService.Business
{
    public class DecryptXOR<T> : IDecryptJob<T>
    {
        public bool DoWork(List<T> objet)
        {
            return Decrypt(objet);
        }


        private bool Decrypt(List<T> objet)
        {
            /*
            var result = new StringBuilder();
            foreach (var item in objet)
            {
                for (int c = 0; c < item.ToString().Length; c++)
                {
                    result.Append((char)((uint)item.ToString() [c] ^ (uint)key[c % key.Length]));
                }
            }
            */
            // Once the file is decrypted, send it to the JMS and wait for a response
            try
            {
                new Communication<T>().Receive();
                new Communication<T>().Send("test");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
            
            return true;
        }
    }
}