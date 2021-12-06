namespace tests
{
    using NUnit.Framework;
    using pages;
    using utility;

    [TestFixture("Consulta de Saldo Suite")]
    public class ConsultaSaldoSuite : BaseTest 
    {
        public HomePage home;
        public ConsultaSaldoPage consultaSaldo;

        public ConsultaSaldoSuite(string testClass)
        {
            this.testClass = testClass;
        }

        [SetUp]
        public override void beforeMethod()
        {
            base.beforeMethod();
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