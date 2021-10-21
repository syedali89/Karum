package test.java.tests;

import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;
import test.java.pages.HomePage;
import test.java.pages.SanwichMenuPage;
import test.java.utility.DataRecover;

public class HomePageSuite extends BaseTest {
    public HomePage home;
    @BeforeMethod
    public void beforeMethod(){
        _driver.GetIntance().launchApp();
        logIN.grantAllPermissions();
        clientData = DataRecover.RecoverClientData();

        home = logIN.allLoginProcess(clientData);
    }

    @Test(priority = 1)
    public void TC001_UserHomePage_ValidateElementsHome() {
        home.verifyHomePageElements(clientData);
    }

    @Test(priority = 2)
    public void TC002_UserHomePage_ConsultaSaldoButton() {
        home.tapSaldoCuenta();
        home.verifySaldoCuentaOnScreen();
    }

    @Test(priority = 3)
    public void TC003_UserHomePage_PagarEnTiendaButton() {
        home.tapPagarTiendaBtn();
        home.verifyPagarTiendaOnScreen();
    }

    @Test(priority = 4)
    public void TC004_UserHomePage_MisMovimientosButton() {
        home.tapMisMovimientosBtnBtn();
        home.verifyMisMovimientosPageOnScreen();
    }

    @Test(priority = 5)
    public void TC005_UserHomePage_PuntosDeLealtadButton() {
        home.tapPuntosLealtadBtn();
        home.verifyPuntosLealtadPageOnScreen();
    }

    @Test(priority = 6)
    public void TC006_UserHomePage_SandwichMenuButton() {
        SanwichMenuPage sandwichPage = home.tapSandwichBtn();
        sandwichPage.verifytextElements(clientData);
        sandwichPage.tapCloseBtn();
        home.verifyHomePageOnScreen(clientData);
    }

    @Test(priority = 7)
    public void TC007_UserHomePage_SandwichMenuButton_CerrarSesion() {
        SanwichMenuPage sandwichPage = home.tapSandwichBtn();
        sandwichPage.tapCerrarSesionBtn();


    }
}