using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Threading;

namespace utility
{
    public class WebScrap 
    {
        private IWebDriver webdriver;
        private WebDriverWait webdriverwait;

        /// <summary>
        /// Contructor
        /// </summary>
        public WebScrap() 
        {
            //Path file = Path("chromedriver.exe");
            //System.setProperty("webdriver.chrome.driver", file.getAbsolutePath());
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--headless");
            options.AddArguments("--window-size=1920,1080");
            webdriver = new ChromeDriver(options);
            webdriverwait = new WebDriverWait(webdriver, TimeSpan.FromSeconds(120));
        }

        public string RecoverDataElementPage(
                string url, By pathElementData, string attributeToRecover, string Iframe = "") 
        {
            string returnData = "";

            try {
                webdriver.Navigate().GoToUrl(url);
                Thread.Sleep(1000);
                if (!Iframe.Equals(string.Empty)) {
                    webdriverwait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id(Iframe)));
                }

                webdriverwait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(pathElementData));
                IWebElement pageElement = webdriver.FindElement(pathElementData);

                if (attributeToRecover.Equals(string.Empty)) 
                {
                    returnData = pageElement.Text;
                }
                else 
                {
                    returnData = pageElement.GetAttribute(attributeToRecover);
                }
            }
            catch (Exception exception) 
            {
                Console.WriteLine(exception.Message);
            }

            return returnData;
        }

        public void waitElementExist(string url, By locator) 
        {
            webdriver.Navigate().GoToUrl(url);
            webdriverwait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
        }

        public void KillSession()
        {
            webdriver.Close();
            webdriver.Quit();
        }
    }
}