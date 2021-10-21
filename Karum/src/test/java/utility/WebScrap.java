package test.java.utility;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.chrome.ChromeOptions;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

import java.io.File;

public class WebScrap {
    private WebDriver webdriver;
    private WebDriverWait webdriverwait;

    public WebScrap() {
        File file = new File("chromedriver.exe");
        System.setProperty("webdriver.chrome.driver", file.getAbsolutePath());
        ChromeOptions options = new ChromeOptions();
        options.addArguments("--headless");
        webdriver = new ChromeDriver(options);
        webdriverwait = new WebDriverWait(webdriver, 120);
    }

    public String RecoverDataElementPage(
            String url, By pathElementData, String attributeToRecover, String Iframe) {

        String returnData = "";

        try {
            webdriver.navigate().to(url);
            Thread.sleep(1000);
            if(!Iframe.isEmpty()) {
                webdriverwait.until(ExpectedConditions.frameToBeAvailableAndSwitchToIt(By.id(Iframe)));
            }

            webdriverwait.until(ExpectedConditions.visibilityOfAllElementsLocatedBy(pathElementData));
            WebElement pageElement = webdriver.findElement(pathElementData);

            if(attributeToRecover.isEmpty()) {
                returnData = pageElement.getText();
            }
            else {
                returnData = pageElement.getAttribute(attributeToRecover);
            }
        }
        catch (Exception exception) {
            System.out.println(exception.getMessage());
        }

        return returnData;
    }

    public String RecoverDataElementPage(
            String url, By pathElementData, String attributeToRecover) {
        return RecoverDataElementPage(url, pathElementData, attributeToRecover, "");
    }

    public void waitElementExist(String url, By locator) {
        webdriver.navigate().to(url);
        webdriverwait.until(ExpectedConditions.visibilityOfAllElementsLocatedBy(locator));
    }

    public void KillSession() {
        webdriver.close();
        webdriver.quit();
    }
}