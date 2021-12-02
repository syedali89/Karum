namespace utility
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.MultiTouch;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Threading;
    using static constants;

    public class SwipeAction 
    {
        private const int MAX_INTENTS = 25;
        private const int ANIMATION_TIME = 200;

        /// <summary>
        /// Swipe Down until a element is visible on screen
        /// </summary>
        /// <param name="driver">Driver Object</param>
        /// <param name="locator">element path By object</param>
        /// <returns>Return true if element is visible, false if the element is not visible/non existing after rearching max number of intents</returns>
        public static bool swipeDownUntilElementExist(Driver driver, By locator)
        {
            #region Variables required for the Swipe Action
            int Height = driver.GetWindownSizeHeight();
            int Width = driver.GetWindownSizeWidth();

            int Starty = (int)(Height * 0.80);
            int Startx = Width / 2;
            int Endy = (int)(Height * 0.20);
            int Endx = Startx;
            int intents = 0;
            #endregion

            if (driver.GetDevice().Equals(OS.ANDROID))
            {
                #region Swipe Action in a Android Device
                while (driver.GetIntance().FindElements(locator).Count == 0 && intents < MAX_INTENTS)
                {
                    new TouchAction(driver.GetIntance())
                            .LongPress(Startx, Starty)
                            .Wait(100)
                            .MoveTo(Endx, Endy)
                            .Release().Perform();
                    intents++;
                }
                #endregion
            }
            else if (driver.GetDevice().Equals(OS.IOS))
            {
                #region Swipe Action in a IOS Device
                while (!driver.GetIntance().FindElement(locator).Displayed && intents < MAX_INTENTS)
                {
                    new TouchAction(driver.GetIntance())
                            .LongPress(Startx, Starty)
                            .Wait(100)
                            .MoveTo(Endx, Endy)
                            .Release().Perform();
                    intents++;
                }
                #endregion
            }

            return intents < MAX_INTENTS;
        }

        /// <summary>
        /// Swipe Down until a element with a specific text is visible on screen
        /// </summary>
        /// <param name="driver">Driver Object</param>
        /// <param name="text">element text value</param>
        /// <returns>Return true if element is visible, false if the element is not visible/non existing after rearching max number of intents</returns>
        public static bool swipeDownUntilElementText(Driver driver, string text)
        {
            if (driver.GetDevice().Equals(OS.ANDROID)) 
            {
                #region Android Swipe Down ultil element is visible 
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
                #endregion
            }

            else if (driver.GetDevice().Equals(OS.IOS))
            {
                #region IOS Swipe Down ultil element is visible 
                By pre = By.XPath(@"//*[@label='"+text+"']");
                
                Dictionary<string, string> scrollObject = new Dictionary<string, string>();
                scrollObject.Add("direction", "down");

                return ScrollIOSUntilElementVisible(driver, pre, scrollObject);
                #endregion
            }

            return true;
        }
        
        /// <summary>
        /// Swipe to a specific direction inside a element on screen
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <param name="direction"></param>
        public static void swipeDirectionFromElement(Driver driver, By locator, Direction direction)
        {
            #region Variables required with default values for the Swipe Action
            Point elementCordinates = driver.GetIntance().FindElement(locator).Location;
            Size elementSize = driver.GetIntance().FindElement(locator).Size;

            int Starty = 0;
            int Startx = 0;
            int Endy = 0;
            int Endx = 0;
            #endregion

            switch (direction)
            {
                case Direction.UP:
                    #region Set variable values for Swipe Up Action
                    if (driver.GetDevice().Equals(OS.ANDROID))
                    {
                        Starty = elementCordinates.Y + 10;
                        Endy = (int)((elementCordinates.Y + elementSize.Height) * 0.9);
                    }
                    else if (driver.GetDevice().Equals(OS.IOS))
                    {
                        Starty = (int)(elementSize.Height * 0.05);
                        Endy = (int)(elementSize.Height * 0.50);                        
                    }

                    Startx = elementCordinates.X + 10;
                    Endx = Startx;
                    break;
                    #endregion
                case Direction.DOWN:
                    #region Set variable values for Swipe Down Action
                    Starty = (int)(elementSize.Height * 0.80);
                    Startx = elementCordinates.X + 10;
                    Endy = (int)(elementSize.Height * 0.10);
                    Endx = Startx;
                    break;
                    #endregion
                case Direction.LEFT:
                case Direction.RIGHT:
                default:
                    throw new NotImplementedException();
            }

            new TouchAction(driver.GetIntance())
                .Press(Startx, Starty)
                .Wait(500)
                .MoveTo(Endx, Endy)
                .Release()
                .Perform();
        }

        /// <summary>
        /// Specific Scroll action for IOS 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <param name="scrollObject"></param>
        /// <returns>If element is visible return true, if element is not visible or not exist return false</returns>
        private static bool ScrollIOSUntilElementVisible(Driver driver, By locator, Dictionary<string, string> scrollObject)
        {
            #region Loop until element exist, if element never exist them return false 
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
            #endregion

            #region Scroll Down until element is visible on screen or max number intents reached
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
            #endregion
        }
    }
}