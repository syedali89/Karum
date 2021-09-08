package test.java.pages;

import io.appium.java_client.android.AndroidDriver;
import io.appium.java_client.android.AndroidElement;
import org.openqa.selenium.By;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.interactions.Actions;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.testng.Assert;


public class BasePage {
    public AndroidDriver<AndroidElement> driver;
    public WebDriverWait wait;

    //Constructor
    public BasePage (AndroidDriver<AndroidElement> driver){
        this.driver = driver;
        wait = new WebDriverWait(driver, 20);
    }

    //Wait Element is Visible
    public void waitVisibility(By locator) {
        wait.until(ExpectedConditions.visibilityOfAllElementsLocatedBy(locator));
    }

    //Wait Element is Visible
    public void waitVisibility(WebElement element) {
        Actions act = new Actions(driver);
        act.moveToElement(element).perform();

        wait.until(ExpectedConditions.visibilityOf(element));
    }

    //Wait Element not is Visible
    public void waitNotVisibility(By locator) {
        wait.until(ExpectedConditions.invisibilityOfElementLocated(locator));
    }

    //Click
    public void clickElement(By locator) {
        waitVisibility(locator);
        driver.findElement(locator).click();
    }

    public void clickElement(WebElement element) {
       waitVisibility(element);
        Actions act = new Actions(driver);
        act.moveToElement(element).click();
    }

    //SendKey
    public void sendTextElement(By locator, String text) {
        waitVisibility(locator);
        driver.findElement(locator).sendKeys(text);
    }

    //SendKey
    public void assertElementText(By locator, String text) {
        waitVisibility(locator);
        String textElement = driver.findElement(locator).getText();
        Assert.assertTrue(textElement.equals(text), "Error en el texto recuperado, se esperaba '" + text + "', pero se recupero '" + textElement + "'.");
    }    
}