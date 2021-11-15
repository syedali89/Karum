namespace utility
{
    using System;
    using System.Drawing;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.MultiTouch;
    using static constants;
    using data;

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
            if (driver.GetDevice().Equals(EnvironmentData.DEVICE.ANDROID)) 
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
            else if (driver.GetDevice().Equals(EnvironmentData.DEVICE.IOS))
            {
                try 
                {
                    ///TODO IOS
                    throw new NotImplementedException();
                } 
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
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

            switch (direction)
            {
                case Direction.UP:
                    Starty = elementCordinates.Y + 10;
                    Startx = elementCordinates.X + 10;
                    Endy = (int)((elementCordinates.Y + elementSize.Height) * 0.9);
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
                    Starty = elementCordinates.Y;
                    Startx = elementCordinates.X;
                    Endy = Starty;
                    Endx = Startx;
                    break;
            }

            new TouchAction(driver.GetIntance())
                    .Press(Startx, Starty)
                    .Wait(500)
                    .MoveTo(Endx, Endy)
                    .Release()
                    .Perform();
        }
    }
}