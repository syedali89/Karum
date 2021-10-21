namespace utility
{
    using System;
    using System.IO;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;

    public class GetScreenshot
    {
        public static string capture(AppiumDriver<AppiumWebElement> driver, string screenshotName)
        {
            string filename = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            string.Format(screenshotName +
                          "_" +
                          "{0}.png", DateTime.Today.ToString("YYYY-MM-dd-HH.mm.ss")));
            Screenshot screenshot = driver.GetScreenshot();
            screenshot.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
            return filename;
        }
    }
}