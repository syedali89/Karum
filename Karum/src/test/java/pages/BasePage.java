package test.java.pages;

import io.appium.java_client.AppiumDriver;
import org.openqa.selenium.By;
import org.openqa.selenium.ElementNotVisibleException;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.interactions.Actions;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.testng.Assert;


public class BasePage {
    public AppiumDriver _driver;
    public WebDriverWait wait;
    public Actions act;
    protected String driverType;

    //Constructor
    public BasePage (AppiumDriver driver, String driverType) {
        _driver = driver;
        this.driverType = driverType;
        wait = new WebDriverWait(driver, 20);
        act = new Actions(driver);
    }

    //Wait Element is Visible
    protected void waitVisibility(By locator) {
        wait.until(ExpectedConditions.visibilityOfAllElementsLocatedBy(locator));
    }

    //Wait Element is Visible
    protected void waitVisibility(WebElement element) {
        act.moveToElement(element).perform();

        wait.until(ExpectedConditions.visibilityOf(element));
    }

    //Wait Element not is Visible
    protected void waitNotVisibility(By locator) {
        wait.until(ExpectedConditions.invisibilityOfElementLocated(locator));
    }

    //Click
    protected void clickElement(By locator) {
        waitVisibility(locator);
        _driver.findElement(locator).click();
    }

    protected void clickElement(WebElement element) {
       waitVisibility(element);
       act.moveToElement(element).click();
    }

    //SendKey
    protected void sendTextElement(By locator, String text) {
        waitVisibility(locator);
        _driver.findElement(locator).sendKeys(text);
    }

    //Assert elements
    protected boolean validateElementVisible(By locator) {
        boolean elementVisible = true;

        try
        {
            waitVisibility(locator);
        }
        catch (Exception e)
        {
            elementVisible = false;
        }

        return elementVisible;
    }

    protected boolean validateElementEnable(By locator) {
        waitVisibility(locator);

        return _driver.findElement(locator).isEnabled();
    }

    //SendKey
    protected void assertElementText(By locator, String text) {
        waitVisibility(locator);
        String textElement = _driver.findElement(locator).getText();
        Assert.assertTrue(textElement.equals(text), "Error, the expeted text was '" + text + "', but current text is '" + textElement + "'.");
    }
}