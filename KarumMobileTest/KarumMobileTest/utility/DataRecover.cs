namespace utility
{
    using System;    
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Text.RegularExpressions;
    using static constants;
    using data;
    using Newtonsoft.Json;
    using OpenQA.Selenium;
    using System.Text;
    using System.Globalization;

    public class DataRecover 
    {
        private const string EMAILINBOX =
            "https://www.mailinator.com/v4/public/inboxes.jsp?to=codigomovil";
        private const string EMAILPATH =
                "https://www.mailinator.com/v4/public/inboxes.jsp?msgid=";
        private static By PATHEMAILONPAGE = By.CssSelector("table.jambo_table tr");
        private static By WAITJUSTNOWEMAIL = By.XPath("//table[@class='table-striped jambo_table']//tr//td[contains(text(), 'just now')]");
        private const string AVISOPRIVACIDAD_DOCUMENT =
                "AVISO DE PRIVACIDAD (22sep2021).pdf";

        public static string localpath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", ".."));

        public static Client RecoverClientData() 
        {
            return RecoverClientData("clientDefaultData.json");

            /** TODO Delete this code after verify that read json work
            Client client = new Client();
            client.AddressStreet = "Some Street";
            client.AddressExtNum = "1234";
            client.AddressIntNum = "1234";
            client.AddressCity =  "Ciudad de México";
            client.AddressSubUrb = "Piedad Narvarte";
            client.AddressZipCode = "03000";
            client.Email = "some@email.com";
            client.PhoneNumber = "3327885614";
            //client.firstNameOne = "Antonio";
            client.firstNameOne = "Jose";
            client.firstNameTwo = "Servando";
            //client.lastNameOne = "Lopez";
            client.lastNameOne = "Sanchez";
            client.lastNameTwo = "Rodea";
            client.birthDate = "22/03/1974";
            client.gender = "Masculino";
            client.CURP = "LORA740322HDFPDN00";
            client.jobCompany = "Karum";
            client.CompanyPhoneNumber = "1234567890";

            //client.userName = "spring2_u1@gmail.com";
            client.userEmail = "spring2_u1@gmail.com";
            client.userPass = "temporal#dev";
            client.userPhone = "3327885614";
            client.estadoCuentaPass = "0030";

            //client.accountAmount = "$14,277.13";
            client.accountAmount = "$17,295.70";
            client.creditNumber = "************5168";

            client.newChargesAmount = "$0.00";
            client.paymentCreditAmount = "$0.00";
            client.monthlyAmount = "$1,200.00";
            client.availableCreditAmount = "$0.00";
            client.overdueAmount = "$0.00";
            client.totalAmount = "$0.00";

            client.creditLimitAmount = "$2,500.00";
            client.paymentAmount = "$1,200.00";
            client.totalLoyalPoints = "0";

            client.clientMovimientos.Add(new Movimiento("93054", "Devolución IVA", "$7,777.88"));
            client.clientMovimientos.Add(new Movimiento("93054", "IVA", "-$4,677.88"));
            client.clientMovimientos.Add(new Movimiento("93054", "Compra", "$2,334.44"));
            client.clientMovimientos.Add(new Movimiento("93054", "Abono", "-$5,551.33"));
            client.clientMovimientos.Add(new Movimiento("93054", "Compra", "$4,880.00"));
            client.clientMovimientos.Add(new Movimiento("93054", "Compra", "$4,660.22"));
            client.clientMovimientos.Add(new Movimiento("93054", "Compra", "$3,333.33"));
            client.clientMovimientos.Add(new Movimiento("93054", "Compra", "$4,455.22"));
            client.clientMovimientos.Add(new Movimiento("93054", "Compra", "$5,770.01"));
            client.clientMovimientos.Add(new Movimiento("93054", "Abono", "-$250.00"));

            return client;*/
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

        public static EnvironmentData RecoverEnviromentData(string file)
        {
            string docFile = RecoverJsonFilePath(file);

            EnvironmentData data;

            using (StreamReader r = new StreamReader(docFile))
            {
                string json = r.ReadToEnd();
                data = JsonConvert.DeserializeObject<EnvironmentData>(json);
            }

            return data;
        }        

        public static string RecoverJsonFilePath(string file)
        { 
            return Path.GetFullPath(Path.Combine(
                localpath, JSON_FOLDER, file));
        }

        public static string RecoverSecurityCode() 
        {
            string securityCode = string.Empty;
            string dateReturn = string.Empty;

            WebScrap webScrap = new WebScrap();
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

            //Regex to extract the code
            Regex rx = new Regex("(\\d{6})");

            MatchCollection matcher = rx.Matches(dateReturn);
            
            if (matcher.Count > 0) 
            {
                securityCode = matcher[0].Value;
            }
            return securityCode;
        }

        public static string AvisoPrivacidadDocument() 
        {
            string docFile = Path.GetFullPath(Path.Combine(
                localpath, DOCUMENTS_FOLDER, AVISOPRIVACIDAD_DOCUMENT));
            return PDFDocument.readDocument(docFile);
        }

        public static List<string> RecoverFolderFilesNames(Driver driver, string folderpath) 
        {
            var Listfilesnames = new List<string>();
            byte[] downloadFolder = null;

            if (driver.GetRemoteState())
            {
                Dictionary<String, Object> pars = new Dictionary<String, Object>();
                pars.Add("handsetFile", folderpath + "/*");
                var something = driver.GetIntance().ExecuteScript("mobile:media:delete", pars);
            }
            else
            {
                downloadFolder = driver.GetIntance().PullFolder(folderpath);
            }
            
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
    }
}