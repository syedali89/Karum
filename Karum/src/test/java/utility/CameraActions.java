package test.java.utility;

import io.appium.java_client.AppiumDriver;
import io.appium.java_client.TouchAction;
import io.appium.java_client.android.AndroidDriver;
import io.appium.java_client.android.nativekey.AndroidKey;
import io.appium.java_client.android.nativekey.KeyEvent;
import io.appium.java_client.touch.WaitOptions;
import io.appium.java_client.touch.offset.PointOption;
import org.openqa.selenium.By;
import test.java.constants;

import java.time.Duration;

public class CameraActions {
    private static KeyEvent androidCamera = new KeyEvent(AndroidKey.CAMERA);
    //private static KeyEvent androidCamera = new KeyEvent(AndroidKey.);

    public static void TakePhoto(Driver driver) {
        //Test Code, camara just pass
        if(true){      return;}
        //
        if(driver.GetDriverType().equals(constants.ANDROID)) {
            driver.GetAndroidDriver().pressKey(androidCamera);
            //TODO a way to wait time
            driver.GetAndroidDriver().pressKey(androidCamera);
            //TODO a way to wait time
        }


    }
}
