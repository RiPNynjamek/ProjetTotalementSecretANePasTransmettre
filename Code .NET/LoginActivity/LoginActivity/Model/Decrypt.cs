﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginActivity.Model
{
    class Decrypt
    {
        public static bool Decrypter(List<string> files)
        {
            if (files == null) return false;
            List<byte[]> filesBytes = new List<byte[]>();
            foreach (var item in files)
            {
                System.IO.FileStream dd = System.IO.File.OpenRead(item);
                byte[] Bytes = new byte[dd.Length];
                dd.Read(Bytes, 0, Bytes.Length);
                filesBytes.Add(Bytes);
            }
            string tokenApi = ConfigurationManager.AppSettings["appVersion"];
            string tokenUser = Authentication.tokenUser;
            DecryptionService.DecryptionClient client = new DecryptionService.DecryptionClient();
            Debug.WriteLine("Fichier 1 size : " + filesBytes[0].Length);
            var retour = client.Decrypt(tokenUser, tokenApi, filesBytes);
            Debug.WriteLine("Fichier retour size : " + retour.DecryptedFile.Length);
            return true;
        }
    }
}
