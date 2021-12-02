namespace pages 
{
    using data;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using utility;

    public partial class PagarTiendaPage : BasePage
    {       
        //Contructor
        public PagarTiendaPage(Driver driver) : base(driver)
        {}

        public void tapCodigoQRbutton() 
        {
            _driver.Report.StepDescription("Tap C�digo QR");
            clickElement(codigoQRbutton);
            _driver.Report.EndStep();
        }

        public void tapCodigoBarrasbutton() 
        {
            _driver.Report.StepDescription("Tap C�digo Barras");
            clickElement(codigoBarrasbutton);
            _driver.Report.EndStep();
        }

        public void verifyQRcodeDisplayed()
        {
            _driver.Report.StepDescription("Verify if QR Code is on screen");

            if (_driver.GetRemoteState())
            {
                ///TODO implement Perfecto Image validation
                Assert.IsTrue(validateElementVisible(QRcodeDisplay), "Error, QR code is not visible");
            }
            else
            {
                Assert.IsTrue(validateElementVisible(QRcodeDisplay), "Error, QR code is not visible");
            }

            _driver.Report.EndStep();
        }

        public void verifyBardcodeDisplayed()
        {
            _driver.Report.StepDescription("Verify if Barcode is on screen");

            if (_driver.GetRemoteState())
            {
                ///TODO implement Perfecto Image validation
                Assert.IsTrue(validateElementVisible(bardcodeDisplay), "Error, Bardcode is not visible");
            }
            else
            {
                Assert.IsTrue(validateElementVisible(bardcodeDisplay), "Error, Bardcode is not visible");
            }            
            
            _driver.Report.EndStep();
        }

        public void verifyPageElements(Client clientData)
        {
            _driver.Report.StepDescription("Verify if all elements from Pagar en Tienda Page are on Screen");

            assertElementText(headerTitle, "Pagar en tienda");
            Assert.IsTrue(validateElementVisible(backButton), "Error, goBack button is not visible");

            verifyCreditoKarumNumber(clientData);

            assertElementText(codigoQRbutton, "C�digo QR");
            assertElementText(codigoBarrasbutton, "C�digo de barras");

            verifyQRcodeDisplayed();

            _driver.Report.EndStep();
        }
    }
}