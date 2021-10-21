package test.java.pages;

import org.openqa.selenium.By;
import org.testng.Assert;
import test.java.data.Client;
import test.java.utility.DataRecover;
import test.java.utility.Driver;

public class SignContractPage extends BasePage {
    //By elements
    public By CONTINUARbtn = By.id("com.karum.credits:id/btn_continue");

    //Contructor
    public SignContractPage(Driver driver) {
        super(driver);
    }

    public void verifyCONTINUARState(boolean state) {
        String enabledDisabled = "disabled";
        if(state) {
            enabledDisabled = "enabled";
        }
        Assert.assertEquals(validateElementEnable(CONTINUARbtn), state,
                "Error, 'CONTINUE' button should be " + enabledDisabled);
    }
}