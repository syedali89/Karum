namespace pages
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using utility;

    public class MisMovimientosPage : BasePage
    {
        //By
        public By pagarTiendaBtn = By.Id("com.karum.credits:id/tv_purchases_main");

        //Contructor
        public MisMovimientosPage(Driver driver) : base(driver) 
        {
        }

        public void verifyPageElements()
        {
            assertElementText(headerTitle, "Mis movimientos");
            Assert.IsTrue(validateElementVisible(backButton), "Error, goBack button is not visible");
        }
    }
}