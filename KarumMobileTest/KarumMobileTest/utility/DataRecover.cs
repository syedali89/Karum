namespace utility
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using data;
    using OpenQA.Selenium;

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
        private const string TERMINOSCONDICIONES_DOCUMENT =
                "TÉRMINOS Y CONDICIONES (22sep2021).pdf";
        private const string USOMEDIOSTECNOLOGICOS_DOCUMENT =
                "TERMS Y COND MEDIOS ELECTRONICOS (22sep2021).pdf";
        private const string BUROCREDITO_DOCUMENT =
                "AUTORIZACIÓN BURÓ DE CRÉDITO (22sep2021).pdf";

        private static string localpath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", ".."));

        public static Client RecoverClientData() 
        {
            //TODO For now the informations is hardcode. Later is gonna refactor.
            Client client = new Client();
            client.AddressStreet = "Some Street";
            client.AddressExtNum = "1234";
            client.AddressIntNum = "1234";
            client.AddressCity = "Ciudad de México";
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

            client.accountAmount = "$14,277.13";
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

            return client;
        }

        public static Client RecoverClientData(string File) 
        {
            //TODO For now the informations is hardcode. Later is gonna refactor.
            Client client = new Client();
            return client;
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
                localpath, constants.DOCUMENTS_FOLDER, AVISOPRIVACIDAD_DOCUMENT));
            return PDFDocument.readDocument(docFile);
        }

        public static string TerminosCondicionesDocument() 
        {
            string docFile = Path.GetFullPath(Path.Combine(
                localpath, constants.DOCUMENTS_FOLDER, TERMINOSCONDICIONES_DOCUMENT));
            return PDFDocument.readDocument(docFile);
        }

        public static string UsoMediosTecnologicosDocument() 
        {
            string docFile = Path.GetFullPath(Path.Combine(
                localpath, constants.DOCUMENTS_FOLDER, USOMEDIOSTECNOLOGICOS_DOCUMENT));
            return PDFDocument.readDocument(docFile);
        }

        public static string BuroCreditoDocument() 
        {
            string docFile = Path.GetFullPath(Path.Combine(
                localpath, constants.DOCUMENTS_FOLDER, BUROCREDITO_DOCUMENT));
            return PDFDocument.readDocument(docFile);
        }
    }
}