
using NUnit.Framework;
using pages;
using utility;

namespace tests
{
    [TestFixture("Pagar en Tienda Suite")]
    public class PagarTiendaSuite : BaseTest 
    {
        public HomePage home;
        public LogIN logIN; 
        public PagarTiendaPage pagarTienda;

        public PagarTiendaSuite(string testClass)
        {
            this.testClass = testClass;
        }

        [SetUp] 
        public void beforeMethod()
        {
            logIN = new LogIN(_driver);

            _driver.GetIntance().LaunchApp();
            logIN.grantAllPermissions();
            clientData = DataRecover.RecoverClientData();

            home = logIN.allLoginProcess(clientData);
            pagarTienda = home.tapPagarTiendaBtn();
            TestCaseStartReport();
        }

        [Test, Order(1)]
        public void TC010_PagarEnTiendaPage() 
        {
            pagarTienda.verifyPageElements(clientData);
        }

        [Test, Order(2)]
        public void TC011_PagarEnTiendaPage_CodigoButtons() 
        {
            pagarTienda.tapCodigoBarrasbutton();
            pagarTienda.verifyBardcodeDisplayed();

            pagarTienda.tapCodigoQRbutton();
            pagarTienda.verifyQRcodeDisplayed();
        }

        [Test, Order(3)]
        public void TC012_PagarEnTiendaPage_GoBackButton() 
        {
            pagarTienda.tapGoBack();
            home.verifyHomePageOnScreen(clientData);
        }
    }
}