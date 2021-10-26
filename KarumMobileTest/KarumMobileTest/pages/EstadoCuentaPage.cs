namespace pages
{
    using data;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using utility;

    public class EstadoCuentaPage : BasePage
    {
        //By
        public By canjearBtn = By.Id("com.karum.credits:id/tv_item_1");
        public By beneficiosBtn = By.Id("com.karum.credits:id/tv_item_2");
        public By pointsValue = By.Id("com.karum.credits:id/tv_available_points");

        //Contructor
        public EstadoCuentaPage(Driver driver) : base(driver)
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
            
            assertElementWithTextExist("Puntos disponibles");
            assertElementText(pointsValue, clientData.totalLoyalPoints);
            assertElementWithTextExist("Dinero disponible");
            assertElementWithTextExist("$0.00");

            Assert.IsTrue(validateElementVisible(canjearBtn), "Error, 'Canjear' button is not visible");
            Assert.IsTrue(validateElementVisible(beneficiosBtn), "Error, 'Beneficios' button is not visible");

            this.verifyCanjearText();
        }

        public void verifyCanjearText()
        {
            assertElementWithTextExist("Lugares de canje");
            assertElementWithTextExist("Puedes canjear en la misma tienda donde realizas tus compras o en cualquier tienda de la cadena.");
        }

        public void verifyBeneficiosText()
        {
            assertElementWithTextExist("Genera puntos en miles de artículos");
            assertElementWithTextExist("1er compra 10% de bonificación");
            assertElementWithTextExist("Siguientes compras 2%");
            assertElementWithTextExist("Semana de tu cumpleaños 10% de bonificación");
            assertElementWithTextExist("Accede a promociones exclusivas");
            assertElementWithTextExist("Sin anualidad");
        }
    }
}