namespace utility
{
    using data;
    using Newtonsoft.Json;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Appium.Enums;
    using OpenQA.Selenium.Appium.iOS;
    using Reportium.Client;
    using Reportium.Model;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using static constants;

    public class Driver 
    {       
        /// <summary>
        /// Contructor
        /// </summary>
        public Driver() 
        {
            _appiumOptions = new AppiumOptions();
            SetEnvironmentData();
            Uri url = this.URLPathConfig();

            #region Set Generic Capabilitys
            _appiumOptions.AddAdditionalCapability("newCommandTimeout", 360);
            _appiumOptions.AddAdditionalCapability("disableWindowAnimation", true);
            _appiumOptions.AddAdditionalCapability("enableAppiumBehavior", true);
            _appiumOptions.AddAdditionalCapability("autoLaunch", true);
            _appiumOptions.AddAdditionalCapability("autoInstrument", true);
            _appiumOptions.AddAdditionalCapability("takesScreenshot", true);
            
            _appiumOptions.AddAdditionalCapability("waitForAvailableLicense", true);
            _appiumOptions.AddAdditionalCapability("sensorInstrument", true);
            _appiumOptions.AddAdditionalCapability(MobileCapabilityType.NoReset, false);
            

            if (!string.IsNullOrEmpty(_env.envData.DEVICE_NAME))
            {
                _appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, _env.envData.DEVICE_NAME);
            }

            _appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, _env.envData.PLATAFORM_VERSION);
            _appiumOptions.AddAdditionalCapability("model", _env.envData.MODEL);
            _appiumOptions.AddAdditionalCapability("manufacturer", _env.envData.MANUFACTURER);
            #endregion

            SetKarumAppCapability();

            if (_env.envData.TEST_DEVICE.Equals(OS.ANDROID)) 
            {
                #region Set Android Specific Capabilitys
                _appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "android");
                
