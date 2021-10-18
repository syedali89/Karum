package test.java.pages;
import org.openqa.selenium.By;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.interactions.Actions;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.testng.Assert;
import test.java.utility.Driver;
import test.java.utility.SwipeAction;
import test.java.constants;
import java.util.List;


public class BasePage {
    public Driver _driver;
    public WebDriverWait wait;
    public Actions act;

    //By Document
    public By documentBody = By.xpath("//android.view.View/android.widget.TextView");

    //Constructor
    public BasePage (Driver driver) {
        _driver = driver;
        wait = new WebDriverWait(driver.GetIntance(), 30);
        act = new Actions(driver.GetIntance());
        if(driver.GetDriverType().equals(constants.IOS)) {
            //TODO IOS PATH document
            documentBody = By.xpath("TODO");
        }
    }

    //Wait Element is Visible
    protected void waitVisibility(By locator) {
        wait.until(ExpectedConditions.visibilityOfAllElementsLocatedBy(locator));
    }

    //Wait Element is not Visible
    protected void waitNotVisibility(By locator) {
        wait.until(ExpectedConditions.invisibilityOfElementLocated(locator));
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

        try {
            waitVisibility(locator);
        }
        catch (Exception e) {
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
        Assert.assertTrue(_driver.GetIntance().findElement(locator).isDisplayed(), "Error, element with the text : '" + text + "' is not visible on screem.");
    }

    //Evaluate if the official document text is equal to the document displayed on the app
    protected void assertDocumentText(String documentName, String documentFullText) {
        List<WebElement> bodyDocumentElements;
        String recoverFullText = "";
        boolean notEndDocument = true;
        String lastText = "";

        while(notEndDocument) {
            waitVisibility(documentBody);
            String lastTextDisplayed;
            bodyDocumentElements = _driver.GetIntance().findElements(documentBody);

            if(bodyDocumentElements.get(bodyDocumentElements.size() - 1).getText().isEmpty()) {
                lastTextDisplayed  = bodyDocumentElements.get(bodyDocumentElements.size() - 2).getText();
            }
            else {
                lastTextDisplayed  = bodyDocumentElements.get(bodyDocumentElements.size() - 1).getText();
            }

            if(lastTextDisplayed.equals(lastText)) {
                notEndDocument = false;
                continue;
            }

            for (WebElement docElement : bodyDocumentElements ) {
                recoverFullText = recoverFullText + docElement.getText() + "\n";

                Assert.assertTrue(
                        documentFullText.contains(docElement.getText()),
                        "Error, in validation of document " + documentName +
                                ", official document : \nSTART DOCUMENT '" + documentFullText + "'\nEND OFFICIAL DOCUMENT " +
                                "\nAnd recover from app document: START DOCUMENT '" + recoverFullText + "'\nEND RECOVER DOCUMENT" +
                                "\nDONT MATCH. \n*Document recover could be incomplete because stop when some line is different from official.");
            }

            lastText = lastTextDisplayed;
        }
    }

    public void grantAllPermissions() {
        if (_driver.PERFECTO) {
            if (_driver.GetDriverType().equals(constants.ANDROID)) {
                By allowButtonForeground = By.id("com.android.permissioncontroller:id/permission_allow_foreground_only_button");
                By allowButton = By.id("com.android.permissioncontroller:id/permission_allow_button");

                //TODO TEST SANGSUNG
                while (validateElementVisible(allowButtonForeground)) {
                    clickElement(allowButtonForeground);
                }

                while (validateElementVisible(allowButton)) {
                    clickElement(allowButton);
                }
            }
        }
    }
}