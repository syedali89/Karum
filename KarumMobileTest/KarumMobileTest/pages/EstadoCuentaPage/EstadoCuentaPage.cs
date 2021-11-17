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

    public partial class EstadoCuentaPage : BasePage
    {
        private int currentPage = 1;       
        private string currentPageDescripcion = "Páginas 1 / 4";       

        //Contructor
        public EstadoCuentaPage(Driver driver) : base(driver)
        {}

        public void tapEstadoCuenta(string month)
        {
            _driver.Report.StepDescription("Tap Estado de cuenta with value: '"+ month + "' button");
            By estadoCuenta = By.XPath("//*[contains(@text, '" + month + "')]");
            clickElement(estadoCuenta);
            _driver.Report.EndStep();
        }

        public void tapCANCELAR()
        {
            _driver.Report.StepDescription("Tap CANCELAR button");
            clickElement(CANCELARpasswordbtn);
            _driver.Report.EndStep();
        }

        public void tapACEPTAR()
        {
            _driver.Report.StepDescription("Tap ACEPTAR button");
            clickElement(ACEPTARpasswordbtn);
            _driver.Report.EndStep();
        }

        public void tapNextPage()
        {
            _driver.Report.StepDescription("Tap Next Page button");
            ChangePage(ADD);
            clickElement(nextPageBtn);
            _driver.Report.EndStep();
        }


        public void tapPreviousPage()
        {
            _driver.Report.StepDescription("Tap Previous Page button");
            ChangePage(SUBSTRACT);
            clickElement(previousPageBtn);
            _driver.Report.EndStep();
        }

        public void tapDESCARGAR()
        {
            _driver.Report.StepDescription("Tap Descargar button");

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
            _driver.Report.EndStep();
        }

        public void SwipeDownPdfDocument()
        {
            _driver.Report.StepDescription("Swipe Down in the pdf preview");
            waitVisibility(pdfPreview);
            ChangePage(ADD);
            SwipeAction.swipeDirectionFromElement(
                _driver, pdfPreview, Direction.DOWN);
            _driver.Report.EndStep();
        }

        public void SwipeUpPdfDocument()
        {
            _driver.Report.StepDescription("Swipe Up in the pdf preview");
            waitVisibility(pdfPreview);
            ChangePage(SUBSTRACT);
            SwipeAction.swipeDirectionFromElement(
                _driver, pdfPreview, Direction.UP);
            _driver.Report.EndStep();
        }

        public void inputPASSWORD(string password)
        {
            _driver.Report.StepDescription("Inform the input Password field");
            sendTextElement(passwordEstadoCuenta, password);
            _driver.Report.EndStep();
        }

        public void verifyPageElements(Client clientData)
        {
            _driver.Report.StepDescription("Verify if all elements from Estado de Cuenta Page are on Screen");

            assertElementText(headerTitle, "Estado de cuenta");
            Assert.IsTrue(validateElementVisible(backButton), "Error, goBack button is not visible");
            assertElementWithTextExist("Crédito Karum");
            assertElementText(clientNumber, "************" + clientData.getLastCreditNumber());
            
            assertElementWithTextExist("Selecciona el estado de cuenta\nque deseas consultar");

            var listEstadoCuenta = _driver.GetIntance().FindElements(estadosCuenta);

            var currentDaTE = DateTime.Now;
            var listMonths = new List<string>();

            for(int i = -1;i >= -6;i-- )
            {
                listMonths.Add(currentDaTE.AddMonths(i).ToString("MMMM yyyy", new CultureInfo("es-ES")));
            }
            
            Assert.AreEqual(listMonths.Count, listEstadoCuenta.Count, "Error, the numbers of elements 'Estado de Cuenta' on screen are different of expected");

            for (int i = 0; listEstadoCuenta.Count > i; i++)
            {                
                assertTextContains(listEstadoCuenta[i].Text.ToUpper(), listMonths[i].ToUpper());
            }

            _driver.Report.EndStep();
        }

        public void verifyPasswordElements()
        {
            _driver.Report.StepDescription("Verify if all elements from Password Modal are on Screen");

            assertElementWithTextExist(@"Contraseña requerida");
            assertElementWithTextExist(@"Por favor ingresa la contraseña del Estado de cuenta");

            Assert.IsTrue(validateElementVisible(passwordEstadoCuenta), "Error, password input field is not visible");
            Assert.IsTrue(validateElementVisible(ACEPTARpasswordbtn), "Error, ACEPTAR button is not visible");
            Assert.IsTrue(validateElementVisible(CANCELARpasswordbtn), "Error, CANCELAR button is not visible");

            _driver.Report.EndStep();
        }

        public void verifyWrongPasswordMessage()
        {
            _driver.Report.StepDescription("Verify error message when input incorrect password");
            assertElementWithTextExist(@"La contraseña ingresada es incorrecta");
            _driver.Report.EndStep();
        }

        public void verifyCorrectPasswordMessage(string mounth)
        {
            _driver.Report.StepDescription("Verify if document is open when input correct password");
            assertTextContains(headerTitle, mounth);
            _driver.Report.EndStep();
        }

        public void verifyCurrentPage()
        {
            _driver.Report.StepDescription("Verify if the page on screen is the expected: " + currentPage);
            assertElementText(pageIndicator, currentPageDescripcion);
            _driver.Report.EndStep();
        }

        public void verifypdfDocumentElements(Client clientData, string mounth)
        {
            _driver.Report.StepDescription("Verify if all elements from Document Page are on Screen");

            verifyCorrectPasswordMessage(mounth);
            Assert.IsTrue(validateElementVisible(backButton), "Error, goBack button is not visible");
            assertElementWithTextExist("Crédito Karum");
            assertElementText(clientNumber, "************" + clientData.getLastCreditNumber());

            this.verifyCurrentPage();
            Assert.IsTrue(validateElementVisible(nextPageBtn), "Error, next page button is not visible");
            Assert.IsTrue(validateElementVisible(previousPageBtn), "Error, previous page button is not visible");
            Assert.IsTrue(validateElementVisible(pdfPreview), "Error, pdf preview document is not visible");
            Assert.IsTrue(validateElementVisible(DESCARGARBtn), "Error, DESCARGAR button is not visible");

            _driver.Report.EndStep();
        }

        public void verifypdfDocumentDownload(string Month)
        {
            _driver.Report.StepDescription("Verify if the document was download");

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

            _driver.Report.EndStep();
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
            if (_driver.GetDevice().Equals(EnvironmentData.DEVICE.ANDROID))
            {
                path = MOVILE_DOWNLOAD_PATHFOLDER_ANDROID;
            }
            else if (_driver.GetDevice().Equals(EnvironmentData.DEVICE.IOS))
            {
                path = MOVILE_DOWNLOAD_PATHFOLDER_IOS;
            }

            return DataRecover.RecoverFolderFilesNames(_driver, path);
        }
    }
}