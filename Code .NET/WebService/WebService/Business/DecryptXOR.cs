using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using WebService.Interfaces;
using WebService.Model;

namespace WebService.Business
{
    public class DecryptXOR<T> : IDecryptJob<T>
    {
        public bool DoWork(List<T> objet)
        {
            return Decrypt(objet);
        }


        bool Decrypt(List<T> objet)
        {
            var com = new Communication<T>();
            com.Receive();
            foreach (var item in objet)
            {
                EncryptDecryptWithoutKey(item.ToString());
            }
            // TODO: get the result from JMS before returning true
            return true;
        }

        private static bool EncryptDecryptWithoutKey(string input)
        {
            var result = new StringBuilder();
            char[] key = { 'a', 'a', 'a', 'a', 'a', 'a' };
            while(true)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    char charToInsert = input[i];
                    for (int j = 0; j < key.Length; j++)
                    {
                        charToInsert = ((char)(charToInsert ^ key[j]));
                    }
                    result.Append(charToInsert);
                }
                SendMessage(result.ToString(), new string(key));
                key = IncrementKey(key);
                if(key == null) break;
            }
            return true;
        }

        private static void SendMessage(string result, string key)
        {
            string message = JsonConvert.SerializeObject(new Model.DecryptMessage(result, key));
            new Communication<T>().Send(message);
        }

        private static bool EncryptDecryptWithKey(string input, string key)
        {
            var result = new StringBuilder();
            char[] charKey = key.ToCharArray();

            Debug.WriteLine("Start string : " + input);
            for (int i = 0; i < input.Length; i++)
            {
                char charToInsert = input[i];
                for (int j = 0; j < charKey.Length; j++)
                {
                    charToInsert = ((char)(charToInsert ^ charKey[j]));
                }
                result.Append(charToInsert);
            }
            Debug.WriteLine("Final string : " + result);
            new Communication<T>().Send(result.ToString());
            return true;
        }

        private static char[] IncrementKey(char[] key)
        {
            if (key[5] == 'z')
            {
                if (key[4] == 'z')
                {
                    if (key[3] == 'z')
                    {
                        if (key[2] == 'z')
                        {
                            if (key[1] == 'z')
                            {
                                if (key[0] == 'z')
                                {
                                    return null;
                                }
                                else
                                {
                                    key[0]++;
                                    key[1] = 'a';
                                    key[2] = 'a';
                                    key[3] = 'a';
                                    key[4] = 'a';
                                    key[5] = 'a';
                                }
                            }
                            else
                            {
                                key[1]++;
                                key[2] = 'a';
                                key[3] = 'a';
                                key[4] = 'a';
                                key[5] = 'a';
                            }
                        }
                        else
                        {
                            key[2]++;
                            key[3] = 'a';
                            key[4] = 'a';
                            key[5] = 'a';
                        }
                    }
                    else
                    {
                        key[3]++;
                        key[4] = 'a';
                        key[5] = 'a';
                    }
                }
                else
                {
                    key[4]++;
                    key[5] = 'a';
                }
            }
            else
            {
                key[5]++;
            }

            return key;
        }
    }
}