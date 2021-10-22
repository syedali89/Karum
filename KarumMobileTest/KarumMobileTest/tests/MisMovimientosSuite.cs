
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
        public void TC010_PagarEnTiendaPage() 
        {
            movimientosPage.verifyPageElements();
        }
    }
}