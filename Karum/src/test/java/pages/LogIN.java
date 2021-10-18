package test.java.pages;

import io.appium.java_client.AppiumDriver;
import org.openqa.selenium.By;
import org.testng.Assert;
import test.java.constants;
import test.java.data.Client;
import test.java.utility.DataRecover;
import test.java.utility.Driver;

public class LogIN extends BasePage{
    private String user;

    //LogIN
    public By soyClienteBtn = By.id("com.karum.credits:id/btn_client");
    public By inputemail = By.id("com.karum.credits:id/et_email");
    public By inputPhoneNumber = By.id("com.karum.credits:id/et_phone");
    public By inputPhoneNumberArea = By.id("com.karum.credits:id/et_code_area");
    public By registrateGobtn = By.id("com.karum.credits:id/btn_on_boarding");
    public By CONTINUARbtn = By.id("com.karum.credits:id/btn_continue");
    public By titleScreenCLIENTE = By.id("com.karum.credits:id/tv_title_login");
    public By alertMessage = By.id("android:id/message");

    //Password
    public By logINPassword = By.id("com.karum.credits:id/et_pass_login");
    public By userEmailOnScreen = By.id("com.karum.credits:id/tv_username");
    public By changeUserBtn = By.id("com.karum.credits:id/tv_change_user");
    public By iniciaSesionBtn = By.id("com.karum.credits:id/btn_login");

    @Deprecated
    public By logINemail = By.id("com.karum.credits:id/et_email_login");
    @Deprecated
    public By alertMessageBadCredentials = By.id("com.karum.credits:id/tv_error_login");

    //Security Code Menu
    public By greatingsActivationDevice = By.id("com.karum.credits:id/tv_sms_title");
    public By messageActivationDevice = By.id("com.karum.credits:id/tv_instructions_sms");
    public By inputSecurityCode = By.id("com.karum.credits:id/pv_otp");
    public By continueBtn = By.id("com.karum.credits:id/btn_continue");
    public By alertMessageBadCode = By.id("com.karum.credits:id/tv_error_login");
    public By resendcodeLinktext = By.id("com.karum.credits:id/btn_resend_sms");

    //Contructor
    public LogIN(Driver driver) {
        super(driver);
    }

    public void logINClienteAsesor(String type) {
        if(type.equals(constants.CLIENTE)) {
            clickElement(soyClienteBtn);
        }
    }

    public void inputSecurityCode(boolean correct) {
        String code;
        if(correct) {
            code = DataRecover.RecoverSecurityCode();

            if(code.isEmpty()) {
                code = "000000";
            }
        }
        else {
            code = "111111";
        }

        sendTextElement(inputSecurityCode, code);
    }

    public void insertSecurityCode(boolean correct) {
        inputSecurityCode(correct);
        clickElement(continueBtn);
    }

    public void inputEmail(Client client) {
        sendTextElement(inputemail, client.userEmail);
    }

    public void inputPhone(Client client) {
        sendTextElement(inputPhoneNumber, client.userPhone);
    }

    public void inputPassword(Client client) {
        sendTextElement(logINPassword, client.userPass);
    }

    public void inputMandatoryFieldThenContinuar(Client client) {
        inputEmail(client);
        inputPhone(client);
        clickElement(CONTINUARbtn);
    }

    public void iniciaSessionPassword(Client client) {
        inputPassword(client);
        clickElement(iniciaSesionBtn);
    }

    public void verifyBadCode() {
        assertElementText(alertMessageBadCode, "Código incorrecto, inténtalo nuevamente");
    }

    public void verifyMessageActivationCode() {
        Assert.assertTrue(validateElementVisible(inputSecurityCode),
                "Error, Security Code Input Field is not visible.");
    }

