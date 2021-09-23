package test.java.pages;

import org.openqa.selenium.By;
import org.testng.Assert;
import test.java.data.Client;
import test.java.utility.Driver;
import test.java.utility.SwipeAction;

public class BasicHolderJobPage extends BasePage {
    //By elements
    //DATA from INE
    public By textClientName = By.id("com.karum.credits:id/tv_client_name");


    //Contructor
    public BasicHolderJobPage(Driver driver) {
        super(driver);
    }

}