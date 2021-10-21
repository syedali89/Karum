package test.java.tests;

import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;
import test.java.constants;
import test.java.utility.DataRecover;

public class LogINSuite extends BaseTest {
    @BeforeMethod
    public void beforeMethod(){
        _driver.GetIntance().launchApp();
        logIN.grantAllPermissions();
        clientData = DataRecover.RecoverClientData();
    }

    @Test(priority = 1)
    public void TC031_LOGIN_ExistingClient() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.validateSOYCLIENTELogINEmailPhone();
    }

    @Test(priority = 2)
    public void TC032_LOGIN_AllFiendsMandatory() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.inputEmail(clientData);
        logIN.inputPhone(clientData);

        logIN.verifyCONTINUARbtnState(true);
    }

    @Test(priority = 3)
    public void TC033_LOGIN_EmailFieldInvalidFormat_CONTINUARdisabled() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        clientData.userEmail = "QWERTY";

        logIN.inputEmail(clientData);
        logIN.inputPhone(clientData);

        logIN.verifyCONTINUARbtnState(false);
    }

    @Test(priority = 4)
    public void TC034_LOGIN_PhoneFieldInvalidFormat_CONTINUARdisabled() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        clientData.userPhone = "000";

        logIN.inputEmail(clientData);
        logIN.inputPhone(clientData);

        logIN.verifyCONTINUARbtnState(false);
    }

    @Test(priority = 5)
    public void TC035_LOGIN_IncorrectEmailPhoneCredentials() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        clientData.userEmail = "a@a.a";

        logIN.inputMandatoryFieldThenContinuar(clientData);
        logIN.verifyEmailPhoneIncorrect();
    }

    @Test(priority = 6)
    public void TC036_LOGIN_CorrectEmailPhoneCredentials() {
        logIN.logINClienteAsesor(constants.CLIENTE);

        logIN.inputMandatoryFieldThenContinuar(clientData);
        logIN.verifyMessageActivationCode();
    }

    @Test(priority = 7)
    public void TC037_SecurityCodeLoginPage_ValidateText() {
        logIN.logINClienteAsesor(constants.CLIENTE);

        logIN.inputMandatoryFieldThenContinuar(clientData);
        logIN.verifySecurityCodeLoginText(clientData);
    }

    @Test(priority = 8)
    public void TC038_SecurityCodeLoginPage_SecurityCodeMandatory() {
        logIN.logINClienteAsesor(constants.CLIENTE);

        logIN.inputMandatoryFieldThenContinuar(clientData);
        logIN.inputSecurityCode(false);
        logIN.verifyCONTINUARbtnState(true);
    }

    @Test(priority = 9)
    public void TC039_SecurityCodeLoginPage_WrongSecurityCode() {
        logIN.logINClienteAsesor(constants.CLIENTE);

        logIN.inputMandatoryFieldThenContinuar(clientData);
        logIN.insertSecurityCode(false);
        logIN.verifyBadCode();
    }

    @Test(priority = 10)
    public void TC040_SecurityCodeLoginPage_CorrectSecurityCode() {
        logIN.logINClienteAsesor(constants.CLIENTE);

        logIN.inputMandatoryFieldThenContinuar(clientData);
        logIN.insertSecurityCode(true);
        logIN.verifyPasswordPage(clientData);
    }

    @Test(priority = 11)
    public void TC041_PasswordPage_InputIncorrectPassword() {
        logIN.logINClienteAsesor(constants.CLIENTE);

        logIN.inputMandatoryFieldThenContinuar(clientData);
        logIN.insertSecurityCode(true);

        clientData.userPass = "WRONG";
        logIN.inputPassword(clientData);
        logIN.verifyBadPassword();
    }

    @Test(priority = 12)
    public void TC042_PasswordPage_InputCorrectPassword() {
        logIN.logINClienteAsesor(constants.CLIENTE);

        logIN.inputMandatoryFieldThenContinuar(clientData);
        logIN.insertSecurityCode(true);

        logIN.iniciaSessionPassword(clientData);
        logIN.verifyCorrectPassword();
    }

    @Deprecated
    @Test(enabled = false)
    public void TC001_LOGIN_ExistingClient() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.validateLoginPageSOYCLIENTE(false);
    }

    @Deprecated
    @Test(enabled = false)
    public void TC002_ValidateUsernamefield_Required() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.enterUserCredentials("", "A");
        logIN.validateLoginPageSOYCLIENTE(false);
    }

    @Deprecated
    @Test(enabled = false)
    public void TC002_ValidateUsernamefieldIsEmailFormat() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.enterUserCredentials("username", "A");
        logIN.validateLoginPageSOYCLIENTE(false);
    }

    @Deprecated
    @Test(enabled = false)
    public void TC003_ValidatePasswordfield_Required() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.enterUserCredentials("user@email.com", "");
        logIN.validateLoginPageSOYCLIENTE(false);
    }

    @Deprecated
    @Test(enabled = false)
    public void TC004_ValidateINICIASESIONenables() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.enterUserCredentials("user@email.com", "A");
        logIN.validateLoginPageSOYCLIENTE(true);
    }

    @Deprecated
    @Test(enabled = false)
    public void TC005_ValidateapplicationAskSecurityPinUponLoginForFirstTimeOnlyAfterInstallingApplication () {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.LoginUser(clientData.userName, clientData.userPass);
        logIN.verifyMessageActivationCode();
    }

    @Deprecated
    @Test(enabled = false)
    public void TC006_ValidateErrorMessageEnteringInvalidSecurityCodeUponFirstTimeLogin() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.LoginUser(clientData.userName, clientData.userPass);
        logIN.insertSecurityCode(false);

        logIN.verifyBadCode();
    }

    @Deprecated
    @Test(enabled = false)
    public void TC006_ValidateCorrectLogin_ValidSecurityCodeUponFirstTimeLogin() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.LoginUser(clientData.userName, clientData.userPass);
        logIN.insertSecurityCode(true);

        homePage.verifyGoodLogIn();
    }

    @Deprecated
    @Test(enabled = false)
    public void TC007_ValidateHomeScreenAfterlogin () {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.LoginUser(clientData.userName, clientData.userPass);
    }

    @Deprecated
    @Test(enabled = false)
    public void TC008_ValidateErrorMessageLoginScreenEnteringWrongPassword() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.LoginUser(clientData.userName, clientData.userPass+"W");
        logIN.verifyBadLogIn();
    }

    @Deprecated
    @Test(enabled = false)
    public void TC008_ValidateErrorMessageLoginScreenEnteringWrongUsername() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        logIN.LoginUser(clientData.userName+"W", clientData.userPass);
        logIN.verifyBadLogIn();
    }
}