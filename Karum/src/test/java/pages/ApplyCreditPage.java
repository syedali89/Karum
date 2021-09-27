package test.java.pages;

import org.openqa.selenium.By;
import org.testng.Assert;
import test.java.data.Client;
import test.java.utility.Driver;
import test.java.utility.SwipeAction;

public class ApplyCreditPage extends BasePage {
    //By elements
    public By CONTINUARbtn = By.id("com.karum.credits:id/btn_continue");

    //By authorize
    public By checkboxTerminosYCondiciones = By.id("com.karum.credits:id/cb_terms_conditions");
    public By checkboxUsoMediosTecnologicos = By.id("com.karum.credits:id/cb_terms_conditions_electronics");
    public By checkboxConsultaBuroCredito = By.id("com.karum.credits:id/cb_credit_bureau");

    public By linkTextTerminosYCondiciones = By.id("com.karum.credits:id/tv_terms_conditions");
    public By linkTextUsoMediosTecnologicos = By.id("com.karum.credits:id/tv_terms_conditions_electronic");
    public By linkTextConsultaBuroCredito = By.id("com.karum.credits:id/tv_credit_bureau_privacy");


    //Contructor
    public ApplyCreditPage(Driver driver) {
        super(driver);
    }

    public void tapCONTIONUARbtn() {
        clickElement(CONTINUARbtn);
    }

    public void verifyTextApplyForCreditFirstPage() {
        assertElementWhitTextExist("Solicitud de Crédito");
        assertElementWhitTextExist("Validaremos tu información crediticia, autoriza la consulta para solicitar tu Crédito");
        Assert.assertTrue(validateElementVisible(checkboxTerminosYCondiciones),
                "Error, checkbox for authorize 'Términos y condiciones' is not visible");
        Assert.assertTrue(validateElementVisible(checkboxUsoMediosTecnologicos),
                "Error, checkbox for authorize 'Uso de medios Tecnologicos' is not visible");
        Assert.assertTrue(validateElementVisible(checkboxConsultaBuroCredito),
                "Error, checkbox for authorize 'Consulta datos por buró de crédito y/o Circulo de crédito' is not visible");
        assertElementText(linkTextTerminosYCondiciones, "términos y condiciones");
        assertElementText(linkTextUsoMediosTecnologicos, "uso de medios electrónicos");
        assertElementText(linkTextConsultaBuroCredito, "Buró de crédito y/o Círculo de crédito");
    }
}