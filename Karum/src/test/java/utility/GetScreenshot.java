package test.java.utility;

import java.io.File;
import java.io.IOException;
import io.appium.java_client.AppiumDriver;
import org.codehaus.plexus.util.FileUtils;
import org.openqa.selenium.OutputType;
import org.openqa.selenium.TakesScreenshot;

public class GetScreenshot{
    public static String capture(AppiumDriver driver, String screenshotName) throws IOException {
        TakesScreenshot ts = ((TakesScreenshot)driver);
        File source = ts.getScreenshotAs(OutputType.FILE);
        String dest = System.getProperty("user.home") + "\\ErrorScreenshot\\" + screenshotName + ".png";
        File destination = new File(dest);
        FileUtils.copyFile(source, destination);
        return dest;
    }
}