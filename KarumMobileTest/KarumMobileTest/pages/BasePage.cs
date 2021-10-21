using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using utility;

namespace pages 
{
    public class BasePage {
        public Driver _driver;
        public WebDriverWait wait;
        public Actions act;

        //By Generics
        public By documentBody = By.XPath("//android.view.View/android.widget.TextView");
        public By headerTitle = By.Id("com.karum.credits:id/tv_title_header");

        //Constructor
        public BasePage(Driver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(driver.GetIntance(), TimeSpan.FromSeconds(30));
            act = new Actions(driver.GetIntance());
            if (driver.GetDriverType().Equals(constants.IOS)) {
                //TODO IOS PATH document
                documentBody = By.XPath("TODO");
            }
        }

        public void grantAllPermissions()
        {
            if (_driver.GetRemoteState())
            {
                if (_driver.GetDriverType().Equals(constants.ANDROID))
                {
                    By allowButtonForeground = By.Id("com.android.permissioncontroller:id/permission_allow_foreground_only_button");
                    By allowButton = By.Id("com.android.permissioncontroller:id/permission_allow_button");

                    //TODO TEST SANGSUNG
                    while (validateElementVisible(allowButtonForeground))
                    {
                        clickElement(allowButtonForeground);
                    }

                    while (validateElementVisible(allowButton))
                    {
                        clickElement(allowButton);
                    }
                }
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
        protected void sendTextElement(By locator, String text)
        {
            waitVisibility(locator);
            _driver.GetIntance().FindElement(locator).SendKeys(text);
        }

        //Assert elements
        protected bool validateElementVisible(By locator)
        {
            bool elementVisible = true;

            try
            {
                waitVisibility(locator);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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

        protected void assertElementText(By locator, String text)
        {
            waitVisibility(locator);
            string textElement = _driver.GetIntance().FindElement(locator).Text;
            Assert.AreEqual(text, textElement, "Error, the expeted text was '" + text + "', but current text is '" + textElement + "'.");
        }

        protected void assertElementWithTextExist(String text)
        {
            By locator = By.XPath("//*[@text='" + text + "']");
            Assert.IsTrue(SwipeAction.swipeDownUntilElementText(_driver, text), "Error, there are not element with the text : '" + text + "'.");
            Assert.IsTrue(_driver.GetIntance().FindElement(locator).Displayed, "Error, element with the text : '" + text + "' is not visible on screem.");
        }

        //Evaluate if the official document text is equal to the document displayed on the app
        protected void assertDocumentText(string documentName, string documentFullText)
        {            
            string recoverFullText = "";
            bool notEndDocument = true;
            string lastText = "";

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

                foreach(AppiumWebElement docElement in bodyDocumentElements) {
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
    }
}