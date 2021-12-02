namespace pages
{
    using data;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using utility;

    public partial class FileApp : BasePage
    {
        //By
        public By BrowseButton = By.XPath("//*[@resource-id='com.google.android.documentsui:id/toolbar']//android.widget.ImageButton");
        public By DownloadFolder = By.XPath("//*[@resource-id='com.google.android.documentsui:id/roots_list']//*[@text='Downloads']");
        public By SearchArea = By.XPath("AndroidNull");

        public override void SetIOSBy()
        { 
            base.SetIOSBy();

            BrowseButton = By.XPath("//*[@label='Browse']");
            SearchArea = By.XPath("//*[@name='FullDocumentManagerViewControllerNavigationBarSearchFieldIdentifier']");
            DownloadFolder = By.XPath("//*[@name='Downloads, Folder']");
        }

        private By FileToFind(string partialFileName)
        {
            By fileBy = null;
            
            if (_driver.GetDevice().Equals(EnvironmentData.DEVICE.ANDROID))
            {
                fileBy = By.XPath(string.Format("//*[contains(@text, '{0}')]", partialFileName));    
            }
            else if (_driver.GetDevice().Equals(EnvironmentData.DEVICE.IOS))
            {
                fileBy = By.XPath(string.Format("//*[contains(@label, '{0}')]", partialFileName));
            }

            return fileBy;
        }
    }
}