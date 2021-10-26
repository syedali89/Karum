
using NUnit.Framework;
using pages;
using utility;

namespace tests
{
    public class PuntosLealtadSuite : BaseTest 
    {
        public HomePage home;
        public LogIN logIN; 
        public PuntosLealtadPage lealtadPage; 

        [SetUp] 
        public void beforeMethod()
        {
            logIN = new LogIN(_driver);

            _driver.GetIntance().LaunchApp();
            logIN.grantAllPermissions();
            clientData = DataRecover.RecoverClientData();

            home = logIN.allLoginProcess(clientData);
            lealtadPage = home.tapPuntosLealtadBtn();
        }

        [Test, Order(1)]
        public void TC017_PuntosLealtadPage() 
        {
            lealtadPage.verifyPageElements(clientData);
        }
        
        [Test, Order(2)]
        public void TC018_PuntosLealtadPage_CanjearBeneficiosButtons() 
        {
            lealtadPage.tapBeneficiosBtn();
            lealtadPage.verifyBeneficiosText();
            lealtadPage.tapCanjearBtn();
            lealtadPage.verifyCanjearText();
        }

        [Test, Order(3)]
        public void TC019_PuntosLealtadPage_GoBackButton() 
        {
            lealtadPage.tapGoBack();
            home.verifyHomePageOnScreen(clientData);
        }
    }
}