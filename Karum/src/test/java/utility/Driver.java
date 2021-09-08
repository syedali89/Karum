package test.java.utility;

import io.appium.java_client.android.AndroidElement;
import io.appium.java_client.android.AndroidDriver;
import io.appium.java_client.remote.AndroidMobileCapabilityType;
import io.appium.java_client.remote.MobileCapabilityType;
import org.openqa.selenium.Platform;
import org.openqa.selenium.remote.DesiredCapabilities;

import java.net.MalformedURLException;
import java.net.URL;
import java.util.concurrent.TimeUnit;

public class Driver
{
    public Driver() throws MalformedURLException {
        DesiredCapabilities capabilities = new DesiredCapabilities();
        capabilities.setCapability(MobileCapabilityType.PLATFORM_NAME, Platform.ANDROID);
        capabilities.setCapability(MobileCapabilityType.UDID, "YOUR_DEVICE_UDID");
        capabilities.setCapability(MobileCapabilityType.NO_RESET, false);
        capabilities.setCapability(AndroidMobileCapabilityType.APP_PACKAGE, APP_PACKAGE_NAME);
        capabilities.setCapability(AndroidMobileCapabilityType.APP_ACTIVITY, APP_ACTIVITY_NAME);
        // Initialize driver
        AndroidDriver driver = new AndroidDriver(new URL("http://localhost:4723/wd/hub"), capabilities);
        // Discard state
        driver.resetApp();

        driver.manage().timeouts().implicitlyWait(30, TimeUnit.SECONDS);
    }

    private AndroidDriver<AndroidElement> driver;
    private final static String APP_PACKAGE_NAME = "io.testproject.demo";
    private final static String APP_ACTIVITY_NAME = ".MainActivity";

    public AndroidDriver<AndroidElement> GetIntance()
    {
        return driver;
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
