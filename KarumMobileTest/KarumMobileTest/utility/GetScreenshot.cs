namespace utility
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using System;
    using System.IO;

    public class GetScreenshot
    {
        /// <summary>
        /// Capture a Screenshot from the device
        /// </summary>
        /// <param name="driver">AppiumDriver</param>
        /// <param name="screenshotName">Save File name</param>
        /// <returns>Saved full path File</returns>
        public static string capture(AppiumDriver<AppiumWebElement> driver, string screenshotName)
        {
            string filename = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            string.Format(screenshotName +
                          "_" +
                          "{0}.PNG", DateTime.Now.ToString("yyyy-MM-dd.HH.mm.ss")));
            Screenshot screenshot = driver.GetScreenshot();
            screenshot.SaveAsFile(filename, ScreenshotImageFormat.Png);
            return filename;
        }
    }
}