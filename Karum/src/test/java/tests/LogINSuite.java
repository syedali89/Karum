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
    public void TC005_ValidateapplicationAskSecurityPinUponLoginForFirstTimeOnlyAfterInstallingApplication () {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.LoginUser(clientData.userName, clientData.userPass);
        logIN.verifyMessageActivationCode();
    }

    @Test
    public void TC006_ValidateErrorMessageEnteringInvalidSecurityCodeUponFirstTimeLogin() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.LoginUser(clientData.userName, clientData.userPass);
        logIN.insertSecurityCode(false);

        logIN.verifyBadCode();
    }

    @Test
    public void TC006_ValidateCorrectLogin_ValidSecurityCodeUponFirstTimeLogin() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.LoginUser(clientData.userName, clientData.userPass);
        logIN.insertSecurityCode(true);

        homePage.verifyGoodLogIn();
    }

    @Test
    public void TC007_ValidateHomeScreenAfterlogin () {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.LoginUser(clientData.userName, clientData.userPass);
    }

    @Test
    public void TC008_ValidateErrorMessageLoginScreenEnteringWrongPassword() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.LoginUser(clientData.userName, clientData.userPass);
        logIN.verifyBadLogIn();
    }

    @Test
    public void TC008_ValidateErrorMessageLoginScreenEnteringWrongUsername() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.LoginUser(clientData.userName, clientData.userPass);
        logIN.verifyBadLogIn();
    }
}