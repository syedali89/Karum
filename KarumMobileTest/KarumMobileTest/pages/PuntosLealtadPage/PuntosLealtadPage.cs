namespace pages
{
    using data;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using utility;
    using static constants;

    public partial class PuntosLealtadPage : BasePage
    {
        //Contructor
        public PuntosLealtadPage(Driver driver) : base(driver)
        {}

        public void tapCanjearBtn()
        {
            _driver.Report.StepDescription("Tap CANJEAR button");
            clickElement(canjearBtn);
            _driver.Report.EndStep();
        }

        public void tapBeneficiosBtn()
        {
            _driver.Report.StepDescription("Tap BENEFICIOS button");
            clickElement(beneficiosBtn);
            _driver.Report.EndStep();
        }

        public void verifyPageElements(Client clientData)
        {
            _driver.Report.StepDescription("Verify if all elements from Puntos de Lealtad are on screen");

            assertElementText(headerTitle, "Puntos de lealtad");
            Assert.IsTrue(validateElementVisible(backButton), "Error, goBack button is not visible");
            
            verifyCreditoKarumNumber(clientData);

            assertElementWithTextExist("Puntos disponibles");
            assertElementText(pointsValue, clientData.totalLoyalPoints);
            assertElementWithTextExist("Dinero disponible");
            assertElementWithTextExist("$0.00");

            Assert.IsTrue(validateElementVisible(canjearBtn), "Error, 'Canjear' button is not visible");
            Assert.IsTrue(validateElementVisible(beneficiosBtn), "Error, 'Beneficios' button is not visible");

            this.verifyCanjearText();

            _driver.Report.EndStep();
        }

        public void verifyCanjearText()
        {
            _driver.Report.StepDescription("Verify Canjear message is on screen");

            assertElementWithTextExist("Lugares de canje");
            if (_driver.GetDevice().Equals(OS.ANDROID))
            {
                assertElementWithTextExist("Puedes canjear en la misma tienda donde realizas tus compras o en cualquier tienda de la cadena.");
            }
            else if (_driver.GetDevice().Equals(OS.IOS))
            {
                assertElementText(By.XPath("//*[contains(@label, 'Puedes canjear en la misma')]"), "Puedes canjear en la misma tienda donde realizas tus compras  o en cualquier tienda de la cadena.");
            }

            _driver.Report.EndStep();
        }

        public void verifyBeneficiosText()
        {
            _driver.Report.StepDescription("Verify Beneficios message is on screen");

            assertElementWithTextExist("Genera puntos en miles de artículos");
            assertElementWithTextExist("1er compra 10% de bonificación");
            assertElementWithTextExist("Siguientes compras 2%");
            assertElementWithTextExist("Semana de tu cumpleaños 10% de bonificación");
            assertElementWithTextExist("Accede a promociones exclusivas");
            assertElementWithTextExist("Sin anualidad");

            _driver.Report.EndStep();
        }
    }
}