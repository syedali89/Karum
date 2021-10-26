
using NUnit.Framework;
using pages;
using utility;

namespace tests
{
    public class MisMovimientosSuite : BaseTest 
    {
        public HomePage home;
        public LogIN logIN; 
        public MisMovimientosPage movimientosPage; 

        [SetUp] 
        public void beforeMethod()
        {
            logIN = new LogIN(_driver);

            _driver.GetIntance().LaunchApp();
            logIN.grantAllPermissions();
            clientData = DataRecover.RecoverClientData();

            home = logIN.allLoginProcess(clientData);
            movimientosPage = home.tapMisMovimientosBtnBtn();
        }

        [Test, Order(1)]
        public void TC013_MisMovimientosPage() 
        {
            movimientosPage.verifyPageElements(clientData);
        }

        [Test, Order(2)]
        public void TC014_MisMovimientosPage_GoBackButton() 
        {
            movimientosPage.tapGoBack();
            home.verifyHomePageOnScreen(clientData);
        }

        [Test, Order(3)]
        public void TC015_MisMovimientosPage_TapOneData() 
        {
            var mov = movimientosPage.tapMovimiento();
            movimientosPage.verifySelectedMovementText(mov);
            movimientosPage.tapOutsideMovement();
            movimientosPage.verifyMisMovimientoPageOnScreen();
        }

        [Test, Order(4)]
        public void TC016_MisMovimientosPage_TapSolictarAclaracionCargo() 
        {
            movimientosPage.tapMovimiento();
            movimientosPage.tapSolicitarAclaracion();
            movimientosPage.verifySolicitarAclaracionText(clientData);
        }
    }
}