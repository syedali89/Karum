namespace utility
{
    using NUnit.Framework;
    using OpenQA.Selenium.Appium;
    using Reportium.Client;
    using Reportium.Test.Result;
    using System;
    using static constants;

    /// <summary>
    /// Tool use for Reporting on Perfecto or Console writing on local 
    /// </summary>
    public class ReportTool
    {
        public ReportiumClient reportiumClient;
        private bool remote;
        private string device;
        
        public ReportTool(bool remote, string device, ReportiumClient reportiumClient)
        {
            this.remote = remote;
            this.device = device;
            this.reportiumClient = reportiumClient;
        }

        public ReportTool(bool remote, string device)
        {
            this.remote = remote;
            this.device = device;
        }

        public void TestCaseStartReport()
        {
            if (remote)
            {
                reportiumClient.TestStart(TestContext.CurrentContext.Test.Name, new Reportium.Test.TestContext("Device: " + device));
            }
            else
            {
                Console.WriteLine("TestCase: " + TestContext.CurrentContext.Test.Name + "\nDevice: " + device);
            }
        }

        /// <summary>
        /// Description of the Specific Step executed
        /// </summary>
        /// <param name="step"></param>
        public void StepDescription(string step)
        {
            if (remote)
            {
                reportiumClient.StepStart(step);
            }
            else
            {
                Console.WriteLine("Step:" + step);
            }
        }

        /// <summary>
        /// End of the current Step
        /// </summary>
        public void EndStep()
        {
            if (remote)
            {
                reportiumClient.StepEnd();
            }
        }

        public void TestCaseEndReport()
         {
            if (remote && reportiumClient != null)
            {
                try
                {
                    var url = reportiumClient.GetReportUrl();
                    Console.WriteLine(url);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }
        
        /// <summary>
        /// Test Success Actions
        /// </summary>
        public void TestSuccess()
        {
            if (remote)
            {
                reportiumClient.TestStop(TestResultFactory.CreateSuccess());
            }
        }

        /// <summary>
        /// Fail test Actions
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="ex"></param>
        public void TestFails(AppiumDriver<AppiumWebElement> driver, Exception ex)
        {
            string path = string.Empty;
            if (remote)
            {
                #region Mark the test as failed on Perfecto Report
                reportiumClient.StepEnd("Step end because test fail");
                
                string message = TestContext.CurrentContext.Result.Message + ". Stack Trace:" + TestContext.CurrentContext.Result.StackTrace;

                if (ex.Message.Equals(ERROR_RECOVERING_SECURITY_CODE))
                {
                    reportiumClient.TestStop(TestResultFactory.CreateFailure(message, ex, "98WKBTwi70"));
                }
                else
                {
                    reportiumClient.TestStop(TestResultFactory.CreateFailure(message));
                }
                #endregion
            }
            else
            {
                #region Take a Screenshot of the error in Local
                try
                {
                    path = GetScreenshot.capture(driver, TestContext.CurrentContext.Test.Name);
                    Console.WriteLine("Screenshot='" + path + "'");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                #endregion
            }
        }
    }
}