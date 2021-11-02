namespace utility 
{
    using System;
    using System.IO;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Enums;
    using OpenQA.Selenium.Appium.iOS;
    using System.Reflection;
    using static constants;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using OpenQA.Selenium.Appium.Service.Options;
    using OpenQA.Selenium.Appium.Service;

    public class Driver 
    {       
        /// <summary>
        /// Contructor
        /// </summary>
        public Driver() 
        {
            _appiumOptions = new AppiumOptions();
            _appiumOptions.AddAdditionalCapability("newCommandTimeout", 60000);
            _appiumOptions.AddAdditionalCapability("disableWindowAnimation", true);

            if (TEST_DEVISE.Equals(ANDROID)) {

                Uri url = this.URLPathConfig();                

                _appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, APP_PACKAGE_NAME);
                _appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, APP_ACTIVITY_NAME);
                _appiumOptions.AddAdditionalCapability(MobileCapabilityType.NoReset, false);

                _appiumOptions.AddAdditionalCapability("enableAppiumBehavior", true);
                _appiumOptions.AddAdditionalCapability("autoLaunch", true);
                _appiumOptions.AddAdditionalCapability("autoInstrument", true);
                _appiumOptions.AddAdditionalCapability("takesScreenshot", true);
                _appiumOptions.AddAdditionalCapability("screenshotOnError", true);
                _appiumOptions.AddAdditionalCapability("automationName", "uiautomator2");                
                
                _appiumOptions.AddAdditionalCapability("waitForAvailableLicense", true);
                _appiumOptions.AddAdditionalCapability("sensorInstrument", true); 

                _driverandroid = new AndroidDriver<AppiumWebElement>(url, _appiumOptions, TimeSpan.FromSeconds(240));
                _driver = _driverandroid;

                _driverType = ANDROID;                                
            }
            else if(TEST_DEVISE.Equals(IOS))
            {
                string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..",
                        constants.APPVERSION_FOLDER, APPPATH_IOS));
                _appiumOptions.AddAdditionalCapability("app", path);
                _appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, IOS);

                _driverios = new IOSDriver<AppiumWebElement>(new Uri("http://localhost:4723/wd/hub"), _appiumOptions, TimeSpan.FromSeconds(240));
                _driver = _driverios;
                _driverType = IOS;
            }

            _height = _driver.Manage().Window.Size.Height;
            _width = _driver.Manage().Window.Size.Width;
        }

        private AppiumDriver<AppiumWebElement> _driver;            
        private AndroidDriver<AppiumWebElement> _driverandroid;
        private IOSDriver<AppiumWebElement> _driverios;
        private AppiumOptions _appiumOptions;
        private string _driverType;
        private const bool REMOTEEXECUTION = false;
        private const string APP_PACKAGE_NAME = "com.karum.credits";
        private const string APP_ACTIVITY_NAME = "com.karum.credits.ui.SplashActivity";
        //private const string DEVICE_NAME_NAME = "ZY323V65L2";
        private const string DEVICE_NAME_NAME = "emulator-5554";
        private string TEST_DEVISE = "ANDROID";
        private const string APPPATH_IOS = "iosapp";
        private const string APPPATH_ANDROID = "Karum_Fase_2_Sprint_3_v1.10.6.apk";

        private int _height;
        private int _width;

        public void DeleteFilesDownload()
        {
            if (_driverType.Equals(ANDROID))
            {
                List<string> delete = new List<string>
                {
                    "-rf", 
                    MOVILE_DOWNLOAD_PATHFOLDER_ANDROID + @"/*.*"
                };

                var deleteCommand = new Dictionary<string, object>();
                deleteCommand.Add("command", "rm");
                deleteCommand.Add("args", delete);
                ExecuteCommand(deleteCommand);
            }
            ///TODO IOS
        }

        public void ExecuteCommand(Dictionary<string, object> args)
        {
            if (_driverType.Equals(ANDROID))
            {
                _driver.ExecuteScript("mobile: shell", args);
            }
            ///TODO IOS
        }

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

        private Uri URLPathConfig()
        {
            Uri url;

            if (REMOTEEXECUTION)
            {
                // 1. Replace <<cloud name>> with your perfecto cloud name (for example, 'demo' is the cloudName of demo.perfectomobile.com).
                string cloudName = "trial";

                // 2. Replace <<security token>> with your Perfecto security token.
                string securityToken = "eyJhbGciOiJIUzI1NiIsInR5cCIgOiAiSldUIiwia2lkIiA6ICI2ZDM2NmJiNS01NDAyLTQ4MmMtYTVhOC1kODZhODk4MDYyZjIifQ.eyJpYXQiOjE2MzQwNTIwMzMsImp0aSI6ImE2MjdmMTgxLTIzNDItNGI0Ni1hMGU5LTAzYWVhYzEyZWVmMiIsImlzcyI6Imh0dHBzOi8vYXV0aDMucGVyZmVjdG9tb2JpbGUuY29tL2F1dGgvcmVhbG1zL3RyaWFsLXBlcmZlY3RvbW9iaWxlLWNvbSIsImF1ZCI6Imh0dHBzOi8vYXV0aDMucGVyZmVjdG9tb2JpbGUuY29tL2F1dGgvcmVhbG1zL3RyaWFsLXBlcmZlY3RvbW9iaWxlLWNvbSIsInN1YiI6ImJiZGE3NDJlLWIzNTMtNGI2ZC05NzQ5LTJjZmU0Y2FkMTY0NiIsInR5cCI6Ik9mZmxpbmUiLCJhenAiOiJvZmZsaW5lLXRva2VuLWdlbmVyYXRvciIsIm5vbmNlIjoiOGIwZGZlYTctMTc3Zi00NDFjLWI4YTEtNDlmMjk1ZDg2MGEwIiwic2Vzc2lvbl9zdGF0ZSI6IjZkNzgwNzc3LWI5OTYtNGNiMS1iOGNlLTQyNDZhOTI1YTE2ZSIsInNjb3BlIjoib3BlbmlkIG9mZmxpbmVfYWNjZXNzIHByb2ZpbGUgZW1haWwifQ.Hfps3Bp18N2wsitCOW4fMhnu6cDlvSNMfiYUYjvIDXA";

                _appiumOptions.AddAdditionalCapability("securityToken", securityToken);
                _appiumOptions.AddAdditionalCapability("app",
                        "PRIVATE:Karum_Fase_2_Sprint_3_v1.10.6.apk");
                _appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName,
                        "99241FFAZ00HKL");

                url = new Uri("https://" + cloudName.Replace(
                                ".perfectomobile.com", "")
                                + ".perfectomobile.com/nexperience/perfectomobile/wd/hub");
            }
            else
            {
                _appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AutoGrantPermissions, true);
                _appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName,
                        DEVICE_NAME_NAME);
                string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..",
                    APPVERSION_FOLDER, APPPATH_ANDROID));
                _appiumOptions.AddAdditionalCapability("app", path);

                url = new Uri("http://localhost:4723/wd/hub");
            }

            return url;
        }
    }
}