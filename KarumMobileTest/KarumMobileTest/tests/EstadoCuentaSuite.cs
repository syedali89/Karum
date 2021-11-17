
namespace tests
{
    using NUnit.Framework;
    using pages;
    using utility;
    using static constants;

    [TestFixture("Estado de Cuenta Suite")]
    public class EstadoCuentaSuite  : BaseTest 
    {
        public HomePage home;
        public EstadoCuentaPage estadoCuenta;

        public EstadoCuentaSuite(string testClass)
        {
            this.testClass = testClass;
        }

        [SetUp]
        public override void beforeMethod()
        {
            base.beforeMethod();

            clientData = DataRecover.RecoverClientData();
            home = logIN.allLoginProcess(clientData);
            estadoCuenta = home.tapEstadoCuentaBtn();
        }

        [Test, Order(1)]
        public void TC028_EstadoCuenta_PageValidation() 
        {
            estadoCuenta.verifyPageElements(clientData);
        }

        [Test, Order(2)]
        public void TC029_EstadoCuenta_DocumentRequiredPassword() 
        {
            estadoCuenta.tapEstadoCuenta(AGOSTO);
            estadoCuenta.verifyPasswordElements();
            estadoCuenta.tapCANCELAR();
            home.verifyEstadoCuentaPageOnScreen();
        }

        [Test, Order(3)]
        public void TC030_EstadoCuenta_WrongPasswordDocument() 
        {
            estadoCuenta.tapEstadoCuenta(AGOSTO);
            estadoCuenta.inputPASSWORD("XXXX");
            estadoCuenta.tapACEPTAR();
            estadoCuenta.verifyWrongPasswordMessage();
            estadoCuenta.tapACEPTAR();
            home.verifyEstadoCuentaPageOnScreen();
        }

        [Test, Order(4)]
        public void TC043_EstadoCuenta_CorrectPasswordDocument() 
        {
            estadoCuenta.tapEstadoCuenta(AGOSTO);
            estadoCuenta.inputPASSWORD(clientData.estadoCuentaPass);
            estadoCuenta.tapACEPTAR();
            estadoCuenta.verifyCorrectPasswordMessage(AGOSTO);
        }

        [Test, Order(5)]
        public void TC044_EstadoCuenta_DocumentPageText() 
        {
            estadoCuenta.tapEstadoCuenta(AGOSTO);
            estadoCuenta.inputPASSWORD(clientData.estadoCuentaPass);
            estadoCuenta.tapACEPTAR();
            estadoCuenta.verifypdfDocumentElements(clientData, AGOSTO);
        }

        [Test, Order(6)]
        public void TC045_EstadoCuenta_DocumentPageArrows() 
        {
            estadoCuenta.tapEstadoCuenta(AGOSTO);
            estadoCuenta.inputPASSWORD(clientData.estadoCuentaPass);
            estadoCuenta.tapACEPTAR();
            estadoCuenta.tapNextPage();
            estadoCuenta.verifyCurrentPage();
            estadoCuenta.tapPreviousPage();
            estadoCuenta.verifyCurrentPage();
        }

        [Test, Order(7)]
        public void TC046_EstadoCuenta_SwipeDownUpDocument() 
        {
            estadoCuenta.tapEstadoCuenta(AGOSTO);
            estadoCuenta.inputPASSWORD(clientData.estadoCuentaPass);
            estadoCuenta.tapACEPTAR();
            estadoCuenta.SwipeDownPdfDocument();
            estadoCuenta.verifyCurrentPage();
            estadoCuenta.SwipeUpPdfDocument();
            estadoCuenta.verifyCurrentPage();
        }

        [Test, Order(8)]
        public void TC047_EstadoCuenta_FullDocumentVerification() 
        {
            estadoCuenta.tapEstadoCuenta(AGOSTO);
            estadoCuenta.inputPASSWORD(clientData.estadoCuentaPass);
            estadoCuenta.tapACEPTAR();
            estadoCuenta.tapNextPage();
            estadoCuenta.tapNextPage();
            estadoCuenta.tapNextPage();
            estadoCuenta.verifyCurrentPage();
        }

        [Test, Order(9)]
        public void TC048_EstadoCuenta_DocumentDownloadButton() 
        {
            estadoCuenta.tapEstadoCuenta(AGOSTO);
            estadoCuenta.inputPASSWORD(clientData.estadoCuentaPass);
            estadoCuenta.tapACEPTAR();
            estadoCuenta.tapDESCARGAR();
            estadoCuenta.verifypdfDocumentDownload(AGOSTO);
        }
    }
}