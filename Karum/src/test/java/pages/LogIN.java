package test.java.pages;

import io.appium.java_client.AppiumDriver;
import org.openqa.selenium.By;
import org.testng.Assert;
import test.java.constants;

public class LogIN extends BasePage{
    private String user;

    public By soyClienteBtn = By.id("com.karum.credits:id/btn_client");
    public By logINemail = By.id("com.karum.credits:id/et_email_login");
    public By logINPassword = By.id("com.karum.credits:id/et_pass_login");
    public By iniciaSesionBtn = By.id("com.karum.credits:id/btn_login");
    public By alertMessage = By.id("android:id/message");

    //Contructor
    public LogIN(AppiumDriver driver, String type) {
        super(driver, type);
    }

    public void logINClienteAsesor(String type)
    {
        if(type.equals(constants.CLIENTE))
        {
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

    public void verifyBadLogIn()
    {
        assertElementText(alertMessage, "Tu solicitud no puede ser atendida por el momento, por favor intenta más tarde.");
    }

    public void validateLoginPageSOYCLIENTE(boolean isenabled)
    {
        Assert.assertTrue(validateElementVisible(logINemail), "Error, Username/Email field is Not Visible.");
        Assert.assertTrue(validateElementVisible(logINPassword), "Error, Password field is Not Visible.");
        Assert.assertTrue(validateElementVisible(iniciaSesionBtn), "Error, 'INICIA SESION' Button is Not Visible.");
        Assert.assertEquals(isenabled, validateElementEnable(iniciaSesionBtn),
                "Error, 'INICIA SESION' Email and Password are mandatory and 'INICIA SESION' has to be Disable or Enable depending of context.");
    }
}