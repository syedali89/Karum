namespace tests
{
    using NUnit.Framework;
    using pages;
    using utility;

    [TestFixture("Credit Page Suite")]
    public class CreditPageSuite : BaseTest 
    {
        public HomePage home;
        public CreditPage creditpage;

        public CreditPageSuite(string testClass)
        {
            this.testClass = testClass;
        }

        [SetUp]
        public override void beforeMethod()
        {
            base.beforeMethod();

            clientData = DataRecover.RecoverClientData();
            home = logIN.allLoginProcess(clientData);
            creditpage = new CreditPage(_driver);
        }

        [Test, Order(1)]
        public void TC020_MisCreditosPage() 
        {
            creditpage.tapGoCreditDownMenu();
            creditpage.verifyCreditPageElements(clientData);
        }
        
        [Test, Order(2)]
        public void TC021_MisCreditosPage_HomePageButton() 
        {
            creditpage.tapGoCreditDownMenu();
            creditpage.tapGoHomeDownMenu();
            home.verifyHomePageOnScreen(clientData);
        }

        [Test, Order(3)]
        public void TC022_MisCreditosPage_ComprarTiendaButton() 
        {
            creditpage.tapGoCreditDownMenu();
            var comprartienda = creditpage.tapComprarTiendaBtn();
            creditpage.verifyPagarTiendaOnScreen();
            comprartienda.tapGoBack();
            creditpage.verifyCreditPageOnScreen();
        }

        [Test, Order(4)]
        public void TC023_MisCreditosPage_MisPuntosButton() 
        {
            creditpage.tapGoCreditDownMenu();
            var lealtadPage = creditpage.tapMisPuntosBtn();
            creditpage.verifyPuntosLealtadPageOnScreen();
            lealtadPage.tapGoBack();
            creditpage.verifyCreditPageOnScreen();
        }

        [Test, Order(5)]
        public void TC024_MisCreditosPage_MisMovimientosButton() 
        {
            creditpage.tapGoCreditDownMenu();
            var movimientosPage = creditpage.tapMisMovimientosBtn();
            creditpage.verifyMisMovimientosPageOnScreen();
            movimientosPage.tapGoBack();
            creditpage.verifyCreditPageOnScreen();
        }

        [Test, Order(6)]
        public void TC025_MisCreditosPage_Sandwich() 
        {
            creditpage.tapGoCreditDownMenu();
            var sandwich = creditpage.tapSandwichBtn();
            sandwich.verifytextElements(clientData);
            sandwich.tapCloseBtn();
            creditpage.verifyCreditPageOnScreen();
        }

        [Test, Order(7)]
        public void TC027_MisCreditosPage_EstadoCuentaButton() 
        {
            creditpage.tapGoCreditDownMenu();
            var estadocuenta = creditpage.tapEstadoCuentaBtn();
            creditpage.verifyEstadoCuentaPageOnScreen();
            estadocuenta.tapGoBack();
            creditpage.verifyCreditPageOnScreen();
        }
    }
}