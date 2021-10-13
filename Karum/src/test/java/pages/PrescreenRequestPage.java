package test.java.pages;

import org.openqa.selenium.By;
import org.testng.Assert;
import test.java.data.Client;
import test.java.utility.DataRecover;
import test.java.utility.Driver;
import test.java.utility.SwipeAction;

public class PrescreenRequestPage extends BasePage {
    //By elements
    public By inputSecureCode = By.id("com.karum.credits:id/pv_otp");
    public By resendSecureCode = By.id("com.karum.credits:id/btn_resend_sms");
    public By resendCounter = By.id("com.karum.credits:id/tv_counter_sms");
    public By VALIDARbtn = By.id("com.karum.credits:id/btn_validate");
    public By CONTINUARbtn = By.id("com.karum.credits:id/btn_continue");
    public By ACEPTARbtn = By.xpath("//*[@text='ACEPTAR']");
    public By successRequestImage = By.id("com.karum.credits:id/iv_success_request");

    //By Job Information
    public By CompanyName = By.id("com.karum.credits:id/tv_company_name");
    public By MonthlyIncome = By.id("INCOME");
    public By CompanyPhone = By.id("com.karum.credits:id/et_phone");
    public By CompanyAreaPhone = By.id("com.karum.credits:id/et_code_area");
    public By ErrorCompanyPhone = By.id("com.karum.credits:id/tv_error_no_match");

    //By Password Information
    public By UserEmail = By.id("com.karum.credits:id/tv_username");
    public By inputPassword = By.id("com.karum.credits:id/et_request_pass");
    public By inputConfirmPassword = By.id("com.karum.credits:id/et_request_pass_confirm");

    //Contructor
    public PrescreenRequestPage(Driver driver) {
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

    public void tapCONTINUAR() {
        clickElement(CONTINUARbtn);
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

    public void insertCompanyPhone(String phone) {
        sendTextElement(CompanyPhone, phone);
    }

    public void insertPasswordField(String pass, String confirmPass) {
        sendTextElement(inputPassword, pass);
        sendTextElement(inputConfirmPassword, confirmPass);
    }

    public void insertPasswordField(Client clientData) {
        sendTextElement(inputPassword, clientData.userPass);
        sendTextElement(inputConfirmPassword,  clientData.userPass);
    }

    public SignContractPage allProcessPrescreenRequestPage(Client clientData) {
        this.insertSecurityCode(true);
        this.insertCompanyPhone(clientData.CompanyPhoneNumber);
        this.tapCONTINUAR();
        clientData.userPass = "QWERTY#w1";

        this.insertPasswordField(clientData);
        this.tapCONTINUAR();
        this.tapCONTINUAR();

        return new SignContractPage(_driver);
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

    public void verifyCONTINUARState(boolean state) {
        String enabledDisabled = "disabled";
        if(state) {
            enabledDisabled = "enabled";
        }
        Assert.assertEquals(validateElementEnable(CONTINUARbtn), state,
                "Error, 'CONTINUE' button should be " + enabledDisabled);
    }

    public void verifyPersonalPhoneEqualCompanyNumber() {
        assertElementText(ErrorCompanyPhone, "El teléfono de empresa debe ser diferente al celular registrado en el domicilio");
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

    public void verifyAfterSecureCodePage(Client clientData) {
        assertElementWithTextExist("Solicitud");
        assertElementWithTextExist(
                "Valida y completa tu información laboral para solicitar tu crédito");
        assertElementText(inputSecureCode,"Empresa");
        assertElementText(CompanyName, clientData.jobCompany);
        assertElementWithTextExist("Ingreso mensual");
        assertElementText(MonthlyIncome, clientData.income);
        assertElementWithTextExist("Teléfono de empresa *");
        assertElementWithTextExist("País *");
        Assert.assertTrue(validateElementVisible(CompanyAreaPhone),
                "Error, Company area phone input is not visible");
        Assert.assertTrue(validateElementVisible(CompanyPhone),
                "Error, Company phone input is not visible");
        Assert.assertTrue(validateElementVisible(CONTINUARbtn),
                "Error, CONTINUAR button is not visible");
        assertElementWithTextExist("* Campos obligatorios");
    }

    public void verifySolicitudPasswordText(Client clientData) {
        assertElementWithTextExist("Solicitud");
        assertElementWithTextExist(
                "Es necesario estar registrado para solicitar tu crédito, genera tu contraseña");
        assertElementText(UserEmail, clientData.Email);
        assertElementWithTextExist("Crea tu contraseña");
        assertElementWithTextExist("Contraseña *");
        Assert.assertTrue(validateElementVisible(inputPassword),
                "Error, Password input is not visible");
        assertElementWithTextExist("Repetir contraseña *");
        Assert.assertTrue(validateElementVisible(inputConfirmPassword),
                "Error, Confirm Password input is not visible");

        assertElementWithTextExist("* Campos obligatorios");
        assertElementWithTextExist("La contraseña debe incluir:");
        assertElementWithTextExist("Mínimo 8 caracteres");
        assertElementWithTextExist("Al menos una mayúscula");
        assertElementWithTextExist("Al menos una minúscula");
        assertElementWithTextExist("Al menos un número");
        assertElementWithTextExist("Al menos un caracter especial");
        assertElementWithTextExist("Caracteres permitidos: #$&-.?@_+!");


        Assert.assertTrue(validateElementVisible(CONTINUARbtn),
                "Error, CONTINUAR button is not visible");
    }

    public void verifyErrorPasswordsDifferent() {
        assertElementWithTextExist("Las contraseñas no coinciden");
        verifyCONTINUARState(false);
    }

    public void verifyProcesoEvaluacionText() {
        assertElementWithTextExist("En proceso de evaluación, por favor termina la captura de información");
        Assert.assertTrue(validateElementVisible(successRequestImage),
                "Error, Success Image is not visible");
        verifyCONTINUARState(true);
    }
}