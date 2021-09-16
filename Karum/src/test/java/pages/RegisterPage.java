package test.java.pages;

import io.appium.java_client.AppiumDriver;
import org.openqa.selenium.By;
import org.testng.Assert;
import test.java.constants;
import test.java.utility.Driver;
import test.java.utility.TouchActions;

public class RegisterPage extends BasePage {
    //By elements
    public By registrateGobtn = By.id("com.karum.credits:id/btn_on_boarding");
    public By registrateMessage = By.id("com.karum.credits:id/tv_title_privacy_notice");
    public By registratemebtn = By.id("com.karum.credits:id/btn_register_privacy_notice");
    public By avisoPrivacidadCheckbox = By.id("com.karum.credits:id/cb_privacy_notice");
    public By avisoPrivacidadLink = By.id("com.karum.credits:id/tv_privacy_notice");
    public By avisoPrivacidadClose = By.id("com.karum.credits:id/iv_close_privacy_notice");

    //Contructor
    public RegisterPage(Driver driver, String type) {
        super(driver, type);
    }

    public void goRegistrationPage() {
        clickElement(registrateGobtn);
    }

    public void goAvisoPrivacidad() {
        TouchActions.swipeDownUntilElementExist(_driver.GetIntance(), avisoPrivacidadLink);
        clickElement(avisoPrivacidadLink);
    }

    public void acceptAvisoPrivacidad() {
        TouchActions.swipeDownUntilElementExist(_driver.GetIntance(), avisoPrivacidadCheckbox);
        clickElement(avisoPrivacidadCheckbox);
    }

    public PMLPage tapRegistrarme() {
        TouchActions.swipeDownUntilElementExist(_driver.GetIntance(), registratemebtn);
        clickElement(registratemebtn);
        return new PMLPage(_driver, driverType);
    }

    public void assertRegistrarmeBtnEnabled() {
        Assert.assertTrue(validateElementEnable(registratemebtn), "Error, REGISTRARME button is not enabled after accept 'Aviso Privacidad'.");
    }

    public void assertAvisoPrivacidad() {
        //TODO assert of all the document, but we have to be sure about the content. Now only we evalute the title, the close button and the name of the company
        assertElementWhitTextExist("Aviso de privacidad");
        Assert.assertTrue(validateElementVisible(avisoPrivacidadClose), "Errro, Is not visible button that close 'Aviso Privacidad' document.");
        assertElementWhitTextExist("KUALI SERVICIOS INTEGRALES DE EMPRENDIMIENTO SAPI DE C.V., SOFOM ENR");
        //Validate correct funtion of the close Aviso Privacidad button.
        clickElement(avisoPrivacidadClose);
        Assert.assertTrue(validateElementVisible(registratemebtn), "Error, REGISTRARME button is not visible after tap on close Aviso Privacidad button.");
    }

    public void assertInitialRegistrationPage() {
        assertElementText(registrateMessage, "Regístrate ahora y solicita tu crédito en menos de 5 minutos");
        //TODO assert of all the diferent types of validation that are required for the client to make a account. Now we are only check the Titles.
        assertElementWhitTextExist("Debes contar con la siguiente documentación para iniciar tu registro:");
        assertElementWhitTextExist("Identificación oficial");
        assertElementWhitTextExist("Comprobante de domicilio");
        assertElementWhitTextExist("Registro facial");
        Assert.assertTrue(TouchActions.swipeDownUntilElementExist(_driver.GetIntance(), registratemebtn), "Error, REGISTRARME button is not visible.");
    }
}