    public void verifySecurityCodeLoginText(Client client) {
        String lastPhone = client.userPhone.substring(client.userPhone.length() - 4);

        assertElementText(greatingsActivationDevice, "Hola, "+ client.firstNameOne);
        assertElementText(messageActivationDevice, "Activa tu dispositivo, ingresando el código de activación que te enviamos por SMS al ******" + lastPhone);
        assertElementText(resendcodeLinktext, "Enviar de nuevo");
        assertElementWithTextExist("¿No recibiste el código?");

        Assert.assertTrue(validateElementVisible(inputSecurityCode),
                "Error, Security Code Input Field is not visible.");

        Assert.assertTrue(validateElementVisible(CONTINUARbtn),
                "Error, CONTINUAR button is not visible.");
    }

    public void verifyCONTINUARbtnState(boolean isEnable) {
        String enabledDisabledMessage = "disabled";
        if(isEnable) {
            enabledDisabledMessage = "enabled";
        }

        Assert.assertEquals(validateElementEnable(CONTINUARbtn), isEnable,
                "Error, CONTINUAR btn input should be " + enabledDisabledMessage);
    }

    public void validateSOYCLIENTELogINEmailPhone() {
        assertElementText(titleScreenCLIENTE, "Comienza a comprar\n" +
                "desde tu celular");

        assertElementWithTextExist("Ingresa tu número celular (10 digitos) *");
        Assert.assertTrue(validateElementVisible(inputPhoneNumber), "Error, input phone number field is not visible.");
        Assert.assertTrue(validateElementVisible(inputPhoneNumberArea), "Error, input phone area field is not visible.");

        assertElementWithTextExist("Correo electrónico *");
        Assert.assertTrue(validateElementVisible(inputemail), "Error, input phone number field is not Visible.");

        assertElementWithTextExist("* Campos obligatorios");
        assertElementWithTextExist("No tienes cuenta,");
        Assert.assertTrue(validateElementVisible(registrateGobtn), "Error, registrate linktext is not Visible.");

        Assert.assertTrue(validateElementVisible(CONTINUARbtn), "Error, CONTINUAR button is not Visible.");
        verifyCONTINUARbtnState(false);
    }

    public void verifyEmailPhoneIncorrect() {
        assertElementText(alertMessage, "Los datos proporcionados no coinciden con ningun registro");
        assertElementWithTextExist("ACEPTAR");
    }

    public void verifyPasswordPage(Client client) {
        assertElementWithTextExist("Hola, "+ client.firstNameOne);
        assertElementWithTextExist("Usuario");
        assertElementText(userEmailOnScreen, client.userEmail);
        assertElementText(changeUserBtn, "Cambiar usuario");

        assertElementWithTextExist("Contraseña *");
        assertElementWithTextExist("* Campos");
        Assert.assertTrue(validateElementVisible(logINPassword),
                "Error, input Password field is not visible");

        assertElementText(iniciaSesionBtn, "INICIA SESIÓN");
    }

    public void verifyBadPassword() {
        assertElementWithTextExist("Contraseña incorrecta");
    }

    public void verifyCorrectPassword() {
        assertElementWithTextExist("Crédito Karum");
    }

    @Deprecated
    public void enterUserCredentials(String user, String pass) {
        sendTextElement(logINemail, user);
        sendTextElement(logINPassword, pass);
    }

    @Deprecated
    public void LoginUser(String user, String pass) {
        enterUserCredentials(user, pass);
        clickElement(iniciaSesionBtn);
        this.user = user;
    }

    @Deprecated
    public void validateLoginPageSOYCLIENTE(boolean isEnabled) {
        String state = "Disabled";
        if(isEnabled) {
            state = "Enabled";
        }

        Assert.assertTrue(validateElementVisible(logINemail), "Error, Username/Email field is Not Visible.");
        Assert.assertTrue(validateElementVisible(logINPassword), "Error, Password field is Not Visible.");
        Assert.assertTrue(validateElementVisible(iniciaSesionBtn), "Error, 'INICIA SESION' Button is Not Visible.");
        Assert.assertEquals(isEnabled, validateElementEnable(iniciaSesionBtn),
                "Error, 'INICIA SESION' Email and Password are mandatory and 'INICIA SESION' has to be "+ state + ".");
    }

    @Deprecated
    public void verifyBadLogIn() {
        assertElementText(alertMessageBadCredentials, "Usuario y contraseña incorrecta");
    }
}