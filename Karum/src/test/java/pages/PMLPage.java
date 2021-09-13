package test.java.pages;

import io.appium.java_client.AppiumDriver;
import org.openqa.selenium.By;
import org.testng.Assert;
import test.java.utility.TouchActions;

import java.util.Arrays;
import java.util.List;

//PreventMoneyLaunderingPageObject
public class PMLPage extends BasePage {
    //By elements
    public By continueBtn = By.id("com.karum.credits:id/btn_continue");

    //Other Variables
    public enum aceptoField
    {
        SIACEPTO,
        NOACEPTO,
        UNINFORMED
    }

    public List<aceptoField> aceptoButtons = Arrays.asList(new aceptoField[]
            {
                    aceptoField.UNINFORMED,
                    aceptoField.UNINFORMED,
                    aceptoField.UNINFORMED,
                    aceptoField.UNINFORMED,
                    aceptoField.UNINFORMED,
                    aceptoField.UNINFORMED});

    //Contructor
    public PMLPage(AppiumDriver driver, String type) {
        super(driver, type);
    }

    public void SetSINOACEPTOradioButton(aceptoField siNoAcepto, int position) {
        --position;
        aceptoButtons.set(position, siNoAcepto);
    }

    public void SetAllFieldsSINOACEPTO(aceptoField siNoAcepto) {
        for(int position = 0; position<aceptoButtons.size(); position++)
        {
            aceptoButtons.set(position, siNoAcepto);
        }
    }
    
    public void tapACEPTOFields() {
        int position = 1;
        for (aceptoField radiobutton: aceptoButtons)
        {
            tapRadiobuttonSINOAcepto(radiobutton, position);
            position++;
        }
    }

    public void assertContinueBtnDisable() {
        TouchActions.swipeDownUntilElementExist(_driver, continueBtn);
        Assert.assertTrue(!validateElementEnable(continueBtn), "Error, CONTINUE button is enabled and all 'SI ACEPTO' aren't selected.");
    }

    public void assertContinueBtnEnable() {
        TouchActions.swipeDownUntilElementExist(_driver, continueBtn);
        Assert.assertTrue(validateElementEnable(continueBtn), "Error, CONTINUE button is disable and all 'SI ACEPTO' are selected.");
    }

    public void assertPMLText() {
        assertElementWhitTextExist(
                "Te queremos conocer mejor, por favor responde las preguntas para poder hacerlo:");
        assertElementWhitTextExist(
                "Declaro bajo protesta de decir la verdad que no desempeño actualmente ni durante el año inmediato anterior algún cargo público destacado a nivel federal, estatal, municipal o distrito en México o en el extranjero.");
        assertElementWhitTextExist(
                "Declaro también que mi cónyuge, en su caso, o pariente por consanguinidad o afinidad hasta el 2º grado, no desempeña actualmente ni durante el año inmediato anterior ningún cargo público destacado a nivel federal, estatal, municipal o distrital en México o en el extranjero.");
        assertElementWhitTextExist(
                "Declaro que ningún tercero obtendrá los beneficios derivados de las operaciones realizadas con KUALI SERVICIOS INTEGRALES DE EMPRENDIMIENTO SAPI DE C.V SOFOM E.N.R. ni ejercerá los derechos de uso, aprovechamiento o disposición de los recursos operados, siendo el verdadero propietario de los mismos. (Propietario real)");
        assertElementWhitTextExist(
                "Declaro que ningún tercero aportará regularmente recursos para el cumplimiento de las obligaciones derivadas del contrato que se establece con KUALI SERVICIOS INTEGRALES DE EMPRENDIMIENTO SAPI DE C.V SOFOM E.N.R. sin ser el titular de dicho contrato ni obtener los beneficios económicos derivados del mismo.");
        assertElementWhitTextExist(
                "Declaro que bajo protesta de decir verdad que para efectos de la realización de las operaciones con KUALI SERVICIOS INTEGRALES DE EMPRENDIMIENTO SAPI DE C.V SOFOM E.N.R. estoy actuando por cuenta propia.");
        assertElementWhitTextExist(
                "Declaro que los recursos que utilizaré para el pago de este producto provienen de una fuente licita.");

        Assert.assertTrue(TouchActions.swipeDownUntilElementExist(_driver, continueBtn), "Error, CONTINUE button doesn't exist");
    }

    public void tapRadiobuttonSINOAcepto(aceptoField aceptoFieldradiobutton, int radPosition) {
        if(aceptoFieldradiobutton != aceptoField.UNINFORMED) {
            By tapField;

            if (aceptoFieldradiobutton == aceptoField.SIACEPTO) {
                tapField = By.id("com.karum.credits:id/rb_yes_" + radPosition);
                TouchActions.swipeDownUntilElementExist(_driver, tapField);
                clickElement(tapField);
            } else if (aceptoFieldradiobutton == aceptoField.NOACEPTO) {
                tapField = By.id("com.karum.credits:id/rb_no_" + radPosition);
                TouchActions.swipeDownUntilElementExist(_driver, tapField);
                clickElement(tapField);
            }
        }
    }
}