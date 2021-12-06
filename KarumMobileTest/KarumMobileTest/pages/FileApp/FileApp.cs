namespace pages
{
    using data;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using System;
    using utility;
    using static constants;

    /// <summary>
    /// This Page Object exist for the sole porpuse of verify if documents if files App
    /// </summary>
    public partial class FileApp : BasePage
    {
        private string IOSAppBundleID = "com.apple.DocumentsApp";
        private string AndroidAppPackage = "com.google.android.documentsui";
        private string AndroidAppActivity = "com.android.documentsui.files.FilesActivity";

        //Contructor
        public FileApp(Driver driver) : base(driver)
        {
            if (_driver.GetDevice().Equals(OS.IOS))
            {
                _driver.LaunchNewApp(IOSAppBundleID);
            }
            else if (_driver.GetDevice().Equals(OS.ANDROID))
            {
                _driver.LaunchNewApp(AndroidAppPackage, AndroidAppActivity);
            }
        }

        public AppiumWebElement CheckDownloadDocument(string partialname)
        {
            if (_driver.GetDevice().Equals(OS.ANDROID))
            {
                clickElement(BrowseButton);
                clickElement(DownloadFolder);
            }
            else if (_driver.GetDevice().Equals(OS.IOS))
            {
                if (_driver.GetIntance().FindElements(By.XPath("//*[@name='FullDocumentManagerViewControllerNavigationBar']//*[@label='Downloads']))")).Count <= 0)
                {
                    clickElement(BrowseButton);
                    sendTextElement(SearchArea, "KARUM");
                }
            }            

            AppiumWebElement returnElement = null;

            try
            {
                waitVisibility(FileToFind(partialname));
                returnElement = _driver.GetIntance().FindElement(FileToFind(partialname));
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);
                returnElement = null;
            }

            return returnElement;
        }
    }
}