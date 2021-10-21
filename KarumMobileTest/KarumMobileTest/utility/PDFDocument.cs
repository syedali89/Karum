using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using System.IO;

namespace utility
{
    public class PDFDocument 
    {
        public static string readDocument(string path) 
        {
            string documentString = string.Empty;

            PdfDocument document = new PdfDocument(new PdfReader(path));

            for (int i = 1; i <= document.GetNumberOfPages(); i++)
            {
                documentString += PdfTextExtractor.GetTextFromPage(document.GetPage(i));
            }
            document.Close();
            return documentString;
        }
    }
}