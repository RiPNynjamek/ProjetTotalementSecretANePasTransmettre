using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginActivity.Businness
{
    static class FileCreation
    {
        public static void CreatePDF(string path, string textToWrite)
        {
            Document document = new Document();
            try
            {
                PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
                document.Open();
                document.Add(new Phrase(textToWrite));
                document.Close();
            }
            catch (Exception e)
            {

            }
        }
    }
}
