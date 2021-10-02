package test.java.pages;

import org.openqa.selenium.By;
import org.testng.Assert;
import test.java.data.Client;
import test.java.utility.DataRecover;
import test.java.utility.Driver;

public class RegSecureCode extends BasePage {
    //By elements
    public By inputSecureCode = By.id("com.karum.credits:id/pv_otp");
    public By resendSecureCode = By.id("com.karum.credits:id/btn_resend_sms");
    public By resendCounter = By.id("com.karum.credits:id/tv_counter_sms");
    public By VALIDARbtn = By.id("com.karum.credits:id/btn_validate");
    public By ACEPTARbtn = By.xpath("//*[@text='ACEPTAR']");

    //Contructor
    public RegSecureCode(Driver driver) {
        super(driver);
    }

    public void waitCountdown() {
        waitNotVisibility(resendCounter);
    }

    public void tapEnviarCodido() {
        clickElement(resendSecureCode);
    }

    public void tapACEPTAR() {
        clickElement(ACEPTARbtn);
    }

    public void insertSecurityCode(boolean correct) {
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

        sendTextElement(inputSecureCode, code);
        clickElement(VALIDARbtn);
    }

    public void verifyWrongSecurity() {
        //TODO There are a bug because any code is valid
    }

    public void verifyCorrectSecurityCode() {
        assertElementWithTextExist("Solicitud");
        assertElementWithTextExist("Valida y completa tu información laboral para solicitar tu crédito");
    }

    public void verifyAlertSendCode() {
        assertElementWithTextExist("El código se envió exitosamente");
        Assert.assertTrue(validateElementVisible(ACEPTARbtn),
                "Error, ACEPTAR button is not visible");
    }

    public void verifyResendSecureCodePage() {
        assertElementWithTextExist(
                "Nota: Espera que termine el tiempo para solicitar tu código nuevamente");
        assertElementText(resendSecureCode, "Enviar de nuevo");
        Assert.assertTrue(validateElementVisible(resendCounter),
                "Error, Resend Security code Countdown is not visible");
        //TODO Evaluate that code es resend
    }

    public void verifySecureCodePage(Client clientData) {
        String lastPhone = clientData.PhoneNumber.substring(clientData.PhoneNumber.length() - 4);
        assertElementWithTextExist("Validación de solicitud");
        assertElementWithTextExist(
                "Ingresa el código de validación que te enviamos por SMS al ******" + lastPhone);
        Assert.assertTrue(validateElementVisible(inputSecureCode),
                "Error, the input field for secure Code is not visible");
        assertElementWithTextExist("¿No recibiste el código?");
        assertElementWithTextExist(
                "Nota: Espera que termine el tiempo para solicitar tu código nuevamente");
        assertElementText(resendSecureCode, "Enviar de nuevo");
        Assert.assertTrue(validateElementVisible(resendCounter),
                "Error, Resend Security code Countdown is not visible");
        Assert.assertTrue(validateElementVisible(VALIDARbtn),
                "Error, VALIDAR button is not visible");
    }
}