
using NUnit.Framework;
using pages;
using utility;

namespace tests
{
    public class HomePageSuite : BaseTest 
    {
        public HomePage home;
        public LogIN logIN; 

        [SetUp] 
        public void beforeMethod()
        {
            logIN = new LogIN(_driver);

            _driver.GetIntance().LaunchApp();
            logIN.grantAllPermissions();
            clientData = DataRecover.RecoverClientData();

            home = logIN.allLoginProcess(clientData);
        }

        [Test, Order(1)]
        public void TC001_UserHomePage_ValidateElementsHome() 
        {
            home.verifyHomePageElements(clientData);
        }

        [Test, Order(2)]
        public void TC002_UserHomePage_ConsultaSaldoButton() 
        {
            home.tapSaldoCuenta();
            home.verifySaldoCuentaOnScreen();
        }

        [Test, Order(3)]
        public void TC003_UserHomePage_PagarEnTiendaButton() 
        {
            home.tapPagarTiendaBtn();
            home.verifyPagarTiendaOnScreen();
        }

        [Test, Order(4)]
        public void TC004_UserHomePage_MisMovimientosButton() 
        {
            home.tapMisMovimientosBtnBtn();
            home.verifyMisMovimientosPageOnScreen();
        }

        [Test, Order(5)]
        public void TC005_UserHomePage_PuntosDeLealtadButton() 
        {
            home.tapPuntosLealtadBtn();
            home.verifyPuntosLealtadPageOnScreen();
        }

        [Test, Order(6)]
        public void TC006_UserHomePage_SandwichMenuButton() 
        {
            SanwichMenuPage sandwichPage = home.tapSandwichBtn();
            sandwichPage.verifytextElements(clientData);
            sandwichPage.tapCloseBtn();
            home.verifyHomePageOnScreen(clientData);
        }

        [Test, Order(7)]
        public void TC007_UserHomePage_SandwichMenuButton_CerrarSesion() 
        {
            SanwichMenuPage sandwichPage = home.tapSandwichBtn();
            sandwichPage.tapCerrarSesionBtn();
        }

        [Test, Order(8)]
        public void TC026_UserHomePage_EstadoCuentaButton()
        {
            var estadoCuenta = home.tapEstadoCuentaBtn();
            home.verifyEstadoCuentaPageOnScreen();
            estadoCuenta.tapGoBack();
            home.verifyHomePageOnScreen(clientData);
        }
    }
}