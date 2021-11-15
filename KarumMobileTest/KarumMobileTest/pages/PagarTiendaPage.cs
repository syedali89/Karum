namespace pages 
{
    using data;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using utility;

    public class PagarTiendaPage : BasePage
    {
        //By 
        public By codigoQRbutton = By.Id("com.karum.credits:id/tv_item_1");
        public By codigoBarrasbutton = By.Id("com.karum.credits:id/tv_item_2");
        public By QRcodeDisplay = By.Id("com.karum.credits:id/iv_qr_purchases");
        public By bardcodeDisplay = By.Id("com.karum.credits:id/iv_barcode_purchases");        
        //Contructor
        public PagarTiendaPage(Driver driver) : base(driver)
        {}

        public void tapCodigoQRbutton() 
        {
            _driver.Report.StepDescription("Tap Código QR");
            clickElement(codigoQRbutton);
            _driver.Report.EndStep();
        }

        public void tapCodigoBarrasbutton() 
        {
            _driver.Report.StepDescription("Tap Código Barras");
            clickElement(codigoBarrasbutton);
            _driver.Report.EndStep();
        }

        public void verifyQRcodeDisplayed()
        {
            _driver.Report.StepDescription("Verify if QR Code is on screen");
            Assert.IsTrue(validateElementVisible(QRcodeDisplay), "Error, QR code is not visible");
            _driver.Report.EndStep();
        }

        public void verifyBardcodeDisplayed()
        {
            _driver.Report.StepDescription("Verify if Barcode is on screen");
            Assert.IsTrue(validateElementVisible(bardcodeDisplay), "Error, Bardcode is not visible");
            _driver.Report.EndStep();
        }

        public void verifyPageElements(Client clientData)
        {
            _driver.Report.StepDescription("Verify if all elements from Pagar en Tienda Page are on Screen");

            assertElementText(headerTitle, "Pagar en tienda");
            Assert.IsTrue(validateElementVisible(backButton), "Error, goBack button is not visible");

            assertElementWithTextExist("Crédito Karum");
            assertElementText(clientNumber, "************" + clientData.getLastCreditNumber());
            
            assertElementText(codigoQRbutton, "Código QR");
            assertElementText(codigoBarrasbutton, "Código de barras");

            verifyQRcodeDisplayed();

            _driver.Report.EndStep();
        }
    }
}