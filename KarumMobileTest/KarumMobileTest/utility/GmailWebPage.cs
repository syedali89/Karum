namespace utility
{
    using data;
    using OpenQA.Selenium;

    public class GmailWebPage
    {
        public DriverChrome driver;
        private Client clientData;

        By LogINPage = By.CssSelector("a[data-action='sign in']");
        By UserInput = By.Id("identifierId");
        By NextButtonEmail = By.CssSelector("div#identifierNext button");
        By PassInput = By.CssSelector("input[name='password']");
        By NextButtonPassword = By.CssSelector("div#passwordNext button");
        By FirstNewMail = By.CssSelector("table[id*='2a'] tr.zE");
        By ListSameMails = By.CssSelector("div[role='listitem']");
        /// <summary>
        /// Contructor
        /// </summary>
        public GmailWebPage(DriverChrome driver, Client clientData) 
        {
            this.driver = driver;
            this.clientData = clientData;
            driver.webdriver.Navigate().GoToUrl("https://www.gmail.com");            
        }

        public void LogINGmail(string user, string pass)
        {
            if (driver.webdriver.FindElements(LogINPage).Count > 0)
            {
                driver.ClickElement(LogINPage);
            }

            driver.SendKeyElement(UserInput, user);
            driver.ClickElement(NextButtonEmail);
            driver.SendKeyElement(PassInput, pass);
            driver.ClickElement(NextButtonPassword);
        }

        public string GetMailMessage()
        {
            driver.ClickElement(FirstNewMail);

            foreach (var mail in driver.ReturnListElement(ListSameMails))
            {
                mail.Click();
            }

            By lastCode = By.XPath(string.Format("(//p/span[contains(text(),'{0} {1}')]/../../..//p[contains(@style, 'color')])[last()]", clientData.firstNameOne, clientData.lastNameOne));

            return driver.ReturnElement(lastCode).Text;
        }        
    }
}