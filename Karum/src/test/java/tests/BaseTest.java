package test.java.tests;

import org.openqa.selenium.html5.Location;
import org.testng.ITestListener;
import org.testng.ITestResult;
import org.testng.Reporter;
import org.testng.annotations.*;
import test.java.pages.*;
import test.java.utility.Driver;
import test.java.utility.GetScreenshot;

import java.io.IOException;
import java.net.MalformedURLException;

public class BaseTest implements ITestListener {
    protected Driver _driver;
    protected LogIN logIN;
    protected HomePage homePage;
    protected RegisterPage reg;
    protected PMLPage moneyLaunderingPage;
    protected INEPhotoPage inePhotoPage ;

    @BeforeMethod
    public void beforeTest() throws MalformedURLException {
        _driver = new Driver();
        logIN = new LogIN(_driver, _driver.GetDriverType());
        homePage = new HomePage(_driver, _driver.GetDriverType());
        reg = new RegisterPage(_driver, _driver.GetDriverType());
        moneyLaunderingPage = new PMLPage(_driver, _driver.GetDriverType());
        inePhotoPage = new INEPhotoPage(_driver, _driver.GetDriverType());
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