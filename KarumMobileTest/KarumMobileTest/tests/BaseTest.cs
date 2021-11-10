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
        private ReportiumClient reportiumClient;

        [OneTimeSetUp]
        public void beforeClass()
        {
            _driver = new Driver();
            CreateReportingClient();
            _driver.GetIntance().CloseApp();
        }

        [TearDown]
        public void afterTest() 
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Success)
            {
                if (_driver.GetRemoteState())
                {
                    reportiumClient.TestStop(TestResultFactory.CreateSuccess());
                }
            }
            else
            {
                string path = string.Empty;

                try 
                {
                    path = GetScreenshot.capture(_driver.GetIntance(), TestContext.CurrentContext.Test.Name);
                    Console.WriteLine("Screenshot='" + path +"'");
                } 
                catch (Exception e) 
                {
                    Console.WriteLine(e.Message);
                }

                if (_driver.GetRemoteState())
                {
                    string message = TestContext.CurrentContext.Result.Message + ". Stack Trace:" + TestContext.CurrentContext.Result.StackTrace;

                    reportiumClient.TestStop(TestResultFactory.CreateFailure(message));
                }
            }

            _driver.GetIntance().CloseApp();
        }

        [OneTimeTearDown]
        public void afterClass()
        {
            if (_driver.GetRemoteState())
            {
                try
                {
                    var url = reportiumClient.GetReportUrl();
                    Console.WriteLine(url);

                    //Optional open browser after test finished: 
                    System.Diagnostics.Process.Start(url.ToString());

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }

            if (_driver != null) 
            {
                _driver.GetIntance().Quit();
            }
        }

        private void CreateReportingClient()
        {
            PerfectoExecutionContext perfectoExecutionContext = new PerfectoExecutionContext.PerfectoExecutionContextBuilder()
                .WithProject(new Project("KarumAutomationMobile", "v1.0"))
                .WithContextTags(new[] { testClass, _driver.GetDriverType().ToString() })
                .WithJob(new Job("Karum Mobile Automation", 1))
                .WithWebDriver(_driver.GetIntance())
                .Build();
            reportiumClient = PerfectoClientFactory.CreatePerfectoReportiumClient(perfectoExecutionContext);
        }

        public void TestCaseStartReport()
        {
            if (_driver.GetRemoteState())
            {
                reportiumClient.TestStart(TestContext.CurrentContext.Test.Name, new Reportium.Test.TestContext("Device: " + _driver.GetDriverType().ToString()));
            }
        }

        public void StepDescription(string step)
        {
            if (_driver.GetRemoteState())
            {
                reportiumClient.StepStart(step);
            }
        }
    }
}