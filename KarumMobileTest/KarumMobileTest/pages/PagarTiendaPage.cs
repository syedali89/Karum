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
            clickElement(codigoQRbutton);
        }

        public void tapCodigoBarrasbutton() 
        {
            clickElement(codigoBarrasbutton);
        }

        public void verifyQRcodeDisplayed()
        {
            Assert.IsTrue(validateElementVisible(QRcodeDisplay), "Error, QR code is not visible");
        }

        public void verifyBardcodeDisplayed()
        {
            Assert.IsTrue(validateElementVisible(bardcodeDisplay), "Error, Bardcode is not visible");
        }

        public void verifyPageElements(Client clientData)
        {
            string lastPhone = clientData.PhoneNumber.Substring(clientData.PhoneNumber.Length - 4);

            assertElementText(headerTitle, "Pagar en tienda");
            Assert.IsTrue(validateElementVisible(backButton), "Error, goBack button is not visible");

            assertElementWithTextExist("Crédito Karum");
            assertElementText(clientNumber, "************" + lastPhone);
            
            assertElementText(codigoQRbutton, "Código QR");
            assertElementText(codigoBarrasbutton, "Código de barras");

            verifyQRcodeDisplayed();
        }
    }
}