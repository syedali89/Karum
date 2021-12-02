namespace utility
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Threading;

    public class WebScrap 
    {
        private IWebDriver webdriver;
        private WebDriverWait webdriverwait;

        /// <summary>
        /// Contructor Create a Instance of Chrome Driver for WebScraping
        /// </summary>
        public WebScrap() 
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--headless");
            options.AddArguments("--window-size=1920,1080");
            webdriver = new ChromeDriver(options);
            webdriverwait = new WebDriverWait(webdriver, TimeSpan.FromMinutes(5));
        }

        /// <summary>
        /// Recover the text/Attribute value from a Element
        /// </summary>
        /// <param name="url">URL webpage</param>
        /// <param name="pathElementData">Element By object</param>
        /// <param name="attributeToRecover">the name of the element Attribute what value is going to be recover. If is Empty the element text is going to be recover</param>
        /// <param name="Iframe">In case is necesary to change Iframe. OPTIONAL</param>
        /// <returns>Element attribute value</returns>
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

        /// <summary>
        /// Wait until a element is visible on Screen
        /// </summary>
        /// <param name="url">URL webpage</param>
        /// <param name="locator">By to find the element</param>
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