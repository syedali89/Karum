namespace utility
{
    using iText.Kernel.Pdf;
    using iText.Kernel.Pdf.Canvas.Parser;

    public class PDFDocument 
    {
        /// <summary>
        /// Read a entire PDF file and return all the text from there
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Text from the PDF file</returns>
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