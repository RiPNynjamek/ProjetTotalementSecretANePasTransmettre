using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebService.Business
{
    public static class Logger
    {
        private static readonly string path = "D:\\logfile.txt";
        public static void LogFile(string exceptionType, string innerExceptionMessage, string message)
        {
            StreamWriter log;
            if (!File.Exists(path))
            {
                log = new StreamWriter(path);
            }
            else
            {
                log = File.AppendText(path);
            }

            // Write to the file:
            log.WriteLine("Data Time : " + DateTime.Now);
            log.WriteLine("Exception Type : " + exceptionType);
            log.WriteLine("Inner exception message : " + innerExceptionMessage);
            log.WriteLine("Message : " + message);
            log.WriteLine("");

            // Close the stream:
            log.Close();
        }
    }
}