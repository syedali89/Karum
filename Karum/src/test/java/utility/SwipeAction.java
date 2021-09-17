package test.java.utility;

import com.google.common.collect.ImmutableMap;
import io.appium.java_client.AppiumDriver;
import io.appium.java_client.TouchAction;
import io.appium.java_client.android.AndroidDriver;
import io.appium.java_client.touch.WaitOptions;
import io.appium.java_client.touch.offset.PointOption;
import org.openqa.selenium.By;
import org.openqa.selenium.Dimension;
import org.openqa.selenium.ScreenOrientation;
import test.java.constants;

import java.time.Duration;
import java.util.HashMap;
import java.util.Map;

public class SwipeAction {
    public static boolean swipeDownUntilElementExist(AppiumDriver driver, By locator)
    {
        Dimension size = driver.manage().window().getSize();
        int Starty = (int) (size.height * 0.80);
        int Endy = (int) (size.height * 0.20);
        int Startx = size.width / 2;
        int Endx = Startx;

        if(driver.getOrientation().equals(ScreenOrientation.LANDSCAPE)) {
            Starty = size.height / 2;
            Endy = Starty;
            Startx = size.width / 2;
            Endx = size.width;
            /*String mySelector = "new UiSelector().text(\"" + Text + "\").instance(0)";
            String command = "new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollIntoView(" + mySelector + ");";
            ((AndroidDriver<?>) driver).findElementByAndroidUIAutomator(command);*/
        }

        int intents = 0;

        while(driver.findElements(locator).size() == 0 && intents < 1000)
        {
            intents++;
            new TouchAction(driver)
                    .longPress(PointOption.point(Startx, Starty))
                    .waitAction(WaitOptions.waitOptions(Duration.ofMillis(1000)))
                    .moveTo(PointOption.point(Endx, Endy))
                    .release().perform();
        }

        if(intents >= 15)
        {
            return false;
        }

        return true;
    }

    public static boolean swipeDownUntilElementText(Driver driver, String text) {

        if(driver.GetDriverType().equals(constants.ANDROID)) {
            try {
                String mySelector = "new UiSelector().text(\"" + text + "\").instance(0)";
                String command = "new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollIntoView(" + mySelector + ");";
                driver.GetAndroidDriver().findElementByAndroidUIAutomator(command);
            } catch (Exception ex) {
                return false;
            }
        }
        return true;
    }
}
