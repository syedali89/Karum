namespace tests
{
    using data;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using System;
    using utility;

    [TestFixture]
    public class BaseTest
    {
        protected Driver _driver;
        protected Client clientData;

        [OneTimeSetUp]
        public void beforeClass()
        {
            _driver = new Driver();
            _driver.GetIntance().CloseApp();
        }

        [TearDown]
        public void afterTest() 
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success) {
                Console.WriteLine("ERROR FATAL");
                try 
                {
                    string path = GetScreenshot.capture(_driver.GetIntance(), TestContext.CurrentContext.Test.Name);
                    Console.WriteLine("Screenshot='" + path +"'");
                } 
                catch (Exception e) 
                {
                    Console.WriteLine(e.Message);
                }
            }

            _driver.GetIntance().CloseApp();
        }

        [OneTimeTearDown]
        public void afterClass() 
        {
            if(_driver != null) 
            {
                _driver.GetIntance().Quit();
            }
        }
    }
}