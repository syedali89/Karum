package test.java.pages;

import io.appium.java_client.AppiumDriver;
import org.openqa.selenium.By;
import org.testng.Assert;
import test.java.constants;
import test.java.utility.Driver;

public class HomePage extends BasePage{
    private String user;

    //TODO Define correct value for the BYs
    public By pagarTiendaBtn = By.id("pagarTiendaBtn");

    //Contructor
    public HomePage(Driver driver) {
        super(driver);
    }

    public void verifyGoodLogIn()
    {
        Assert.assertTrue(validateElementVisible(pagarTiendaBtn), "Error, element 'Pagar en Tineda' is not visible");
        Assert.assertTrue(validateElementEnable(pagarTiendaBtn), "Error, element 'Pagar en Tineda' is not enabled");
    }
}