                if (_env.envData.REMOTE)
                {
                    _appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "Appium");
                }
                else
                {
                    _appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "uiautomator2");
                }

                _appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, KARUM_PACKAGE_NAME);
                _appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, KARUM_ACTIVITY_NAME);
                #endregion

                #region Instance a AndroidDriver 
                _driverandroid = new AndroidDriver<AppiumWebElement>(url, _appiumOptions, TimeSpan.FromMinutes(5));
                _driver = _driverandroid;
                #endregion
            }
            else if(_env.envData.TEST_DEVICE.Equals(OS.IOS))
            {
                #region Set IOS Specific Capabilitys
                _appiumOptions.AddAdditionalCapability("resolution", "1125x2436");
                _appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "ios");     
                _appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "XCUITest");
                _appiumOptions.AddAdditionalCapability("sendKeyStrategy", "setValue");

                if (!string.IsNullOrEmpty(_env.envData.IOS_UDID))
                {
                    _appiumOptions.AddAdditionalCapability(MobileCapabilityType.Udid, _env.envData.IOS_UDID);
                }
                #endregion

                #region Instance a IOSDriver
                _driverios = new IOSDriver<AppiumWebElement>(url, _appiumOptions, TimeSpan.FromMinutes(7));
                _driver = _driverios;
                #endregion
            }

            _height = _driver.Manage().Window.Size.Height;
            _width = _driver.Manage().Window.Size.Width;

            SetCiudadMexicoLocation();
        }

        #region Private Attributes
        private AppiumDriver<AppiumWebElement> _driver;            
        private AndroidDriver<AppiumWebElement> _driverandroid;
        private IOSDriver<AppiumWebElement> _driverios;
        private AppiumOptions _appiumOptions;
        private int _height;
        private int _width;

        private class ConfigurationsEnv
        {
            public string remote { get; set; }
            public string device { get; set; }
            public EnvData envData;
        }

        private ConfigurationsEnv _env;
        #endregion
        #region Public Attributes
        public ReportTool Report;
        public Exception exception = new Exception("N");
        #endregion

        /// <summary>
        /// Set Device Location to Ciudad de Mexico
        /// </summary>
        public void SetCiudadMexicoLocation()
        {
            if (GetRemoteState())
            {
                Dictionary<string, object> pars = new Dictionary<string, object>();
                pars.Add("coordinates", "19.4090, -99.1270");
                _driver.ExecuteScript("mobile:location:set", pars);
            }
        }
        
        /// <summary>
        /// Delete files from Download Folder. 
        /// NOT IMPLEMENT FOR REMOTE EXECUTION
        /// NEITHER IOS LOCAL
        /// </summary>
        public void DeleteFilesDownload()
        {
            if (_env.envData.REMOTE)
            {
                exception = new NotImplementedException();
                throw exception;
            }
            else
            {
                if (_env.envData.TEST_DEVICE.Equals(OS.ANDROID))
                {
                    List<string> delete = new List<string>
                    {
                        "-rf",
                        MOVILE_DOWNLOAD_PATHFOLDER_ANDROID + @"/*.*"
                    };

                    var deleteCommand = new Dictionary<string, object>();
                    deleteCommand.Add("command", "rm");
                    deleteCommand.Add("args", delete);
                    _driver.ExecuteScript("mobile: shell", deleteCommand);
                }
                else if (_env.envData.TEST_DEVICE.Equals(OS.IOS))
                {
                    exception = new NotImplementedException();
                    throw exception;
                }
            }
        }

        #region Generic public Gets Methods
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
            return _env.envData.REMOTE;
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

        public OS GetDevice() 
        {
            return  _env.envData.TEST_DEVICE;
        }
        
        public string GetUserName() 
        {
            return  _env.envData.USEREMAIL;
        }

        public string GetUserPass() 
        {
            return  _env.envData.USERPASS;
        }
        #endregion

        #region Launch Apps on Device Methods
        /// <summary>
        /// Launch a IOS App
        /// </summary>
        /// <param name="bundleId"></param>
        public void LaunchNewApp(string bundleId)
        {
            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add("bundleId", bundleId);
            _driverios.ExecuteScript("mobile: launchApp", args);
        }

        /// <summary>
        /// Launch a Android App
        /// </summary>
        /// <param name="package"></param>
        /// <param name="activity"></param>
        public void LaunchNewApp(string package, string activity)
        {
            _driverandroid.StartActivity(package, activity);
        }
        #endregion

        /// <summary>
        /// Created a Report Client
        /// </summary>
        /// <param name="testClass"></param>
        public void CreateReportingClient(string testClass)
        {
            if (GetRemoteState())
            {
                PerfectoExecutionContext perfectoExecutionContext = new PerfectoExecutionContext.PerfectoExecutionContextBuilder()
                   .WithProject(new Project("KarumAutomationMobile", "v1.0"))
                   .WithContextTags(new[] { testClass, GetDevice().ToString() })
                   .WithJob(new Job("Karum Mobile Automation", 1))
                   .WithWebDriver(GetIntance())
                   .Build();

                Report = new ReportTool(GetRemoteState(), GetDevice().ToString(), PerfectoClientFactory.CreatePerfectoReportiumClient(perfectoExecutionContext));
            }
            else
            {
                Report = new ReportTool(GetRemoteState(), GetDevice().ToString());
            }
        }

        /// <summary>
        /// Set Karum App configuration Capabilitys
        /// </summary>
        private void SetKarumAppCapability()
        {
            if (_env.envData.REMOTE)
            {
                #region Perfecto Capabilitys for remote Execution
                _appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, "PRIVATE:" + _env.envData.APP_VERSION);

                if (!string.IsNullOrEmpty(_env.envData.RESOLUTION))
                {
                    _appiumOptions.AddAdditionalCapability("resolution", _env.envData.RESOLUTION);
                }
                #endregion
            }
            else
            {
                #region Local execution Capabilitys 
                _appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..",
                       APPVERSION_FOLDER, _env.envData.APP_VERSION)));
                #endregion
            }
        }

        /// <summary>
        /// Recover URL conection required for appium execution
        /// </summary>
        /// <returns>URL configurations</returns>
        private Uri URLPathConfig()
        {
            Uri url;

            if (_env.envData.REMOTE)
            {
                #region Perfecto URL server conections 
                _appiumOptions.AddAdditionalCapability(MobileCapabilityType.FullReset, true);
                _appiumOptions.AddAdditionalCapability("securityToken", _env.envData.SECURITYTOKEN);     

                url = new Uri(string.Format("https://{0}.perfectomobile.com/nexperience/perfectomobile/wd/hub", _env.envData.CLOUDNAME));
                #endregion
            }
            else
            {
                #region Local Appium Server URL configuration
                _appiumOptions.AddAdditionalCapability(MobileCapabilityType.NoReset, false);
                
                if (_env.envData.TEST_DEVICE.Equals(OS.ANDROID))
                {
                    _appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AutoGrantPermissions, true);
                }
                else if (_env.envData.TEST_DEVICE.Equals(OS.IOS))
                {
                    _appiumOptions.AddAdditionalCapability(IOSMobileCapabilityType.AutoAcceptAlerts, true);
                }

                url = new Uri("http://localhost:4723/wd/hub");
                #endregion
            }

            return url;
        }

        /// <summary>
        /// Set Enviroment Data recover from a JSON file
        /// </summary>
        private void SetEnvironmentData()
        {
            #region Recovering Enviroment Data
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("REMOTE")))
            {
                _env = new ConfigurationsEnv();
                _env.remote = Environment.GetEnvironmentVariable("REMOTE");
                _env.device = Environment.GetEnvironmentVariable("DEVICE"); 
            }
            else
            {
                string docFile = DataRecover.RecoverJsonFilePath("envExecution.json");

                using (StreamReader r = new StreamReader(docFile))
                {
                    string json = r.ReadToEnd();
                    _env = JsonConvert.DeserializeObject<ConfigurationsEnv>(json);
                }                
            }            

            if (_env.remote != REMOTE_TRUE && _env.remote != REMOTE_FALSE || _env.device != ANDROID && _env.device != IOS)
            {

                exception = new InvalidDataException("Environment variables have a invalid value");
                throw exception;
            }
            #endregion

            #region Setting Enviroment Configuration from JSON File
            if (_env.remote.Equals(REMOTE_TRUE))
            {
                if (_env.device.Equals(ANDROID))
                {
                    _env.envData = DataRecover.RecoverEnviromentData("env_android_remote.json");
                }
                else
                {
                    _env.envData = DataRecover.RecoverEnviromentData("env_ios_remote.json");
                }
            }
            else
            {
                if (_env.device.Equals(ANDROID))
                {
                    _env.envData = DataRecover.RecoverEnviromentData("env_android_local.json");
                }
                else
                {
                    _env.envData = DataRecover.RecoverEnviromentData("env_ios_local.json");     
                }
            }
            #endregion
        }        
    }
}