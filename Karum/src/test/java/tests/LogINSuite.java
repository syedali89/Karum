package test.java.tests;

import org.testng.Reporter;
import org.testng.annotations.Test;
import test.java.pages.HomeMenu;

public class LogINSuite extends BaseTest {

    @Test
    public void correctUserLogIn(){
        HomeMenu menu = new HomeMenu(_driver.GetIntance());

        menu.GoHomePage();
        menu.LoginUser("Selenium", "prueba123");
        menu.verifyUserLogIn();
    }
}