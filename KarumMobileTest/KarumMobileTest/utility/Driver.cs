namespace utility 
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using data;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Enums;
    using OpenQA.Selenium.Appium.iOS;
    using static constants;    

    public class Driver 
    {       
        /// <summary>
        /// Contructor
        /// </summary>
        public Driver() 
        {
            SetEnvironmentData();

            _appiumOptions = new AppiumOptions();
            _appiumOptions.AddAdditionalCapability("newCommandTimeout", 60000);
            _appiumOptions.AddAdditionalCapability("disableWindowAnimation", true);
            _appiumOptions.AddAdditionalCapability("enableAppiumBehavior", true);
            _appiumOptions.AddAdditionalCapability("autoLaunch", true);
            _appiumOptions.AddAdditionalCapability("autoInstrument", true);
            _appiumOptions.AddAdditionalCapability("takesScreenshot", true);
            
            _appiumOptions.AddAdditionalCapability("waitForAvailableLicense", true);
            _appiumOptions.AddAdditionalCapability("sensorInstrument", true);            
            
            if (!string.IsNullOrEmpty(_env.DEVICE_NAME))
            {
                _appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, _env.DEVICE_NAME);
            }

            _appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, _env.PLATAFORM_VERSION);
            _appiumOptions.AddAdditionalCapability("model", _env.MODEL);

            Uri url = this.URLPathConfig();
            setAppCapability();

            if (_env.TEST_DEVICE.Equals(EnvironmentData.DEVICE.ANDROID)) 
            {
                _appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "android");
                if (_env.REMOTE)
                {
                    _appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "Appium");
                }
                else
                {
                    _appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "uiautomator2");
                }

                _appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, APP_PACKAGE_NAME);
                _appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, APP_ACTIVITY_NAME);

                _driverandroid = new AndroidDriver<AppiumWebElement>(url, _appiumOptions, TimeSpan.FromSeconds(240));
                _driver = _driverandroid;                             
            }
            else if(_env.TEST_DEVICE.Equals(EnvironmentData.DEVICE.IOS))
            {
                _appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "ios");                
                _appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "XCUITest");
                
                if (string.IsNullOrEmpty(_env.IOS_UDID))
                {
                    _appiumOptions.AddAdditionalCapability(MobileCapabilityType.Udid, _env.IOS_UDID);
                }

                _driverios = new IOSDriver<AppiumWebElement>(url, _appiumOptions, TimeSpan.FromSeconds(240));
                _driver = _driverios;
            }

            _height = _driver.Manage().Window.Size.Height;
            _width = _driver.Manage().Window.Size.Width;
        }

        private AppiumDriver<AppiumWebElement> _driver;            
        private AndroidDriver<AppiumWebElement> _driverandroid;
        private IOSDriver<AppiumWebElement> _driverios;
        private AppiumOptions _appiumOptions;
        private string APP_PACKAGE_NAME = "com.karum.credits";
        private string APP_ACTIVITY_NAME = "com.karum.credits.ui.SplashActivity";
        private EnvironmentData _env;

        private int _height;
        private int _width;

        public void DeleteFilesDownload()
        {
            if (_env.REMOTE)
            { 
                ///TODO
            }
            else
            {
                if (_env.TEST_DEVICE.Equals(EnvironmentData.DEVICE.ANDROID))
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
                else if (_env.TEST_DEVICE.Equals(EnvironmentData.DEVICE.IOS))
                { 
                    ///TODO
                }
            }
        }

        public void ExecuteCommand(Dictionary<string, object> args)
        {
            if (_env.TEST_DEVICE.Equals(EnvironmentData.DEVICE.ANDROID))
            {
                _driver.ExecuteScript("mobile: shell", args);
            }
            else if (_env.TEST_DEVICE.Equals(EnvironmentData.DEVICE.IOS))
            {
                ///TODO
            }
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
            return _env.REMOTE;
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

        public EnvironmentData.DEVICE GetDriverType() 
        {
            return  _env.TEST_DEVICE;
        }

        private void setAppCapability()
        {
            if (_env.REMOTE)
            {
                _appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, "PRIVATE:" + _env.APP_VERSION);
            }
            else
            {
                _appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..",
                       APPVERSION_FOLDER, _env.APP_VERSION)));
            }       
        }

        private Uri URLPathConfig()
        {
            Uri url;

            if (_env.REMOTE)
            {
                _appiumOptions.AddAdditionalCapability(MobileCapabilityType.FullReset, true);
                _appiumOptions.AddAdditionalCapability("securityToken", _env.SECURITYTOKEN);                       
                _appiumOptions.AddAdditionalCapability("securityToken", _env.SECURITYTOKEN);                        

                url = new Uri("https://" + _env.CLOUDNAME.Replace(
                                ".perfectomobile.com", "")
                                + ".perfectomobile.com/nexperience/perfectomobile/wd/hub");
            }
            else
            {
                _appiumOptions.AddAdditionalCapability(MobileCapabilityType.NoReset, false);
                
                
                if (_env.TEST_DEVICE.Equals(EnvironmentData.DEVICE.ANDROID))
                {
                    _appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AutoGrantPermissions, true);
                }
                else if (_env.TEST_DEVICE.Equals(EnvironmentData.DEVICE.IOS))
                {
                    _appiumOptions.AddAdditionalCapability(IOSMobileCapabilityType.AutoAcceptAlerts, true);
                }

                url = new Uri("http://localhost:4723/wd/hub");
            }

            return url;
        }

        private void SetEnvironmentData()
        {
            string remote = "N";//Environment.GetEnvironmentVariable("REMOTE");
            string device = ANDROID;//Environment.GetEnvironmentVariable("DEVICE");

            if (remote != "Y" && remote != "N")
            {
                throw new InvalidDataException("Environment variable 'REMOTE' has a invalid value");
            }

            if (device != ANDROID && device != IOS)
            {
                throw new InvalidDataException("Environment variable 'DEVICE' has a invalid value");
            }

            if (remote.Equals("Y"))
            {
                if (device.Equals(ANDROID))
                {
                    _env = DataRecover.RecoverEnviromentData("env_android_remote.json");
                }
                else
                {
                    _env = DataRecover.RecoverEnviromentData("env_ios_remote.json");
                }
            }
            else
            {
                if (device.Equals(ANDROID))
                {
                    _env = DataRecover.RecoverEnviromentData("env_android_local.json");
                }
                else
                {
                    _env = DataRecover.RecoverEnviromentData("env_ios_local.json");
                }
            }
        }
    }
}