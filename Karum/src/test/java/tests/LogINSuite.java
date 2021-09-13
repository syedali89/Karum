package test.java.tests;

import org.testng.annotations.Test;
import test.java.constants;
import test.java.pages.LogIN;

public class LogINSuite extends BaseTest {

    @Test
    public void batCredentiasUserLogIn() {
        LogIN logIN = new LogIN(_driver.GetIntance(), _driver.GetDriverType());

        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.LoginUser("user@email.com", "password");
        logIN.verifyBadLogIn();
    }

    @Test
    public void TC001_LOGIN_ExistingClient() {
        LogIN logIN = new LogIN(_driver.GetIntance(), _driver.GetDriverType());

        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.validateLoginPageSOYCLIENTE(false);
    }

    @Test
    public void TC002_ValidateUsernamefield() {
        LogIN logIN = new LogIN(_driver.GetIntance(), _driver.GetDriverType());

        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.enterUserCredentials("", "A");
        logIN.validateLoginPageSOYCLIENTE(false);
    }

    @Test
    public void TC002_ValidateUsernamefieldIsEmailFormat() {
        LogIN logIN = new LogIN(_driver.GetIntance(), _driver.GetDriverType());

        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.enterUserCredentials("username", "A");
        logIN.validateLoginPageSOYCLIENTE(false);
    }

    @Test
    public void TC003_ValidatePasswordfield() {
        LogIN logIN = new LogIN(_driver.GetIntance(), _driver.GetDriverType());

        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.enterUserCredentials("user@email.com", "");
        logIN.validateLoginPageSOYCLIENTE(false);
    }

    @Test
    public void TC004_ValidateINICIASESIONenables() {
        LogIN logIN = new LogIN(_driver.GetIntance(), _driver.GetDriverType());

        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.enterUserCredentials("user@email.com", "A");
        logIN.validateLoginPageSOYCLIENTE(true);
    }
}