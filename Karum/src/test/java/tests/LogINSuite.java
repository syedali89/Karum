package test.java.tests;

import org.testng.annotations.Test;
import test.java.constants;
import test.java.pages.LogIN;
import test.java.pages.HomePage;

public class LogINSuite extends BaseTest {
    @Test
    public void TC001_LOGIN_ExistingClient() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.validateLoginPageSOYCLIENTE(false);
    }

    @Test
    public void TC002_ValidateUsernamefield_Required() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.enterUserCredentials("", "A");
        logIN.validateLoginPageSOYCLIENTE(false);
    }

    @Test
    public void TC002_ValidateUsernamefieldIsEmailFormat() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.enterUserCredentials("username", "A");
        logIN.validateLoginPageSOYCLIENTE(false);
    }

    @Test
    public void TC003_ValidatePasswordfield_Required() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.enterUserCredentials("user@email.com", "");
        logIN.validateLoginPageSOYCLIENTE(false);
    }

    @Test
    public void TC004_ValidateINICIASESIONenables() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.enterUserCredentials("user@email.com", "A");
        logIN.validateLoginPageSOYCLIENTE(true);
    }

    @Test
    public void TC0005_ValidateapplicationAskSecurityPinUponLoginForFirstTimeOnlyAfterInstallingApplication () {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.LoginUser("two@two.com", "1Qa!2345");
        logIN.verifyMessageActivationCode();
    }

    @Test
    public void TC0006_ValidateErrorMessageEnteringInvalidSecurityCodeUponFirstTimeLogin() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.LoginUser("two@two.com", "1Qa!2345");
        logIN.insertSecurityCode(false);

        logIN.verifyBadCode();
    }

    @Test
    public void TC0006_ValidateCorrectLogin_ValidSecurityCodeUponFirstTimeLogin() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.LoginUser("two@two.com", "1Qa!2345");
        logIN.insertSecurityCode(true);

        homePage.verifyGoodLogIn();
    }

    @Test
    public void TC0007_ValidateHomeScreenAfterlogin () {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.LoginUser("two@two.com", "1Qa!2345");
    }

    @Test
    public void TC0008_ValidateErrorMessageLoginScreenEnteringWrongPassword() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.LoginUser("two@two.com", "password");
        logIN.verifyBadLogIn();
    }

    @Test
    public void TC0008_ValidateErrorMessageLoginScreenEnteringWrongUsername() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.LoginUser("user@email.com", "password");
        logIN.verifyBadLogIn();
    }
}