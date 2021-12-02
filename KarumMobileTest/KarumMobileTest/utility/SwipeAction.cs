namespace utility
{
    using System;
    using System.Drawing;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.MultiTouch;
    using static constants;
    using data;
    using System.Collections.Generic;
    using System.Threading;

    public class SwipeAction 
    {
        private const int MAX_INTENTS = 25;
        private const int ANIMATION_TIME = 200;

        public static bool swipeDownUntilElementExist(Driver driver, By locator)
        {
            int Height = driver.GetWindownSizeHeight();
            int Width = driver.GetWindownSizeWidth();

            int Starty = (int)(Height * 0.80);
            int Startx = Width / 2;
            int Endy = (int)(Height * 0.20);
            int Endx = Startx;
            int intents = 0;

            if (driver.GetDevice().Equals(EnvironmentData.DEVICE.ANDROID))
            {
                while (driver.GetIntance().FindElements(locator).Count == 0 && intents < MAX_INTENTS)
                {
                    new TouchAction(driver.GetIntance())
                            .LongPress(Startx, Starty)
                            .Wait(100)
                            .MoveTo(Endx, Endy)
                            .Release().Perform();
                    intents++;
                }
            }
            else if (driver.GetDevice().Equals(EnvironmentData.DEVICE.IOS))
            {
                while (!driver.GetIntance().FindElement(locator).Displayed && intents < MAX_INTENTS)
                {
                    new TouchAction(driver.GetIntance())
                            .LongPress(Startx, Starty)
                            .Wait(100)
                            .MoveTo(Endx, Endy)
                            .Release().Perform();
                    intents++;
                }
            }
            
            return intents < MAX_INTENTS;
        }

        public static bool swipeDownUntilElementText(Driver driver, string text)
        {
            if (driver.GetDevice().Equals(EnvironmentData.DEVICE.ANDROID)) 
            {
                try 
                {
                    string mySelector = "new UiSelector().text(\"" + text + "\").instance(0)";
                    string command = "new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollIntoView(" + mySelector + ");";
                    driver.GetAndroidDriver().FindElementByAndroidUIAutomator(command);
                    return true;
                } 
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }

            else if (driver.GetDevice().Equals(EnvironmentData.DEVICE.IOS))
            {
                By pre = By.XPath(@"//*[@label='"+text+"']");
                
                Dictionary<string, string> scrollObject = new Dictionary<string, string>();
                scrollObject.Add("direction", "down");

                return ScrollIOSUntilElementVisible(driver, pre, scrollObject);
            }

            return true;
        }

        public static void swipeDirectionFromElement(Driver driver, By locator, Direction direction)
        {            
            Point elementCordinates = driver.GetIntance().FindElement(locator).Location;
            Size elementSize = driver.GetIntance().FindElement(locator).Size;

            int Starty = 0;
            int Startx = 0;
            int Endy = 0;
            int Endx = 0;

            Dictionary<string, string> scrollObject = new Dictionary<string, string>();

            switch (direction)
            {
                case Direction.UP:
                    //Starty = elementCordinates.Y + 10;
                    //Startx = elementCordinates.X + 10;
                    //Endy = (int)((elementCordinates.Y + elementSize.Height) * 0.9);
                    //Endx = Startx;
                    if (driver.GetDevice().Equals(EnvironmentData.DEVICE.ANDROID))
                    {
                        Starty = elementCordinates.Y + 10;
                        Endy = (int)((elementCordinates.Y + elementSize.Height) * 0.9);
                    }
                    else if (driver.GetDevice().Equals(EnvironmentData.DEVICE.IOS))
                    {
                        Starty = (int)(elementSize.Height * 0.05);
                        Endy = (int)(elementSize.Height * 0.50);                        
                    }

                    Startx = elementCordinates.X + 10;
                    Endx = Startx;
                    break;
                case Direction.DOWN:
                    Starty = (int)(elementSize.Height * 0.80);
                    Startx = elementCordinates.X + 10;
                    Endy = (int)(elementSize.Height * 0.10);
                    Endx = Startx;
                    break;
                case Direction.LEFT:
                case Direction.RIGHT:
                default:
                    break;
            }

            ///Testing
            

            //scrollObject.Add("direction", "up");

            new TouchAction(driver.GetIntance())
                .Press(Startx, Starty)
                .Wait(500)
                .MoveTo(Endx, Endy)
                .Release()
                .Perform();

            //driver.GetIOSDriver().ExecuteScript("mobile: scroll", scrollObject);
        }

        private static bool ScrollIOSUntilElementVisible(Driver driver, By locator, Dictionary<string, string> scrollObject)
        {
            int intents = 0;

            while (driver.GetIOSDriver().FindElements(locator).Count == 0)
            {
                Thread.Sleep(500);
                if (intents > MAX_INTENTS)
                {
                    return false;
                }
                intents++;
            }

            intents = 0;

            while (!driver.GetIOSDriver().FindElement(locator).Displayed && intents < MAX_INTENTS)
            {
                try
                {
                    driver.GetIOSDriver().ExecuteScript("mobile: scroll", scrollObject);
                    Thread.Sleep(ANIMATION_TIME);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }

            return driver.GetIntance().FindElement(locator).Displayed;
        }
    }
}