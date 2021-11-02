namespace pages
{
    using data;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using utility;
    using static constants;

    public class EstadoCuentaPage : BasePage
    {
        //By
        public By estadosCuenta = By.Id("com.karum.credits:id/tv_period_item");      
        public By passwordEstadoCuenta = By.Id("com.karum.credits:id/et_pass_login");
        public By ACEPTARpasswordbtn = By.XPath("//*[@text='ACEPTAR']");      
        public By CANCELARpasswordbtn = By.XPath("//*[@text='CANCELAR']");      
        
        //By Document
        public By pageIndicator = By.Id("com.karum.credits:id/tv_pager_indicator");      
        public By nextPageBtn = By.Id("com.karum.credits:id/iv_next_page");      
        public By previousPageBtn = By.Id("com.karum.credits:id/iv_previous_page");      
        public By DESCARGARBtn = By.Id("com.karum.credits:id/btn_download");      
        public By pdfPreview = By.Id("com.karum.credits:id/pdf_view");

        private int currentPage = 1;       
        private string currentPageDescripcion = "Páginas 1 / 4";       

        //Contructor
        public EstadoCuentaPage(Driver driver) : base(driver)
        {}

        public void tapEstadoCuenta(string month)
        {
            By estadoCuenta = By.XPath("//*[contains(@text, '" + month + "')]");
            clickElement(estadoCuenta);
        }

        public void tapCANCELAR()
        {
            clickElement(CANCELARpasswordbtn);
        }

        public void tapACEPTAR()
        {
            clickElement(ACEPTARpasswordbtn);
        }

        public void tapNextPage()
        {
            ChangePage(ADD);
            clickElement(nextPageBtn);
        }

        public void tapDESCARGAR()
        {
            if (filesONDownload().Count > 0)
            {
                _driver.DeleteFilesDownload();
            }
            
            clickElement(DESCARGARBtn);
              
            var lista = filesONDownload();
            
            while (lista.Count <= 0)
            {
                Thread.Sleep(500);
                lista = filesONDownload();
            }            
        }

        public void SwipeDownPdfDocument()
        {
            waitVisibility(pdfPreview);
            ChangePage(ADD);
            SwipeAction.swipeDirectionFromElement(
                _driver, pdfPreview, Direction.DOWN);
        }

        public void SwipeUpPdfDocument()
        {
            waitVisibility(pdfPreview);
            ChangePage(SUBSTRACT);
            SwipeAction.swipeDirectionFromElement(
                _driver, pdfPreview, Direction.UP);
        }

        public void tapPreviousPage()
        {
            ChangePage(SUBSTRACT);
            clickElement(previousPageBtn);
        }

        public void inputPASSWORD(string password)
        {
            sendTextElement(passwordEstadoCuenta, password);
        }

        public void verifyPageElements(Client clientData)
        {
            assertElementText(headerTitle, "Estado de cuenta");
            Assert.IsTrue(validateElementVisible(backButton), "Error, goBack button is not visible");
            assertElementWithTextExist("Crédito Karum");
            assertElementText(clientNumber, "************" + clientData.getLastCreditNumber());
            
            assertElementWithTextExist("Selecciona el estado de cuenta\nque deseas consultar");

            var listEstadoCuenta = _driver.GetIntance().FindElements(estadosCuenta);

            var currentDaTE = DateTime.Now;
            var listMonths = new List<string>();
            //{
            //    currentDaTE.AddMonths(-1).ToString("MMMM yyyy", new CultureInfo("es-ES")),
            //    currentDaTE.AddMonths(-2).ToString("MMMM yyyy", new CultureInfo("es-ES")),
            //    currentDaTE.AddMonths(-3).ToString("MMMM yyyy", new CultureInfo("es-ES")),
            //    currentDaTE.AddMonths(-4).ToString("MMMM yyyy", new CultureInfo("es-ES")),
            //    currentDaTE.AddMonths(-5).ToString("MMMM yyyy", new CultureInfo("es-ES")),
            //    currentDaTE.AddMonths(-6).ToString("MMMM yyyy", new CultureInfo("es-ES"))
            //};

            for(int i = -1;i >= -6;i-- )
            {
                listMonths.Add(currentDaTE.AddMonths(i).ToString("MMMM yyyy", new CultureInfo("es-ES")));
            }
            
            Assert.AreEqual(listMonths.Count, listEstadoCuenta.Count, "Error, the numbers of elements 'Estado de Cuenta' on screen are different of expected");

            for (int i = 0; listEstadoCuenta.Count > i; i++)
            {                
                assertTextContains(listEstadoCuenta[i].Text.ToUpper(), listMonths[i].ToUpper());
            }
        }

        public void verifyPasswordElements()
        {
            assertElementWithTextExist(@"Contraseña requerida");
            assertElementWithTextExist(@"Por favor ingresa la contraseña del Estado de cuenta");
            assertElementWithTextExist(@"Contraseña *");

            Assert.IsTrue(validateElementVisible(passwordEstadoCuenta), "Error, password input field is not visible");
            Assert.IsTrue(validateElementVisible(ACEPTARpasswordbtn), "Error, ACEPTAR button is not visible");
            Assert.IsTrue(validateElementVisible(CANCELARpasswordbtn), "Error, CANCELAR button is not visible");
        }

        public void verifyWrongPasswordMessage()
        {
            assertElementWithTextExist(@"La contraseña ingresada es incorrecta");
        }

        public void verifyCorrectPasswordMessage(string mounth)
        {
            assertTextContains(headerTitle, mounth);
        }

        public void verifyCurrentPage()
        {
            assertElementText(pageIndicator, currentPageDescripcion);
        }

        public void verifypdfDocumentElements(Client clientData, string mounth)
        {
            verifyCorrectPasswordMessage(mounth);
            Assert.IsTrue(validateElementVisible(backButton), "Error, goBack button is not visible");
            assertElementWithTextExist("Crédito Karum");
            assertElementText(clientNumber, "************" + clientData.getLastCreditNumber());

            this.verifyCurrentPage();
            Assert.IsTrue(validateElementVisible(nextPageBtn), "Error, next page button is not visible");
            Assert.IsTrue(validateElementVisible(previousPageBtn), "Error, previous page button is not visible");
            Assert.IsTrue(validateElementVisible(pdfPreview), "Error, pdf preview document is not visible");
            Assert.IsTrue(validateElementVisible(DESCARGARBtn), "Error, DESCARGAR button is not visible");
        }

        public void verifypdfDocumentDownload(string Month)
        {
            DateTime currentDate = DateTime.Now;
            string pdfname = string.Format("Karum-{0}_{1}-{2}", Month, currentDate.Year, currentDate.ToString("yyyyMMdd"));

            bool fileWasDownload = false;

            var lista = filesONDownload();

            Assert.IsTrue(lista.Count > 0, "Error, no file was found in Download folder");
            Assert.IsTrue(lista.Count == 1, "Error, if has to be only one file in Download folder");

            foreach (string file in lista)
            {
                if (file.Contains(pdfname) && file.Contains(".pdf"))
                {
                    fileWasDownload = true;
                    break;
                }
            }

            Assert.IsTrue(fileWasDownload, "Error, expected file was not find in Download folder");
        }

        private void ChangePage(string action)
        {
            if(action.Equals(ADD) && currentPage < 4)
            {
                currentPage++;
            }
            else if(action.Equals(SUBSTRACT) && currentPage > 1)
            {
                currentPage--;
            }

            this.currentPageDescripcion = string.Format("Páginas {0} / 4", currentPage.ToString());
        }

        private List<string> filesONDownload()
        {            
            string path = string.Empty;
            if (_driver.GetDriverType().Equals(ANDROID))
            {
                path = MOVILE_DOWNLOAD_PATHFOLDER_ANDROID;
            }
            else if (_driver.GetDriverType().Equals(IOS))
            {
                ///TODO
            }

            return DataRecover.RecoverFolderFilesNames(_driver, path);
        }
    }
}