package test.java.pages;

import org.openqa.selenium.By;
import org.testng.Assert;
import test.java.data.Client;
import test.java.utility.Driver;

public class SanwichMenuPage extends BasePage{
    //By
    public By closeBtn = By.id("close");
    public By userNameDisplay = By.id("username");
    public By cerrarSesionBtn = By.id("cerrarsesion");

    //Contructor
    public SanwichMenuPage(Driver driver) {
        super(driver);
    }

    public void verifytextElements(Client clientData) {
        Assert.assertTrue(validateElementVisible(closeBtn), "Error, close button is not visible");
        assertElementText(userNameDisplay, clientData.firstNameOne + " " + clientData.lastNameOne);
        Assert.assertTrue(validateElementVisible(cerrarSesionBtn), "Error, 'Cerrar Sesión' button is not visible");
    }

    public void tapCloseBtn() {
        clickElement(closeBtn);
    }

    public void tapCerrarSesionBtn() {
        clickElement(cerrarSesionBtn);
    }
}