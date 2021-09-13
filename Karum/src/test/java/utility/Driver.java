package test.java.utility;

import io.appium.java_client.AppiumDriver;
import io.appium.java_client.android.AndroidDriver;
import io.appium.java_client.ios.IOSDriver;
import io.appium.java_client.remote.AndroidMobileCapabilityType;
import io.appium.java_client.remote.MobileCapabilityType;
import org.openqa.selenium.Platform;
import org.openqa.selenium.remote.DesiredCapabilities;

import java.io.File;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.concurrent.TimeUnit;

public class Driver
{
    public Driver() throws MalformedURLException {

        String path = new File("Karum_Fase_2_v1.9.11.apk").getAbsolutePath();

        DesiredCapabilities capabilities = new DesiredCapabilities();
        capabilities.setCapability(MobileCapabilityType.DEVICE_NAME, DEVICE_NAME_NAME);
        capabilities.setCapability(MobileCapabilityType.NO_RESET, false);
        capabilities.setCapability("app", path);

        if(TEST_DEVISE.equals(ANDROID))
        {
            capabilities.setCapability(MobileCapabilityType.PLATFORM_NAME, Platform.ANDROID);
            capabilities.setCapability(AndroidMobileCapabilityType.APP_PACKAGE, APP_PACKAGE_NAME);
            capabilities.setCapability(AndroidMobileCapabilityType.APP_ACTIVITY, APP_ACTIVITY_NAME);
            capabilities.setCapability(AndroidMobileCapabilityType.AUTO_GRANT_PERMISSIONS, true);
            _driverType = ANDROID;

            _driver = new AndroidDriver(new URL("http://localhost:4723/wd/hub"), capabilities);
        }
        else if(TEST_DEVISE.equals(IOS))
        {
            capabilities.setCapability(MobileCapabilityType.PLATFORM_NAME, Platform.IOS);
            _driverType = IOS;

            _driver = new IOSDriver(new URL("http://localhost:4723/wd/hub"), capabilities);
        }
        // Discard state
        _driver.resetApp();

        //_driver.manage().timeouts().implicitlyWait(30, TimeUnit.SECONDS);
    }

    private AppiumDriver _driver;
    private String _driverType;
    private final static String APP_PACKAGE_NAME = "com.karum.credits";
    private final static String APP_ACTIVITY_NAME = "com.karum.credits.ui.SplashActivity";
    private final static String DEVICE_NAME_NAME = "ZY323V65L2";
    private final static String TEST_DEVISE = "ANDROID";
    private final static String ANDROID = "ANDROID";
    private final static String IOS = "IOS";


    public AppiumDriver GetIntance()
    {
        return _driver;
    }

    public String GetDriverType()
    {
        return _driverType;
    }
/*
    public void SwitchApp(String activity, String packeage)
    {
        driver.StartActivity(activity, packeage, "", "", false);
    }

    public void ReturnApp()
    {
        driver.PressKeyCode(AndroidKeyCode.Back);
    }

    /// <summary>
    /// Gets NameTest.
    /// </summary>
    public string GetNameTest()
    {
        return TestContext.CurrentContext.Test.Name.ToString();
    }

    public string GetTime()
    {
        return driver.DeviceTime.ToString();
    }

    public static string TakeFullScreenshot()
    {
        string filename = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                string.Format(indice + "-" +
                        TestContext.CurrentContext.Test.Name +
                        "-" +
                        "{0}.jpg", Guid.NewGuid().ToString()));
        Screenshot screenshot = GetIntance().GetScreenshot();
        screenshot.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
        indice++;
        return filename;
    }

    /// <summary>
    /// Toma capturas.
    /// </summary>
    public static void TaskPrint()
    {
        try
        {
            TestContext.AddTestAttachment(TakeFullScreenshot(), TestContext.CurrentContext.Test.Name);
        }
        catch (Exception)
        {
            Console.WriteLine("Hubo un incoveniente en la captunra.");
        }
    }

    public static void WriteLog(string message)
    {
        StreamWriter log = new StreamWriter(Path.Combine(Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                string.Format(TestContext.CurrentContext.Test.Name +
                        "-" +
                        "{0}.txt", Guid.NewGuid().ToString()))));
        log.Write(message);
        log.Close();
    }*/
}
