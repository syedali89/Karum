namespace utility 
{
    using System;
    using System.IO;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Enums;
    using OpenQA.Selenium.Appium.iOS;
    using System.Reflection;

    public class Driver 
    {       
        /// <summary>
        /// Contructor
        /// </summary>
        public Driver() 
        {
            var capabilities = new AppiumOptions();
            // 1. Replace <<cloud name>> with your perfecto cloud name (for example, 'demo' is the cloudName of demo.perfectomobile.com).
            string cloudName = "trial";

            // 2. Replace <<security token>> with your Perfecto security token.
            string securityToken =     "eyJhbGciOiJIUzI1NiIsInR5cCIgOiAiSldUIiwia2lkIiA6ICI2ZDM2NmJiNS01NDAyLTQ4MmMtYTVhOC1kODZhODk4MDYyZjIifQ.eyJpYXQiOjE2MzQwNTIwMzMsImp0aSI6ImE2MjdmMTgxLTIzNDItNGI0Ni1hMGU5LTAzYWVhYzEyZWVmMiIsImlzcyI6Imh0dHBzOi8vYXV0aDMucGVyZmVjdG9tb2JpbGUuY29tL2F1dGgvcmVhbG1zL3RyaWFsLXBlcmZlY3RvbW9iaWxlLWNvbSIsImF1ZCI6Imh0dHBzOi8vYXV0aDMucGVyZmVjdG9tb2JpbGUuY29tL2F1dGgvcmVhbG1zL3RyaWFsLXBlcmZlY3RvbW9iaWxlLWNvbSIsInN1YiI6ImJiZGE3NDJlLWIzNTMtNGI2ZC05NzQ5LTJjZmU0Y2FkMTY0NiIsInR5cCI6Ik9mZmxpbmUiLCJhenAiOiJvZmZsaW5lLXRva2VuLWdlbmVyYXRvciIsIm5vbmNlIjoiOGIwZGZlYTctMTc3Zi00NDFjLWI4YTEtNDlmMjk1ZDg2MGEwIiwic2Vzc2lvbl9zdGF0ZSI6IjZkNzgwNzc3LWI5OTYtNGNiMS1iOGNlLTQyNDZhOTI1YTE2ZSIsInNjb3BlIjoib3BlbmlkIG9mZmxpbmVfYWNjZXNzIHByb2ZpbGUgZW1haWwifQ.Hfps3Bp18N2wsitCOW4fMhnu6cDlvSNMfiYUYjvIDXA";
        
            capabilities.AddAdditionalCapability("securityToken", securityToken);
            capabilities.AddAdditionalCapability("newCommandTimeout", 60000);

            if (TEST_DEVISE.Equals(ANDROID)) {
                Uri url;

                if(REMOTEEXECUTION) 
                {                   
                    capabilities.AddAdditionalCapability("app",
                            "PRIVATE:Karum_Fase_2_Sprint_3_v1.10.5.apk");
                    capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName,
                            "99241FFAZ00HKL");

                    url = new Uri("https://" + cloudName.Replace(
                                    ".perfectomobile.com", "")
                                    + ".perfectomobile.com/nexperience/perfectomobile/wd/hub");
                }
                else 
                {
                    capabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AutoGrantPermissions, true);
                    capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName,
                            DEVICE_NAME_NAME);                   
                    string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..","..","..",
                        constants.APPVERSION_FOLDER, APPPATH_ANDROID));
                    capabilities.AddAdditionalCapability("app", path);

                    url = new Uri("http://localhost:4723/wd/hub");
                }

                capabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, APP_PACKAGE_NAME);
                capabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, APP_ACTIVITY_NAME);
                capabilities.AddAdditionalCapability(MobileCapabilityType.NoReset, false);

                capabilities.AddAdditionalCapability("enableAppiumBehavior", true);
                capabilities.AddAdditionalCapability("autoLaunch", true);
                capabilities.AddAdditionalCapability("autoInstrument", true);
                capabilities.AddAdditionalCapability("takesScreenshot", true);
                capabilities.AddAdditionalCapability("screenshotOnError", true);
                //capabilities.AddAdditionalCapability("fullReset", true);
                capabilities.AddAdditionalCapability("waitForAvailableLicense", true);
                capabilities.AddAdditionalCapability("sensorInstrument", true); 

                _driverandroid = new AndroidDriver<AppiumWebElement>(url, capabilities, TimeSpan.FromSeconds(240));
                _driver = _driverandroid;

                _driverType = ANDROID;                                
            }
            else if(TEST_DEVISE.Equals(IOS))
            {
                string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..",
                        constants.APPVERSION_FOLDER, APPPATH_IOS));
                capabilities.AddAdditionalCapability("app", path);
                capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, IOS);

                _driverios = new IOSDriver<AppiumWebElement>(new Uri("http://localhost:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(240));
                _driver = _driverios;
                _driverType = IOS;
            }

            _height = _driver.Manage().Window.Size.Height;
            _width = _driver.Manage().Window.Size.Width;
        }

        private AppiumDriver<AppiumWebElement> _driver;     
       
        private AndroidDriver<AppiumWebElement> _driverandroid;
        private IOSDriver<AppiumWebElement> _driverios;
        private string _driverType;
        private const bool REMOTEEXECUTION = false;
        private const string APP_PACKAGE_NAME = "com.karum.credits";
        private const string APP_ACTIVITY_NAME = "com.karum.credits.ui.SplashActivity";
        //private const string DEVICE_NAME_NAME = "ZY323V65L2";
        private const string DEVICE_NAME_NAME = "emulator-5554";
        private string TEST_DEVISE = "ANDROID";
        private const string ANDROID = "ANDROID";
        private const string IOS = "IOS";
        private const string APPPATH_IOS = "iosapp";
        private const string APPPATH_ANDROID = "Karum_Fase_2_Sprint_3_v1.10.6.apk";

        private int _height;
        private int _width;

        public int GetWindownSizeHeight()
        {
            return _height;
        }

        public int GetWindownSizeWidth()
        {
            return _width;
        }

        public bool GetRemoteState()
        {
            return REMOTEEXECUTION;
        }

        public AppiumDriver<AppiumWebElement> GetIntance() 
        {
            return _driver;
        }

        public AndroidDriver<AppiumWebElement> GetAndroidDriver() 
        {
            return _driverandroid;
        }

        public IOSDriver<AppiumWebElement> GetIOSDriver() 
        {
            return _driverios;
        }

        public string GetDriverType() 
        {
            return _driverType;
        }
    }
}