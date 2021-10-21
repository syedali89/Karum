package test.java.pages;

import org.openqa.selenium.By;
import org.testng.Assert;
import test.java.data.Client;
import test.java.utility.Driver;

public class ConsultaSaldoPage extends BasePage{
    //By
    public By pagarTiendaBtn = By.id("com.karum.credits:id/tv_purchases_main");

    //Contructor
    public ConsultaSaldoPage(Driver driver) {
        super(driver);
    }
}