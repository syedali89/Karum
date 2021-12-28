namespace utility
{
    using data;
    using Newtonsoft.Json;
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.IO.Compression;
    using System.Text;
    using System.Text.RegularExpressions;
    using static constants;

    public class DataRecover 
    {
        private static By PATHEMAILONPAGE = By.CssSelector("table.jambo_table tr");
        private static By WAITJUSTNOWEMAIL = By.XPath("//table[@class='table-striped jambo_table']//tr//td[contains(text(), 'just now')]");
        public static string localpath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", ".."));

        public static Client RecoverClientData() 
        {
            return RecoverClientData("clientDefaultData.json");            
        }

        public static Client RecoverClientData(string file)
        {
            string docFile = RecoverJsonFilePath(file);

            Client client;

            using (StreamReader r = new StreamReader(docFile, Encoding.UTF8))
            {
                string json = r.ReadToEnd().Replace("M�", "Mé").Replace("ci�n", "ción");
                var setting = new JsonSerializerSettings();
                client = JsonConvert.DeserializeObject<Client>(json);
            } 

            return client;
        }

        public static EnvData RecoverEnviromentData(string file)
        {
            string docFile = RecoverJsonFilePath(file);

            EnvData data;

            using (StreamReader r = new StreamReader(docFile))
            {
                string json = r.ReadToEnd();
                data = JsonConvert.DeserializeObject<EnvData>(json);
            }

            return data;
        }        

        public static string RecoverJsonFilePath(string file)
        { 
            return Path.GetFullPath(Path.Combine(
                localpath, JSON_FOLDER, file));
        }

        [Obsolete]
        public static string RecoverSecurityCode() 
        {
            string securityCode = string.Empty;
            string dateReturn = string.Empty;

            #region Use the WebScrap Object for recover the Code from the email inbox OBSOLETE         
            DriverChrome webScrap = new DriverChrome();
            try 
            {
                webScrap.waitElementExist(EMAILINBOX, WAITJUSTNOWEMAIL);

                string emailUrl = webScrap.RecoverDataElementPage(
                        EMAILINBOX, PATHEMAILONPAGE, "id");

                emailUrl = EMAILPATH + emailUrl.Substring(4);
                dateReturn = webScrap.RecoverDataElementPage(
                        emailUrl, By.CssSelector("body"), string.Empty, "html_msg_body");

                webScrap.KillSession();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                webScrap.KillSession();
            }
            #endregion

            #region Use Regex to extract the 6 digit number code from all the text recover
            Regex rx = new Regex("(\\d{6})");

            MatchCollection matcher = rx.Matches(dateReturn);
            
            if (matcher.Count > 0) 
            {
                securityCode = matcher[0].Value;
            }
            return securityCode;
            #endregion
        }
        
        public static string RecoverSecurityCode(Driver data, Client client) 
        {
            string securityCode = string.Empty;
            string dateReturn = string.Empty;

            #region Use ChromeDriver to enter Gmail and Recover Security Code
            GmailWebPage gmailPage = null;
            try
            {
                gmailPage = new GmailWebPage(new DriverChrome(), client);
                gmailPage.LogINGmail(data.GetUserName(), data.GetUserPass());
                dateReturn = gmailPage.GetMailMessage();
                gmailPage.driver.KillSession();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (gmailPage.driver != null)
                {
                    gmailPage.driver.KillSession();
                }
            }   
            #endregion
            #region Use Regex to extract the 6 digit number code from all the text recover
            Regex rx = new Regex("(\\d{6})");

            MatchCollection matcher = rx.Matches(dateReturn);
            
            if (matcher.Count > 0) 
            {
                securityCode = matcher[0].Value;
            }
            return securityCode;
            #endregion
        }

        public static string AvisoPrivacidadDocument() 
        {
            string docFile = Path.GetFullPath(Path.Combine(
                localpath, DOCUMENTS_FOLDER, AVISOPRIVACIDAD_DOCUMENT));
            return PDFDocument.readDocument(docFile);
        }
        /// <summary>
        /// Recover files from a specific Device folder. ONLY IMPLEMENT ON LOCAL
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="folderpath"></param>
        /// <returns></returns>
        public static List<string> RecoverFolderFilesNames(Driver driver, string folderpath) 
        {
            var Listfilesnames = new List<string>();
            byte[] downloadFolder = null;

            downloadFolder = driver.GetIntance().PullFolder(folderpath);
            
            File.WriteAllBytes("zipfile", downloadFolder);

            using (ZipArchive zip = ZipFile.Open("zipfile", ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in zip.Entries)
                {
                    Listfilesnames.Add(entry.Name);
                }
            }

            return Listfilesnames;
        }

        public static void RecoverTableExcelData(string pathExcel)
        {

            

        }
    }
}