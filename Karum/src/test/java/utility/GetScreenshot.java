package test.java.utility;

import java.io.File;
import java.io.IOException;
//import org.apache.commons.io.*;
import org.openqa.selenium.OutputType;
import org.openqa.selenium.TakesScreenshot;

import org.openqa.selenium.WebDriver;

public class GetScreenshot{
    public static String capture(WebDriver driver, String screenshotName) throws IOException {
        TakesScreenshot ts = ((TakesScreenshot)driver);
        File source = ts.getScreenshotAs(OutputType.FILE);
        String dest = System.getProperty("user.home") + "\\ErrorScreenshot\\" + screenshotName + ".png";
        File destination = new File(dest);
        //FileUtils.copyFile(source, destination);
        return dest;
    }
}