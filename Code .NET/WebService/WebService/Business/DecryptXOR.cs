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
        public string InformationMessage;
        public static bool IsDecrypted = false;
        public static string FinalMessage;
        private readonly string REPORT_FILE_PATH = "D:\\fichier.pdf";
        public bool DoWork(List<T> objet)
        {
            return Decrypt(objet);
        }

        bool Decrypt(List<T> objet)
        {
            // Start listening for a response
            var com = new Communication<T>();
            com.Receive();

            #region JEE connection

            // We ask the JEE client to start listening to get the files
            WsGenJava.wsGenClient client = new WsGenJava.wsGenClient();
            try
            {
                client.receive();
            }
            catch (Exception e)
            {
                Logger.LogFile(e.GetType().ToString(), e.InnerException.Message, e.Message);
                InformationMessage = "Java web service not available";
                return false;
            }

            #endregion

            foreach (var item in objet)
            {
                EncryptDecryptWithoutKey(item.ToString());
            }

            //We wait for a response from JEE
            while(!IsDecrypted) {}

            // If we couldn't find any valid decrypted file
            if(String.IsNullOrEmpty(FinalMessage))
            {
                InformationMessage = "Decryption failed";
                return false;
            }

            InformationMessage = "Success! Check the results here : " + REPORT_FILE_PATH;
            return true;
        }

        #region Encryption and decryption

        // Decryption using brute force (6 alpha characters)
        public static bool EncryptDecryptWithoutKey(string input)
        {
            var result = new StringBuilder();
            char[] key = { 'a', 'a', 'a', 'a', 'a', 'a' };
            while (true)
            {
                if (IsDecrypted) break;
                for (int i = 0; i < input.Length; i++)
                {
                    if (IsDecrypted) break;
                    char charToInsert = input[i];
                    for (int j = 0; j < key.Length; j++)
                    {
                        if (IsDecrypted) break;
                        charToInsert = ((char)(charToInsert ^ key[j]));
                    }
                    result.Append(charToInsert);
                }
                SendMessage(result.ToString(), new string(key));
                key = IncrementKey(key);
                result.Clear();
                if (key == null) return false;
            }
            return true;
        }

        public static string EncryptDecryptWithKey(string input, string key)
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
            SendMessage(result.ToString(), new string(charKey));
            return result.ToString();
        }

        # endregion

        private static void SendMessage(string result, string key)
        {
            string message = JsonConvert.SerializeObject(new DecryptMessage(result, key));
            new Communication<T>().Send(message);
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