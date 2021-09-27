package test.java.pages;

import org.openqa.selenium.By;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.interactions.Actions;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.Select;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.testng.Assert;
import test.java.data.Client;
import test.java.utility.Driver;
import test.java.utility.SwipeAction;


public class BasePage {
    public Driver _driver;
    public WebDriverWait wait;
    public Actions act;

    //Constructor
    public BasePage (Driver driver) {
        _driver = driver;
        wait = new WebDriverWait(driver.GetIntance(), 1200);
        act = new Actions(driver.GetIntance());
    }

    //Wait Element is Visible
    protected void waitVisibility(By locator) {
        wait.until(ExpectedConditions.visibilityOfAllElementsLocatedBy(locator));
    }

    //Click
    protected void clickElement(By locator) {
        waitVisibility(locator);
        _driver.GetIntance().findElement(locator).click();
    }

    //SendKey
    protected void sendTextElement(By locator, String text) {
        waitVisibility(locator);
        _driver.GetIntance().findElement(locator).sendKeys(text);
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
        if(SwipeAction.swipeDownUntilElementExist(_driver, locator)) {
            return _driver.GetIntance().findElement(locator).isEnabled();
        }
        else {
            return false;
        }
    }

    //SendKey
    protected void assertElementText(By locator, String text) {
        waitVisibility(locator);
        String textElement =  _driver.GetIntance().findElement(locator).getText();
        Assert.assertEquals(text, textElement, "Error, the expeted text was '" + text + "', but current text is '" + textElement + "'.");
    }

    //SendKey
    protected void assertElementWithTextExist(String text) {
        By locator = By.xpath("//*[@text='"+ text + "']");
        Assert.assertTrue(SwipeAction.swipeDownUntilElementText(_driver, text), "Error, there are not element with the text : '" + text + "'.");
        Assert.assertTrue( _driver.GetIntance().findElement(locator).isDisplayed(), "Error, element with the text : '" + text + "' is not visible on screem.");
    }
}