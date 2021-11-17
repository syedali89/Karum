namespace utility
{
    using NUnit.Framework;
    using OpenQA.Selenium.Appium;
    using Reportium.Client;
    using Reportium.Model;
    using Reportium.Test.Result;
    using System;

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

                    //Optional open browser after test finished: 
                    System.Diagnostics.Process.Start(url.ToString());

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }
        
        public void TestSuccess()
        {
            if (remote)
            {
                reportiumClient.TestStop(TestResultFactory.CreateSuccess());
            }
        }

        public void TestFails(AppiumDriver<AppiumWebElement> driver)
        {
            string path = string.Empty;
            if (remote)
            {
                reportiumClient.StepEnd("Step end because test fail");
                
                string message = TestContext.CurrentContext.Result.Message + ". Stack Trace:" + TestContext.CurrentContext.Result.StackTrace;

                reportiumClient.TestStop(TestResultFactory.CreateFailure(message));
            }
            else
            {
                try
                {
                    path = GetScreenshot.capture(driver, TestContext.CurrentContext.Test.Name);
                    Console.WriteLine("Screenshot='" + path + "'");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }            
        }
    }
}