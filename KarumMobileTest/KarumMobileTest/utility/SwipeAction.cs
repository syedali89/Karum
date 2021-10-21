namespace utility
{
    using System;
    using System.Drawing;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.MultiTouch;

    public class SwipeAction 
    {
        public static bool swipeDownUntilElementExist(Driver driver, By locator)
        {
            int Height = driver.GetWindownSizeHeight();
            int Width = driver.GetWindownSizeWidth();

            int Starty = (int)(Height * 0.80);
            int Startx = Width / 2;
            int Endy = (int)(Height * 0.20);
            int Endx = Startx;

            int intents = 0;

            while (driver.GetIntance().FindElements(locator).Count == 0 && intents < 100)
            {
                intents++;
                new TouchAction(driver.GetIntance())
                        .LongPress(Startx, Starty)
                        .Wait(100)
                        .MoveTo(Endx, Endy)
                        .Release().Perform();
            }

            return intents < 100;
        }

        public static bool swipeDownUntilElementText(Driver driver, string text)
        {
            if (driver.GetDriverType().Equals(constants.ANDROID)) 
            {
                try 
                {
                    string mySelector = "new UiSelector().text(\"" + text + "\").instance(0)";
                    string command = "new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollIntoView(" + mySelector + ");";
                    driver.GetAndroidDriver().FindElementByAndroidUIAutomator(command);
                } 
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            else if (driver.GetDriverType().Equals(constants.IOS)) 
            {
                try 
                {
                    ///TODO IOS
                } 
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            return true;
        }

        public static void swipeToRightFromElement(Driver driver, By locator) 
        {
            Point elementCordinates = driver.GetIntance().FindElement(locator).Location;

            int Starty = elementCordinates.Y;
            int Startx = elementCordinates.X;
            int Endy = Starty;
            int Endx = Startx + 200;

            new TouchAction(driver.GetIntance())
                    .LongPress(Startx, Starty)
                    .Wait(100)
                    .MoveTo(Endx, Endy)
                    .Release().Perform();
        }

        public static void swipeToDown(Driver driver) 
        {
            int Height = driver.GetWindownSizeHeight();
            int Width = driver.GetWindownSizeWidth();

            int Starty = Height / 2;
            int Startx = Width / 2;
            int Endy = Starty / 2;
            int Endx = Startx;

            new TouchAction(driver.GetIntance())
                     .LongPress(Startx, Starty)
                    .Wait(100)
                    .MoveTo(Endx, Endy)
                    .Release().Perform();
        }
    }
}