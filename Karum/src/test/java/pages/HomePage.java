package test.java.pages;

import io.appium.java_client.AppiumDriver;
import org.openqa.selenium.By;
import org.testng.Assert;
import test.java.constants;
import test.java.data.Client;
import test.java.utility.Driver;

public class HomePage extends BasePage{
    //By Home buttons
    public By pagarTiendaBtn = By.id("com.karum.credits:id/tv_purchases_main");
    public By misMovimientosBtn = By.id("com.karum.credits:id/tv_movements_main");
    public By estadoCuentaBtn = By.id("com.karum.credits:id/tv_account_status_main");
    public By puntosLealtadBtn = By.id("com.karum.credits:id/tv_loyalty_main");
    public By consultaSaldoBtn = By.id("com.karum.credits:id/tv_balance_consult_main");
    //By Sandwich Area
    public By sandwichBtn = By.id("com.karum.credits:id/iv_home_menu_header");
    public By greetingsClient = By.id("com.karum.credits:id/tv_title_header");
    //By CreditoKarum
    public By numberClient = By.id("com.karum.credits:id/tv_credit_card_main");
    public By totalamountClient = By.id("com.karum.credits:id/tv_credit_balance_main");


    //Contructor
    public HomePage(Driver driver) {
        super(driver);
    }

    public void verifyHomePageElements(Client clientData) {
        String lastPhone = clientData.PhoneNumber.substring(clientData.PhoneNumber.length() - 4);

        assertElementWithTextExist("Crédito Karum");
        assertElementText(numberClient, "************" + lastPhone);

        assertElementText(totalamountClient, clientData.accountAmount);
        Assert.assertTrue(validateElementVisible(consultaSaldoBtn),
                "Error,  'Consulta de saldo' button is not visible");
        Assert.assertTrue(validateElementVisible(pagarTiendaBtn),
                "Error,  'Pagar en Tienda' button is not visible");
        Assert.assertTrue(validateElementVisible(misMovimientosBtn),
                "Error,  'Mis mivimientos' button is not visible");
        Assert.assertTrue(validateElementVisible(estadoCuentaBtn),
                "Error,  'Estado de cuenta' button is not visible");
        Assert.assertTrue(validateElementVisible(puntosLealtadBtn),
                "Error,  'Puntos de lealtad' button is not visible");
    }

    public void verifyHomePageOnScreen(Client clientData) {
        String lastPhone = clientData.PhoneNumber.substring(clientData.PhoneNumber.length() - 4);

        assertElementWithTextExist("Crédito Karum");
        assertElementText(numberClient, "************" + lastPhone);
    }

    public ConsultaSaldoPage tapSaldoCuenta() {
        clickElement(consultaSaldoBtn);
        return new ConsultaSaldoPage(_driver);
    }

    public PagarTiendaPage tapPagarTiendaBtn() {
        clickElement(pagarTiendaBtn);
        return new PagarTiendaPage(_driver);
    }

    public MisMovimientosPage tapMisMovimientosBtnBtn() {
        clickElement(misMovimientosBtn);
        return new MisMovimientosPage(_driver);
    }

    public PuntosLealtadPage tapPuntosLealtadBtn() {
        clickElement(puntosLealtadBtn);
        return new PuntosLealtadPage(_driver);
    }

    public SanwichMenuPage tapSandwichBtn() {
        clickElement(sandwichBtn);
        return new SanwichMenuPage(_driver);
    }

    public void verifySaldoCuentaOnScreen() {
        assertElementText(headerTitle, "Saldo");
    }

    public void verifyPagarTiendaOnScreen() {
        assertElementText(headerTitle, "Pagar en tienda");
    }

    public void verifyMisMovimientosPageOnScreen() {
        assertElementText(headerTitle, "Mis movimientos");
    }

    public void verifyPuntosLealtadPageOnScreen() {
        assertElementText(headerTitle, "Puntos de lealtad");
    }

    @Deprecated
    public void verifyGoodLogIn() {
        Assert.assertTrue(validateElementVisible(pagarTiendaBtn), "Error, element 'Pagar en Tienda' is not visible");
    }
}