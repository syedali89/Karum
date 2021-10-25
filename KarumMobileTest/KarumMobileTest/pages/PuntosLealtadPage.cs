namespace pages
{
    using data;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using utility;

    public class PuntosLealtadPage : BasePage
    {
        //By
        public By canjearBtn = By.Id("com.karum.credits:id/tv_item_1");
        public By beneficiosBtn = By.Id("com.karum.credits:id/tv_item_2");

        //Contructor
        public PuntosLealtadPage(Driver driver) : base(driver)
        {}

        public void tapCanjearBtn()
        {
            clickElement(canjearBtn);
        }

        public void tapBeneficiosBtn()
        {
            clickElement(beneficiosBtn);
        }

        public void verifyPageElements(Client clientData)
        {            
            assertElementText(headerTitle, "Puntos de lealtad");
            Assert.IsTrue(validateElementVisible(backButton), "Error, goBack button is not visible");
            assertElementWithTextExist("Crédito Karum");
            assertElementText(clientNumber, "************" + clientData.getLastCreditNumber());
            //TODO Text not accecible because of problem with code
            this.verifyCanjearText();
        }

        public void verifyCanjearText()
        {
            //TODO Text not accecible because of problem with code
        }

        public void verifyBeneficiosText()
        {
            //TODO Text not accecible because of problem with code
        }


    }
}