package test.java.pages;

import org.openqa.selenium.By;
import test.java.utility.Driver;

public class PuntosLealtadPage extends BasePage{
    //By
    public By pagarTiendaBtn = By.id("com.karum.credits:id/tv_purchases_main");


    //Contructor
    public PuntosLealtadPage(Driver driver) {
        super(driver);
    }
}