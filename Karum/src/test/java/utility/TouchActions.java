package test.java.utility;

import io.appium.java_client.AppiumDriver;
import io.appium.java_client.TouchAction;
import io.appium.java_client.touch.WaitOptions;
import io.appium.java_client.touch.offset.PointOption;
import org.openqa.selenium.By;

import java.time.Duration;

public class TouchActions {

    public static boolean swipeDownUntilElementExist(AppiumDriver driver, By locator)
    {
        int Height = driver.manage().window().getSize().height;
        int Width = driver.manage().window().getSize().width;
        int Starty = Height / 2;
        int Endy = Height / 10;
        int Startx = (int)(Width * 0.8);
        int Endx = Startx;

        int intents = 0;

        while(driver.findElements(locator).size() == 0 && intents < 15)
        {
            intents++;
            new TouchAction(driver).longPress(PointOption.point(Startx, Starty))
                    .waitAction(WaitOptions.waitOptions(Duration.ofMillis(100)))
                    //.waitAction(WaitOptions.waitOptions(Duration.ofSeconds(1)))
                    .moveTo(PointOption.point(Endx, Endy))
                    .release().perform();
        }

        if(intents >= 15)
        {
            return false;
        }

        return true;
    }
}
