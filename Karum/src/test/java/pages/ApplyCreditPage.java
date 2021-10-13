package test.java.pages;

import org.openqa.selenium.By;
import org.testng.Assert;
import test.java.utility.DataRecover;
import test.java.utility.Driver;

public class ApplyCreditPage extends BasePage {
    //By elements
    public By CONTINUARbtn = By.id("com.karum.credits:id/btn_continue");
    public By closeDocumentBtn = By.id("com.karum.credits:id/iv_close_privacy_notice");

    //By authorize
    public By checkboxTerminosCondiciones = By.id("com.karum.credits:id/cb_terms_conditions");
    public By checkboxUsoMediosTecnologicos = By.id("com.karum.credits:id/cb_terms_conditions_electronics");
    public By checkboxConsultaBuroCredito = By.id("com.karum.credits:id/cb_credit_bureau");

    public By linkTextTerminosCondiciones = By.id("com.karum.credits:id/tv_terms_conditions");
    public By linkTextUsoMediosTecnologicos = By.id("com.karum.credits:id/tv_terms_conditions_electronic");
    public By linkTextConsultaBuroCredito = By.id("com.karum.credits:id/tv_credit_bureau_privacy");


    //Contructor
    public ApplyCreditPage(Driver driver) {
        super(driver);
    }

    public void tapTerminosCondiciones() {
        clickElement(linkTextTerminosCondiciones);
    }

    public void tapUsoMediosTecnologicos() {
        clickElement(linkTextUsoMediosTecnologicos);
    }

    public void tapConsultaBuroCredito() {
        clickElement(linkTextConsultaBuroCredito);
    }

    public void tapCloseDocument() {
        clickElement(closeDocumentBtn);
    }

    public void tapCONTINUAR() {
        clickElement(CONTINUARbtn);
    }

    public void tapAllAuthorizeCheckbox() {
        clickElement(checkboxTerminosCondiciones);
        clickElement(checkboxUsoMediosTecnologicos);
        clickElement(checkboxConsultaBuroCredito);
    }

    public PrescreenRequestPage allApplyCreditPage() {
        this.tapAllAuthorizeCheckbox();
        this.tapCONTINUAR();
        return new PrescreenRequestPage(_driver);
    }

    public void verifyContinuarEnabled(boolean enabled) {
        String enabledDisbledMessage = "disabled";
        if(enabled) {
            enabledDisbledMessage = "enabled";
        }

        Assert.assertEquals(validateElementEnable(CONTINUARbtn), enabled,
                "Error , CONTINUAR button should be " + enabledDisbledMessage);
    }

    public void verifyTextApplyForCreditFirstPage() {
        assertElementWithTextExist("Solicitud 5 / 7");
        assertElementWithTextExist("Solicitud de Crédito");
        assertElementWithTextExist("Validaremos tu información crediticia, autoriza la consulta para solicitar tu Crédito");
        Assert.assertTrue(validateElementVisible(checkboxTerminosCondiciones),
                "Error, checkbox for authorize 'Términos y condiciones' is not visible");
        Assert.assertTrue(validateElementVisible(checkboxUsoMediosTecnologicos),
                "Error, checkbox for authorize 'Uso de medios Tecnologicos' is not visible");
        Assert.assertTrue(validateElementVisible(checkboxConsultaBuroCredito),
                "Error, checkbox for authorize 'Consulta datos por buró de crédito y/o Circulo de crédito' is not visible");
        assertElementText(linkTextTerminosCondiciones, "términos y condiciones");
        assertElementText(linkTextUsoMediosTecnologicos, "uso de medios electrónicos");
        assertElementText(linkTextConsultaBuroCredito, "Buró de crédito y/o Círculo de crédito");
    }

    public void verifyTerminosCondicionesDocument() {
        assertElementWithTextExist("Términos y condiciones");
        Assert.assertTrue(validateElementVisible(closeDocumentBtn),
                "Error, close document is not visible");

        //Document Text
        assertDocumentText(
                "Términos y condiciones", DataRecover.TerminosCondicionesDocument());
    }

    public void verifyUsoMediosTecnologicosDocument() {
        assertElementWithTextExist("Términos y condiciones para uso de medios electrónicos");
        Assert.assertTrue(validateElementVisible(closeDocumentBtn),
                "Error, close document is not visible");

        //Document Text
        assertDocumentText(
                "Términos y condiciones para uso de medios electrónicos", DataRecover.UsoMediosTecnologicosDocument());
    }

    public void verifyConsultaBuroCreditoDocument() {
        assertElementWithTextExist("Buró de crédito y/o Círculo de crédito");
        Assert.assertTrue(validateElementVisible(closeDocumentBtn),
                "Error, close document is not visible");

        //Document Text
        assertDocumentText(
                "Buró de crédito y/o Círculo de crédito", DataRecover.BuroCreditoDocument());
    }
}