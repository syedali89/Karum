package test.java.utility;

import io.appium.java_client.AppiumDriver;
import io.appium.java_client.android.AndroidDriver;
import io.appium.java_client.ios.IOSDriver;
import io.appium.java_client.remote.AndroidMobileCapabilityType;
import io.appium.java_client.remote.MobileCapabilityType;
import org.openqa.selenium.Platform;
import org.openqa.selenium.remote.DesiredCapabilities;
import test.java.constants;

import java.io.File;
import java.net.MalformedURLException;
import java.net.URL;
public class Driver {
    public Driver() throws MalformedURLException {
        int exitCode = 0;
        DesiredCapabilities capabilities = new DesiredCapabilities("", "", Platform.ANY);
        // 1. Replace <<cloud name>> with your perfecto cloud name (for example, 'demo' is the cloudName of demo.perfectomobile.com).
        String cloudName = "trial";

        // 2. Replace <<security token>> with your Perfecto security token.
        String securityToken =
                "eyJhbGciOiJIUzI1NiIsInR5cCIgOiAiSldUIiwia2lkIiA6ICI2ZDM2NmJiNS01NDAyLTQ4MmMtYTVhOC1kODZhODk4MDYyZjIifQ.eyJpYXQiOjE2MzQwNTIwMzMsImp0aSI6ImE2MjdmMTgxLTIzNDItNGI0Ni1hMGU5LTAzYWVhYzEyZWVmMiIsImlzcyI6Imh0dHBzOi8vYXV0aDMucGVyZmVjdG9tb2JpbGUuY29tL2F1dGgvcmVhbG1zL3RyaWFsLXBlcmZlY3RvbW9iaWxlLWNvbSIsImF1ZCI6Imh0dHBzOi8vYXV0aDMucGVyZmVjdG9tb2JpbGUuY29tL2F1dGgvcmVhbG1zL3RyaWFsLXBlcmZlY3RvbW9iaWxlLWNvbSIsInN1YiI6ImJiZGE3NDJlLWIzNTMtNGI2ZC05NzQ5LTJjZmU0Y2FkMTY0NiIsInR5cCI6Ik9mZmxpbmUiLCJhenAiOiJvZmZsaW5lLXRva2VuLWdlbmVyYXRvciIsIm5vbmNlIjoiOGIwZGZlYTctMTc3Zi00NDFjLWI4YTEtNDlmMjk1ZDg2MGEwIiwic2Vzc2lvbl9zdGF0ZSI6IjZkNzgwNzc3LWI5OTYtNGNiMS1iOGNlLTQyNDZhOTI1YTE2ZSIsInNjb3BlIjoib3BlbmlkIG9mZmxpbmVfYWNjZXNzIHByb2ZpbGUgZW1haWwifQ.Hfps3Bp18N2wsitCOW4fMhnu6cDlvSNMfiYUYjvIDXA";
        capabilities.setCapability("securityToken", securityToken);

        if(TEST_DEVISE.equals(ANDROID)) {
            URL url;
            if(PERFECTO) {
                capabilities.setCapability("app",
                        "PRIVATE:Karum_Fase_2_Sprint_3_v1.10.5.apk");
                capabilities.setCapability(MobileCapabilityType.DEVICE_NAME,
                        "99241FFAZ00HKL");

                url = new URL(
                        "https://" + cloudName.replace(
                                ".perfectomobile.com", "")
                                + ".perfectomobile.com/nexperience/perfectomobile/wd/hub");
            }
            else {
                capabilities.setCapability(MobileCapabilityType.DEVICE_NAME,
                        DEVICE_NAME_NAME);
                String path = new File(
                        constants.APPVERSION_FOLDER + APPPATH_ANDROID).getAbsolutePath();
                capabilities.setCapability("app", path);

                url = new URL("http://localhost:4723/wd/hub");
            }

            capabilities.setCapability(AndroidMobileCapabilityType.APP_PACKAGE, APP_PACKAGE_NAME);
            capabilities.setCapability(AndroidMobileCapabilityType.APP_ACTIVITY, APP_ACTIVITY_NAME);
            capabilities.setCapability(MobileCapabilityType.NO_RESET, false);

            capabilities.setCapability("enableAppiumBehavior", true);
            capabilities.setCapability("autoLaunch", true);
            capabilities.setCapability("autoInstrument", true);
            capabilities.setCapability("takesScreenshot", true);
            capabilities.setCapability("screenshotOnError", true);
            capabilities.setCapability("fullReset", true);
            capabilities.setCapability("waitForAvailableLicense", true);
            capabilities.setCapability("sensorInstrument", true);

            _driverandroid = new AndroidDriver(url,capabilities);
            _driver = _driverandroid;

            _driverType = ANDROID;
        }
        else if(TEST_DEVISE.equals(IOS))
        {
            String path = new File(constants.APPVERSION_FOLDER + APPPATH_IOS).getAbsolutePath();
            capabilities.setCapability("app", path);
            capabilities.setCapability(MobileCapabilityType.PLATFORM_NAME, Platform.IOS);

            _driverios = new IOSDriver(new URL("http://localhost:4723/wd/hub"), capabilities);
            _driver = _driverios;
            _driverType = IOS;
        }
        // Discard state
        _driver.resetApp();
    }

    private AppiumDriver _driver;
    private AndroidDriver _driverandroid;
    private IOSDriver _driverios;
    private String _driverType;
    private boolean PERFECTO = true;
    private final static String APP_PACKAGE_NAME = "com.karum.credits";
    private final static String APP_ACTIVITY_NAME = "com.karum.credits.ui.SplashActivity";
    //private final static String DEVICE_NAME_NAME = "ZY323V65L2";
    private final static String DEVICE_NAME_NAME = "emulator-5554";
    private String TEST_DEVISE = "ANDROID";
    private final static String ANDROID = "ANDROID";
    private final static String IOS = "IOS";
    private final static String APPPATH_IOS = "iosapp";
    private final static String APPPATH_ANDROID = "Karum_Fase_2_Sprint_3_v1.10.5.apk";


    public AppiumDriver GetIntance() {
        return _driver;
    }

    public AndroidDriver GetAndroidDriver() {
        return _driverandroid;
    }

    public IOSDriver GetIOSDriver() {
        return _driverios;
    }

    public String GetDriverType() {
        return _driverType;
    }
}
