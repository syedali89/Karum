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

    public static String RecoverDataElementPage(
            String url, String pathElementData, String attributeToRecover, int Iframe) {

        String returnData = "";

        try {
            File file = new File("chromedriver.exe");
            System.setProperty("webdriver.chrome.driver", file.getAbsolutePath());
            ChromeOptions options = new ChromeOptions();
            options.addArguments("--headless");
            WebDriver driver = new ChromeDriver(options);
            WebDriverWait wait = new WebDriverWait(driver, 30);

            driver.navigate().to(url);
            Thread.sleep(1000);
            if(Iframe>0) {
                wait.until(ExpectedConditions.frameToBeAvailableAndSwitchToIt(Iframe));
            }

            wait.until(ExpectedConditions.visibilityOfAllElementsLocatedBy(By.cssSelector(pathElementData)));
            WebElement pageElement = driver.findElement(By.cssSelector(pathElementData));

            if(attributeToRecover.isEmpty()) {
                returnData = pageElement.getText();
            }
            else {
                returnData = pageElement.getAttribute(attributeToRecover);
            }

            driver.close();
            driver.quit();
        }
        catch (Exception exception) {
            System.out.println(exception.getMessage());
        }

        return returnData;
    }

    public static String RecoverDataElementPage(
            String url, String pathElementData, String attributeToRecover) {
        return RecoverDataElementPage(url, pathElementData, attributeToRecover, -1);
    }
}