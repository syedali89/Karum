
using NUnit.Framework;
using pages;
using utility;

namespace tests
{
    [TestFixture("Mis Movimientos Suite")]
    public class MisMovimientosSuite : BaseTest 
    {
        public HomePage home;
        public MisMovimientosPage movimientosPage;

        public MisMovimientosSuite(string testClass)
        {
            this.testClass = testClass;
        }

        [SetUp]
        public override void beforeMethod()
        {
            base.beforeMethod();

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