package test.java.pages;

import io.appium.java_client.AppiumDriver;
import org.openqa.selenium.By;
import org.testng.Assert;
import test.java.constants;
import test.java.utility.Driver;

public class LogIN extends BasePage{
    private String user;

    //LogIN
    public By soyClienteBtn = By.id("com.karum.credits:id/btn_client");
    public By logINemail = By.id("com.karum.credits:id/et_email_login");
    public By logINPassword = By.id("com.karum.credits:id/et_pass_login");
    public By iniciaSesionBtn = By.id("com.karum.credits:id/btn_login");
    public By alertMessage = By.id("android:id/message");
    public By alertMessageBadCredentials = By.id("com.karum.credits:id/tv_error_login");
    //Security Code Menu
    public By greatingsActivationDevice = By.id("com.karum.credits:id/tv_sms_title");
    public By messageActivationDevice = By.id("com.karum.credits:id/tv_instructions_sms");
    public By inputSecurityCode = By.id("com.karum.credits:id/pv_otp");
    public By continueBtn = By.id("com.karum.credits:id/btn_continue");
    public By alertMessageBadCode = By.id("com.karum.credits:id/tv_error_login");

    //Contructor
    public LogIN(Driver driver) {
        super(driver);
    }

    public void logINClienteAsesor(String type)
    {
        if(type.equals(constants.CLIENTE)) {
            clickElement(soyClienteBtn);
        }
    }

    public void enterUserCredentials(String user, String pass) {

        sendTextElement(logINemail, user);
        sendTextElement(logINPassword, pass);
    }

    public void LoginUser(String user, String pass)
    {
        enterUserCredentials( user, pass);
        clickElement(iniciaSesionBtn);
        this.user = user;
    }

    public void insertSecurityCode(boolean correct) {
        String code = "";
        if(correct) {
            //TODO recover the correct number for the testing
        }
        else {
            code = "111111";
        }

        sendTextElement(inputSecurityCode, code);
        clickElement(continueBtn);
    }

    public void verifyBadLogIn()
    {
        assertElementText(alertMessageBadCredentials, "Usuario y contraseña incorrecta");
    }

    public void verifyBadCode()
    {
        assertElementText(alertMessageBadCode, "Código incorrecto, inténtalo nuevamente");
    }

    public void verifyMessageActivationCode()
    {
        assertElementText(greatingsActivationDevice, "Hola, Jose");
        assertElementText(messageActivationDevice, "Activa tu dispositivo, ingresando el código de activación que te enviamos por SMS al ******5614");
    }

    public void validateLoginPageSOYCLIENTE(boolean isEnabled)
    {
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
}