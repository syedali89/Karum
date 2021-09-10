package test.java.tests;

import org.testng.ITestListener;
import org.testng.ITestResult;
import org.testng.Reporter;
import org.testng.annotations.*;
import test.java.utility.Driver;
import test.java.utility.GetScreenshot;

import java.io.IOException;
import java.net.MalformedURLException;

public class BaseTest implements ITestListener {
    protected Driver _driver;

    @BeforeMethod
    public void beforeTest() throws MalformedURLException {
        _driver = new Driver();
    }

    @AfterMethod
    public void afterTest(ITestResult result){
        if (result.getStatus() == ITestResult.FAILURE) {
            System.out.println("ERROR FATAL");
            try
            {
                String path = GetScreenshot.capture(_driver.GetIntance(), result.getName());
                Reporter.log("<br><img src='" + path + "'/></b>", true);
            }
            catch (IOException e)
            {
                Reporter.log(e.getMessage());
            }
        }

        if(_driver != null)
        {
            _driver.GetIntance().quit();
        }
    }
}