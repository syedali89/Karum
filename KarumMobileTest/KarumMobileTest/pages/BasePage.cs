namespace pages
{
    using data;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.iOS.Enums;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;
    using System;
    using utility;
    using static constants;

    public class BasePage 
    {
        public Driver _driver;
        public WebDriverWait wait;
        public Actions act;

        //By Generics
        public By documentBody = By.XPath("//android.view.View/android.widget.TextView");
        public By headerTitle = By.Id("com.karum.credits:id/tv_title_header");
        public By backButton = By.Id("com.karum.credits:id/iv_home_back_header");
        public By clientNumber = By.Id("com.karum.credits:id/tv_credit_card_num_item");

        //DownMenu
        public By downMenuHome = By.Id("com.karum.credits:id/mainFragment");
        public By downMenuCredit = By.Id("com.karum.credits:id/creditsFragment");
        public By downMenuProfile = By.Id("com.karum.credits:id/menu_3");

        //Constructor
        public BasePage(Driver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(driver.GetIntance(), TimeSpan.FromSeconds(30));
            act = new Actions(driver.GetIntance());
            if (driver.GetDevice().Equals(OS.IOS))
            {
                SetIOSBy();                
            }
        }

        public virtual void SetIOSBy()
        {            
            headerTitle = By.XPath("//XCUIElementTypeOther[1]/XCUIElementTypeOther[1]/XCUIElementTypeOther[1]/XCUIElementTypeOther[1]/XCUIElementTypeStaticText");
            downMenuHome = By.XPath("//XCUIElementTypeTabBar/XCUIElementTypeButton[1]");
            downMenuCredit = By.XPath("//XCUIElementTypeTabBar/XCUIElementTypeButton[2]");
            downMenuProfile = By.XPath("//XCUIElementTypeTabBar/XCUIElementTypeButton[3]");
            clientNumber = By.XPath("//XCUIElementTypeStaticText[contains(@label, '**********')]");
            backButton = By.XPath("//*[@label='ic back KARUM']");
            documentBody = By.XPath("//XCUIElementTypeTextView");
        }

        public void tapGoBack()
        {
            clickElement(backButton);
        }

        public void tapGoHomeDownMenu()
        {
            clickElement(downMenuHome);
        }

        public void tapGoCreditDownMenu()
        {
            clickElement(downMenuCredit);
        }

        public void grantAllPermissions()
        {
            if (_driver.GetRemoteState())
            {
                wait.Timeout = TimeSpan.FromSeconds(5);

                if (_driver.GetDevice().Equals(OS.ANDROID))
                {
                    By allowButtonForeground = By.Id("com.android.permissioncontroller:id/permission_allow_foreground_only_button");
                    By allowButton = By.Id("com.android.permissioncontroller:id/permission_allow_button");

                    while (validateElementVisible(allowButtonForeground))
                    {
                        clickElement(allowButtonForeground);
                    }

                    while (validateElementVisible(allowButton))
                    {
                        clickElement(allowButton);
                    }
                }
                if (_driver.GetDevice().Equals(OS.IOS))
                {
                    By allowButton = By.XPath("//*[@label='Always Allow']");
                    By OkButton = By.XPath("//*[@label='OK']");
                    
                    while (validateElementVisible(allowButton))
                    {
                        clickElement(allowButton);
                    }                                                                                
                    while (validateElementVisible(OkButton))
                    {
                        clickElement(OkButton);
                    }
                }

                wait.Timeout = TimeSpan.FromSeconds(30);
            }
        }

        //Wait Element is Visible
        protected void waitVisibility(By locator)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
        }

        //Wait Element is not Visible
        protected void waitNotVisibility(By locator)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        //Click
        protected void clickElement(By locator)
        {
            waitVisibility(locator);
            _driver.GetIntance().FindElement(locator).Click();
        }

        //SendKey
        protected void sendTextElement(By locator, string text)
        {
            waitVisibility(locator);

            var sendkeyElement = _driver.GetIntance().FindElement(locator);
            sendkeyElement.SendKeys(text);

            if (_driver.GetDevice().Equals(OS.IOS))
            {
                _driver.GetIOSDriver().HideKeyboard(HideKeyboardStrategy.Tap_outside);
                
                if (_driver.GetIOSDriver().IsKeyboardShown())
                {
                    _driver.GetIOSDriver().HideKeyboard(HideKeyboardStrategy.Press_key, "Done");
                }
                if (_driver.GetIOSDriver().IsKeyboardShown())
                {
                    sendkeyElement.SendKeys(Keys.Enter);
                }
                if (_driver.GetIOSDriver().IsKeyboardShown())
                {
                    clickElement(By.XPath("//XCUIElementTypeStaticText[@hittable='true']"));
                }
            }
        }

        //Recover Text
        protected string getTextElement(By locator)
        {
            Assert.IsTrue(SwipeAction.swipeDownUntilElementExist(_driver, locator), "Error, trying to recover element text.");
            return _driver.GetIntance().FindElement(locator).Text;
        }

        //Assert elements
        protected bool validateElementVisible(By locator)
        {
            bool elementVisible = true;

            try
            {
                waitVisibility(locator);
            }
            catch (Exception)
            {
                elementVisible = false;
            }

            return elementVisible;
        }

        protected bool validateElementEnable(By locator)
        {
            if (SwipeAction.swipeDownUntilElementExist(_driver, locator))
            {                
                return _driver.GetIntance().FindElement(locator).Enabled;
            }
            else
            {
                return false;
            }
        }

        protected void verifyButtonMenuScreen(DownMenuSelected menuSelected)
        {
            Assert.IsTrue(validateElementVisible(downMenuHome), "Error, down menu home button is not visible");
            Assert.IsTrue(validateElementVisible(downMenuCredit), "Error, down menu credit button is not visible");
            Assert.IsTrue(validateElementVisible(downMenuProfile), "Error, down menu profile button is not visible");

            By elementSelected = null;

            if (menuSelected.Equals(DownMenuSelected.HOME))
            {
                elementSelected = downMenuHome;
            }
            else if (menuSelected.Equals(DownMenuSelected.CREDIT))
            {
                elementSelected = downMenuCredit;
            }

            Assert.IsTrue(_driver.GetIntance().FindElement(elementSelected).Selected, "Error, The expected down menu element '" + menuSelected.ToString() + "' is not Selected");
        }        
        
        protected void verifyCreditoKarumNumber(Client clientData)
        {
            assertElementWithTextExist("Crédito Karum");
            assertElementText(clientNumber, "************" + clientData.getLastCreditNumber());
        }        

        protected void assertElementText(By locator, string text)
        {
            string textElement = getTextElement(locator);
            Assert.AreEqual(text, textElement, "Error, the expected text was '" + text + "', but current text is '" + textElement + "'.");
        }

        protected void assertElementText(AppiumWebElement element, string text)
        {
            string textElement = element.Text;
            Assert.AreEqual(text, textElement, "Error, the expected text was '" + text + "', but current text is '" + textElement + "'.");
        }

        protected void assertTextContains(By locator, string textexpected)
        {
            string textcompare = getTextElement(locator);
            assertTextContains(textcompare, textexpected);
        }

        protected void assertTextContains(string textcompare, string textexpected)
        {
            Assert.IsTrue(textcompare.Contains(textexpected), "Error, the element text '" + textcompare + "' not contains '" + textexpected + "'");
        }

        protected void assertElementWithTextExist(string text)
        {
            By locator = null;

            if (_driver.GetDevice().Equals(OS.ANDROID))
            {
                locator = By.XPath("//*[@text='" + text + "']");
            }
            else if (_driver.GetDevice().Equals(OS.IOS))
            {
                locator = By.XPath("//*[@label='" + text + "']");
            }            
            
            Assert.IsTrue(SwipeAction.swipeDownUntilElementText(_driver, text), "Error, there are not element with the text : '" + text + "'.");
            Assert.IsTrue(_driver.GetIntance().FindElement(locator).Displayed, "Error, element with the text : '" + text + "' is not visible on screem.");
        }

        //Evaluate if the official document text is equal to the document displayed on the app
        protected void assertDocumentText(string documentName, string documentFullText)
        {            
            string recoverFullText = "";
            bool notEndDocument = true;
            string lastText = "";

            if (_driver.GetDevice().Equals(OS.ANDROID))
            {
                while (notEndDocument)
                {
                    waitVisibility(documentBody);
                    string lastTextDisplayed;
                    var bodyDocumentElements = _driver.GetIntance().FindElements(documentBody);

                    if (bodyDocumentElements[bodyDocumentElements.Count - 1].Text.Equals(String.Empty))
                    {
                        lastTextDisplayed = bodyDocumentElements[bodyDocumentElements.Count - 2].Text;
                    }
                    else
                    {
                        lastTextDisplayed = bodyDocumentElements[bodyDocumentElements.Count - 1].Text;
                    }

                    if (lastTextDisplayed.Equals(lastText))
                    {
                        notEndDocument = false;
                        continue;
                    }

                    foreach (AppiumWebElement docElement in bodyDocumentElements)
                    {
                        recoverFullText = recoverFullText + docElement.Text + "\n";

                        Assert.IsTrue(
                                documentFullText.Contains(docElement.Text),
                                "Error, in validation of document " + documentName +
                                        ", official document : \nSTART DOCUMENT '" + documentFullText + "'\nEND OFFICIAL DOCUMENT " +
                                        "\nAnd recover from app document: START DOCUMENT '" + recoverFullText + "'\nEND RECOVER DOCUMENT" +
                                        "\nDONT MATCH. \n*Document recover could be incomplete because stop when some line is different from official.");
                    }

                    lastText = lastTextDisplayed;
                }
            }
            else
            {
                var bodyDocumentText = _driver.GetIntance().FindElement(documentBody).Text;

                Assert.IsTrue(documentFullText.Equals(bodyDocumentText),
                    "Error, in validation of document " + documentName +
                    ", official document : \nSTART DOCUMENT '" + documentFullText + "'\nEND OFFICIAL DOCUMENT " +
                    "\nAnd recover from app document: START DOCUMENT '" + bodyDocumentText + "'\nEND RECOVER DOCUMENT" +
                    "\nDONT MATCH.");
            }
        }
    }
}