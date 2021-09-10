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