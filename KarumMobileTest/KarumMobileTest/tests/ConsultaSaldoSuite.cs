
using NUnit.Framework;
using pages;
using utility;

namespace tests
{
    public class ConsultaSaldoSuite : BaseTest 
    {
        public HomePage home;
        public LogIN logIN; 
        public ConsultaSaldoPage consultaSaldo; 

        [SetUp]
        public void beforeMethod()
        {
            logIN = new LogIN(_driver);

            _driver.GetIntance().LaunchApp();
            logIN.grantAllPermissions();
            clientData = DataRecover.RecoverClientData();

            home = logIN.allLoginProcess(clientData);
            consultaSaldo = home.tapSaldoCuenta();
        }

        [Test, Order(1)]
        public void TC008_ConsultaSaldoPage() 
        {
            consultaSaldo.verifyPageElements(clientData);
        }

        [Test, Order(2)]
        public void TC009_ConsultaSaldoPage_BackHOME() 
        {
            consultaSaldo.tapGoBack();
            home.verifyHomePageOnScreen(clientData);
        }
    }
}