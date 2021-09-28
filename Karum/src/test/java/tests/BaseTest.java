package test.java.tests;

import org.testng.ITestListener;
import org.testng.ITestResult;
import org.testng.Reporter;
import org.testng.annotations.*;
import test.java.data.Client;
import test.java.pages.*;
import test.java.utility.DataRecover;
import test.java.utility.Driver;
import test.java.utility.GetScreenshot;

import java.io.IOException;
import java.net.MalformedURLException;
import java.util.Random;

public class BaseTest implements ITestListener {
    protected Driver _driver;
    protected LogIN logIN;
    protected HomePage homePage;
    protected RegisterPage reg;
    protected Client clientData;

    @BeforeClass
    public void beforeClass() {
         clientData = DataRecover.RecoverClientData();
    }

    @BeforeMethod
    public void beforeTest() throws MalformedURLException {
        _driver = new Driver();
        logIN = new LogIN(_driver);
        homePage = new HomePage(_driver);
        reg = new RegisterPage(_driver);
    }

    @AfterMethod
    public void afterTest(ITestResult result){
        if (result.getStatus() == ITestResult.FAILURE) {
            System.out.println("ERROR FATAL");
            try
            {
                String path = GetScreenshot.capture(_driver.GetIntance(), result.getName() + "_" + new Random().nextInt(99999999));
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