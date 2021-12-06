namespace utility
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Collections.ObjectModel;
    using System.Threading;

    public class DriverChrome 
    {
        public IWebDriver webdriver;
        public WebDriverWait webdriverwait;

        /// <summary>
        /// Contructor Create a Instance of Chrome Driver for WebScraping
        /// </summary>
        public DriverChrome() 
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--window-size=1920,1080");
            options.AddArguments("--incognito");
            webdriver = new ChromeDriver(options);
            webdriverwait = new WebDriverWait(webdriver, TimeSpan.FromMinutes(5));
        }

        [Obsolete]
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

        [Obsolete]
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
        
        /// <summary>
        /// Wait ultil a element is visible on screen, then return the element
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        public IWebElement ReturnElement(By locator) 
        {
            var elements = webdriverwait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));

            return elements[0];
        }

        public ReadOnlyCollection<IWebElement> ReturnListElement(By locator)
        {
            var elements = webdriverwait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));

            return elements;
        }

        public void ClickElement(By locator)
        {
            var element = ReturnElement(locator);
            element.Click();
        }

        public void SendKeyElement(By locator, string text)
        {
            var element = ReturnElement(locator);
            element.SendKeys(text);
        }

        public void KillSession()
        {
            webdriver.Close();
            webdriver.Quit();
        }
    }
}