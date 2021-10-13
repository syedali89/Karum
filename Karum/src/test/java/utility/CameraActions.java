package test.java.utility;

import io.appium.java_client.android.nativekey.AndroidKey;
import io.appium.java_client.android.nativekey.KeyEvent;
import org.openqa.selenium.By;
import test.java.constants;

import java.util.HashMap;
import java.util.Map;

public class CameraActions {
    private static By btnTakePhotoButton = By.id("com.android.camera2:id/shutter_button");
    private static By btnAcceptPhotoButton = By.id("com.android.camera2:id/done_button");
    private static KeyEvent androidCamera = new KeyEvent(AndroidKey.CAMERA);
    //private static KeyEvent androidCamera = new KeyEvent(AndroidKey.);

    public static void TakePhoto(Driver driver) {
        //Test Code, camara just pass
        if(true){      return;}
        //
        if(driver.GetDriverType().equals(constants.ANDROID)) {
            //driver.GetAndroidDriver().pressKey(androidCamera);
            driver.GetAndroidDriver().findElement(btnTakePhotoButton).click();
            driver.GetAndroidDriver().findElement(btnAcceptPhotoButton).click();
            //TODO a way to wait time
            driver.GetAndroidDriver().pressKey(androidCamera);
            //TODO a way to wait time
        }
    }

    private static Map<String, Object> parameters(Driver driver, String imageName) {
        Map<String, Object> params = new HashMap<>();
        params.put("repositoryFile", "PRIVATE:" + imageName);
        params.put("identifier", "com.karum.credits");
        params.put("resize", "true");
        return params;
    }

    public static void ImageInjection(Driver driver, String imageName) {
        Map<String, Object> params = parameters(driver, imageName);
        if(driver.GetDriverType().equals(constants.ANDROID)) {
            Object res = driver.GetAndroidDriver().executeScript("mobile:image.injection:start", params);
        }
    }

    public static void ImageInjectionStop(Driver driver, String imageName) {
        Map<String, Object> params = parameters(driver, imageName);
        if(driver.GetDriverType().equals(constants.ANDROID)) {
            Object res = driver.GetAndroidDriver().executeScript("mobile:image.injection:stop", params);
        }
    }

}
