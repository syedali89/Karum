package test.java.pages;

import io.appium.java_client.android.AndroidDriver;
import io.appium.java_client.android.AndroidElement;
import org.openqa.selenium.Alert;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.pagefactory.AjaxElementLocatorFactory;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.testng.Assert;
import org.testng.Reporter;

public class HomeMenu extends BasePage{
    private String user;

    //PageFactory
    @FindBy(id = "next2")
    WebElement LogINMenu;

    @FindBy(xpath = "//button[text()='Log in']")
    public By LogINButton;

    public By LogINUsername = new By.ById("loginusername");
    public By LogINPassword = new By.ById("loginpassword");
    public By usernameLogIN = new By.ById("nameofuser");

    //Contructor
    public HomeMenu(AndroidDriver<AndroidElement> driver) {
        super(driver);
        PageFactory.initElements(new AjaxElementLocatorFactory(driver, 30), this);
    }

    public void GoHomePage(){
        driver.navigate().to("https://demoblaze.com/index.html");
    }

    public void LoginUser(String user, String pass)
    {
        Reporter.log("Proceso de Login");
        clickElement(LogINMenu);
        sendTextElement(LogINUsername, user);
        sendTextElement(LogINPassword, pass);
        clickElement(LogINButton);
        this.user = user;
    }

    public void verifyUserLogIn()
    {
        assertElementText(usernameLogIN, "Welcome " + this.user);
    }
}
