package test.java.pages;

import org.openqa.selenium.By;
import org.testng.Assert;
import test.java.data.Client;
import test.java.utility.Driver;
import test.java.utility.SwipeAction;

public class BasicHolderJobPage extends BasePage {
    //By elements
    public By goBackbutton = By.id("com.karum.credits:id/iv_back_header");
    public By CONTINUARbtn = By.id("com.karum.credits:id/btn_continue");

    //By Do you have a job?
    public By SIhaveJobBtn = By.id("com.karum.credits:id/tv_yes_option");
    public By NOhaveJobBtn = By.id("com.karum.credits:id/tv_no_option");

    //By Job description
    public By companyNameInput = By.id("com.karum.credits:id/et_company_name");
    public By workIndependentlyCheckbox = By.id("com.karum.credits:id/cb_independent");

    //By Income
    public By visualMonthlyIncome = By.id("com.karum.credits:id/et_salary");
    public By barSalaryInput = By.id("com.karum.credits:id/cb_independent");
    public By pointSalaryInput = By.xpath("//*[@resource-id='com.karum.credits:id/sb_salary']/android.widget.SeekBar");


    //Contructor
    public BasicHolderJobPage(Driver driver) {
        super(driver);
    }

    public void tapGoBack() {
        clickElement(goBackbutton);
    }

    public void tapSINOhaveJob(boolean SI) {
        if(SI) {
            clickElement(SIhaveJobBtn);
        }
        else {
            clickElement(NOhaveJobBtn);
        }

    }

    public void informCompanyName(Client client) {
        sendTextElement(companyNameInput, client.jobCompany);
    }

    public Client tapWorkIndependently(Client client) {
        clickElement(workIndependentlyCheckbox);
        client.jobCompany = "Independiente";
        return client;
    }

    public void tapCONTINUAR() {
        clickElement(CONTINUARbtn);
    }

    public void setIncomeFromBar() {
        waitVisibility(pointSalaryInput);
        SwipeAction.swipeToRightFromElement(_driver, pointSalaryInput);
    }

    public ApplyCreditPage allProcessBasicAddressPage() {
        this.tapSINOhaveJob(false);
        this.setIncomeFromBar();
        this.tapCONTINUAR();
        return new ApplyCreditPage(_driver);
    }

    public void verifyJobCompany(Client clientData) {
        assertElementText(companyNameInput, clientData.jobCompany);
    }

    public void verifyCONTINUARState(boolean state) {
        String enabledDisabled = "disabled";
        if(state) {
            enabledDisabled = "enabled";
        }

        Assert.assertEquals(validateElementEnable(CONTINUARbtn), state,
                "Error, 'CONTINUE' button should be " + enabledDisabled);
    }

    public void verifyAmountIsCorrect() {
        waitVisibility(pointSalaryInput);
        String selectedIncome = _driver.GetIntance().findElement(pointSalaryInput).getText();
        String currentIncome = _driver.GetIntance().findElement(visualMonthlyIncome).getText();

        Assert.assertTrue(currentIncome.contains(selectedIncome),
                "Error, the income selected '" + selectedIncome +"' and the income displayed '" + currentIncome + "' are different");
    }

    public void verifyDoYouHaveJobText() {
        assertElementWhitTextExist("Perfil");
        assertElementWhitTextExist("1 / 3");
        assertElementWhitTextExist("¿Laboras actualmente?");

        Assert.assertTrue(validateElementVisible(SIhaveJobBtn),
                "Error, 'Si' button is not visible");
        Assert.assertTrue(validateElementVisible(NOhaveJobBtn),
                "Error, 'No' button is not visible");
    }

    public void verifyJobDescription() {
        assertElementWhitTextExist("Perfil");
        assertElementWhitTextExist("2 / 3");
        assertElementWhitTextExist("Nombre de la empresa donde laboras");

        Assert.assertTrue(validateElementVisible(companyNameInput),
                "Error, input for company name is not visible");
        Assert.assertTrue(validateElementVisible(workIndependentlyCheckbox),
                "Error, work Independently CheckboxName button is not visible");
        assertElementText(workIndependentlyCheckbox,"Laboro de forma independiente");
    }

    public void verifyMonthlyIncome() {
        assertElementWhitTextExist("Perfil");
        assertElementWhitTextExist("3 / 3");
        assertElementWhitTextExist("¿Cuál es tu ingreso mensual?");
        assertElementWhitTextExist("$3,000.00");
        assertElementWhitTextExist("+ $50,000.00");

        Assert.assertTrue(validateElementVisible(visualMonthlyIncome),
                "Error, 'Monto del ingreso mensual' is not visible on screen");
        assertElementText(visualMonthlyIncome, "$0.00");
        Assert.assertTrue(validateElementVisible(barSalaryInput) && validateElementVisible(pointSalaryInput),
                "Error, moving bar for define income is not visible or is incomplete on the screen");
    }
}