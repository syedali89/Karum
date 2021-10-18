package test.java.tests;

import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;
import test.java.constants;
import test.java.pages.HomePage;
import test.java.utility.DataRecover;

public class HomePageSuite extends BaseTest {
    @BeforeMethod
    public void beforeMethod(){
        _driver.GetIntance().launchApp();
        logIN.grantAllPermissions();
        clientData = DataRecover.RecoverClientData();

        logIN.allLoginProcess(clientData);
    }

    @Test(priority = 1)
    public void TC031_LOGIN_ExistingClient() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.validateSOYCLIENTELogINEmailPhone();
    }
}