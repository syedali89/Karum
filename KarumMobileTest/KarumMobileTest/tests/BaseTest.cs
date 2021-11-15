namespace tests
{
    using data;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using Reportium.Client;
    using Reportium.Model;
    using Reportium.Test.Result;
    using System;
    using utility;

    [TestFixture]
    public class BaseTest
    {
        protected string testClass;
        protected Driver _driver;
        protected Client clientData;

        [OneTimeSetUp]
        public void beforeClass()
        {
            _driver = new Driver();
            CreateReportingClient();
        }

        [TearDown]
        public void afterTest() 
        {                        
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Success)
            {
                _driver.Report.TestSuccess();
            }
            else
            {
                _driver.Report.TestFails(_driver.GetIntance());
            }

            _driver.GetIntance().CloseApp();
        }

        [OneTimeTearDown]
        public void afterClass()
        {
            _driver.Report.TestCaseEndReport();

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