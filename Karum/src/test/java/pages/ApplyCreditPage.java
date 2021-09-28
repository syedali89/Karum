package test.java.pages;

import org.openqa.selenium.By;
import org.testng.Assert;
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

    public RegSecureCode allApplyCreditPage() {
        this.tapAllAuthorizeCheckbox();
        this.tapCONTINUAR();
        return new RegSecureCode(_driver);
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
        assertElementWithTextExist(
                "Estos Términos y Condiciones regulan el uso del sitio web (en lo sucesivo el “Portal”) y la aplicación de KARUM LATIN AMERICA, S. DE R.L. DE C.V. (“KARUM”) (en lo sucesivo la “App de KARUM”) así como todas aquellas operaciones relacionadas con el uso de dicha aplicación. Estos términos constituyen un acuerdo de voluntades entre KARUM (a quien en adelante nos podremos referir como “KARUM”, “nosotros”, nuestro) y usted (a quien en adelante nos podremos referir como “Usuario”, “Cliente”, “usted”, “suyo”, en plural o singular).");
        assertElementWithTextExist(
                "Declara KARUM ser una Sociedad de Responsabilidad Limitada de Capital Variable, cuyo nombre comercial es KARUM, con domicilio en Blvd. Manuel Ávila Camacho No. 5 Interior S 1000, Ed. Torre B, P. 10, Of. 1045, Fracc. Lomas de Sotelo, Naucalpan de Juárez, Estado de Mexico, C.P. 53390. Los presentes Términos y Condiciones se encuentran disponibles a través del sitio web");
        assertElementWithTextExist(
                "www.karum.com");
        assertElementWithTextExist(
                "y la App de KARUM, disponible para los sistemas operativos iOS y Android.");
        assertElementWithTextExist(
                "Declara el Usuario ser una persona mayor de edad y contar con capacidad para contratar y contraer toda clase de obligaciones. Asimismo, declara que entiende plenamente el contenido de los presentes Términos y Condiciones. Si alguna parte de los presentes Términos y Condiciones no le parecen aceptables o no le son comprensibles en su totalidad, requerimos que el Usuario suspenda el uso de la App de KARUM y termine la relación con KARUM. El acceso y uso del Usuario en la aplicación de KARUM implican la aceptación de los Términos y Condiciones expresados en el presente acuerdo.");
        assertElementWithTextExist(
                "Para los efectos del presente acuerdo, las partes acuerdan que por Usuario se entenderá: cualquier persona física o moral que contrate una cuenta, ingrese, acceda y/o utilice la App de KARUM (incluyendo cualquiera de los elementos que despliegan su contenido) y/o a la persona física o moral que se registre y/o use, cualquiera de los servicios que se ofrecen a través de dicha aplicación o este sitio web."
        );
        assertElementWithTextExist(
                "Durante el uso de la aplicación el Usuario manifestará expresamente su consentimiento sobre estos Términos y Condiciones a través del uso de medios electrónicos al darse de alta en la App de KARUM y llevará a cabo una o múltiples acciones afirmativas que impliquen una interacción activa del Usuario con la aplicación y de la cual se permita derivar la manifestación de su consentimiento expreso. Asimismo, declara expresamente su aceptación utilizando para tal efecto medios electrónicos para la manifestación de su voluntad, en términos de lo dispuesto por el Código Civil Federal, el Código de Comercio, Código Civil para el Distrito Federal (hoy Ciudad de México) y demás legislación aplicable."
        );

        //TODO Add all document using files in a more easy way
    }

    public void verifyUsoMediosTecnologicosDocument() {
        assertElementWithTextExist("Términos y condiciones para uso de medios electrónicos");

        //TODO Add all document  using files in a more easy way
    }

    public void verifyConsultaBuroCreditoDocument() {
        assertElementWithTextExist("Buró de crédito y/o Círculo de crédito");


        //TODO Add all document using files in a more easy way
    }
}