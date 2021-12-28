namespace tests
{
    using data;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using pages;
    using utility;

    [TestFixture]
    public class BaseTest
    {
        protected string testClass;
        protected Driver _driver;
        protected Client clientData;
        public LogIN logIN;

        [SetUp]
        public virtual void beforeMethod()
        {
            //Create Driver and Report Client
            _driver = new Driver();
            CreateReportingClient();

            //Create LogIN and grand all permissions
            logIN = new LogIN(_driver);
            logIN.grantAllPermissions();

            //Start Reporting
            _driver.Report.TestCaseStartReport();
        }

        [TearDown]
        public void afterTest()
        {
            //Reporting for success or fail
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Success)
            {
                _driver.Report.TestSuccess();
            }
            else
            {
                _driver.Report.TestFails(_driver.GetIntance(), _driver.exception);
            }

            //End report
            _driver.Report.TestCaseEndReport();

            //End Driver Session
            if (_driver != null)
            {
                _driver.GetIntance().Quit();
            }
        }

        private void CreateReportingClient()
        {
            _driver.CreateReportingClient(testClass);
        }        
    }
}