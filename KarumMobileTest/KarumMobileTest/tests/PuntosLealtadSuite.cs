namespace tests
{
    using NUnit.Framework;
    using pages;
    using utility;

    [TestFixture("Puntos de Lealtad Suite")]
    public class PuntosLealtadSuite : BaseTest 
    {
        public HomePage home;
        public PuntosLealtadPage lealtadPage;

        public PuntosLealtadSuite(string testClass)
        {
            this.testClass = testClass;
        }

        [SetUp]
        public override void beforeMethod()
        {
            base.beforeMethod();

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