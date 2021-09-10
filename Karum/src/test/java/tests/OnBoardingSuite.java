package test.java.tests;

import org.testng.annotations.Test;
import test.java.constants;
import test.java.pages.LogIN;
import test.java.pages.PMLPage;
import test.java.pages.RegisterPage;

public class OnBoardingSuite extends BaseTest {

    @Test
    public void TC001_NewClient() {
        LogIN logIN = new LogIN(_driver.GetIntance(), _driver.GetDriverType());
        RegisterPage reg = new RegisterPage(_driver.GetIntance(), _driver.GetDriverType());

        logIN.logINClienteAsesor(constants.CLIENTE);
        reg.goRegistrationPage();
        reg.assertInitialRegistrationPage();
    }

    @Test
    public void TC002_InitialScreen_AvisoPrivacidadDocument() {
        LogIN logIN = new LogIN(_driver.GetIntance(), _driver.GetDriverType());
        RegisterPage reg = new RegisterPage(_driver.GetIntance(), _driver.GetDriverType());

        logIN.logINClienteAsesor(constants.CLIENTE);
        reg.goRegistrationPage();
        reg.goAvisoPrivacidad();
        reg.assertAvisoPrivacidad();
    }

    @Test
    public void TC002_InitialScreen_AcceptAvisoPrivacidadRegistrarmeEnable() {
        LogIN logIN = new LogIN(_driver.GetIntance(), _driver.GetDriverType());
        RegisterPage reg = new RegisterPage(_driver.GetIntance(), _driver.GetDriverType());

        logIN.logINClienteAsesor(constants.CLIENTE);
        reg.goRegistrationPage();
        reg.acceptAvisoPrivacidad();
        reg.assertRegistrarmeBtnEnabled();
    }

    @Test
    public void TC003_AMLQuestionnaire_NothingSelected_DisableContinue() {
        LogIN logIN = new LogIN(_driver.GetIntance(), _driver.GetDriverType());
        RegisterPage reg = new RegisterPage(_driver.GetIntance(), _driver.GetDriverType());
        PMLPage moneyLaunderingPage = new PMLPage(_driver.GetIntance(), _driver.GetDriverType());

        logIN.logINClienteAsesor(constants.CLIENTE);
        reg.goRegistrationPage();
        reg.acceptAvisoPrivacidad();
        reg.tapRegistrarme();

        moneyLaunderingPage.assertContinueBtnDisable();
    }

    @Test
    public void TC003_AMLQuestionnaire_OneYesRestUnSelected_DisableContinue() {
        LogIN logIN = new LogIN(_driver.GetIntance(), _driver.GetDriverType());
        RegisterPage reg = new RegisterPage(_driver.GetIntance(), _driver.GetDriverType());
        PMLPage moneyLaunderingPage = new PMLPage(_driver.GetIntance(), _driver.GetDriverType());

        logIN.logINClienteAsesor(constants.CLIENTE);
        reg.goRegistrationPage();
        reg.acceptAvisoPrivacidad();
        reg.tapRegistrarme();

        moneyLaunderingPage.SetSINOACEPTOradioButton(PMLPage.aceptoField.SIACEPTO, 3);
        moneyLaunderingPage.tapACEPTOFields();
        moneyLaunderingPage.assertContinueBtnDisable();
    }

    @Test
    public void TC003_AMLQuestionnaire_AllNoSelected_DisableContinue() {
        LogIN logIN = new LogIN(_driver.GetIntance(), _driver.GetDriverType());
        RegisterPage reg = new RegisterPage(_driver.GetIntance(), _driver.GetDriverType());
        PMLPage moneyLaunderingPage = new PMLPage(_driver.GetIntance(), _driver.GetDriverType());

        logIN.logINClienteAsesor(constants.CLIENTE);
        reg.goRegistrationPage();
        reg.acceptAvisoPrivacidad();
        reg.tapRegistrarme();

        moneyLaunderingPage.SetAllFieldsSINOACEPTO(PMLPage.aceptoField.NOACEPTO);
        moneyLaunderingPage.tapACEPTOFields();
        moneyLaunderingPage.assertContinueBtnDisable();
    }

    @Test
    public void TC003_AMLQuestionnaire_OneNORestYesSelected_DisableContinue() {
        LogIN logIN = new LogIN(_driver.GetIntance(), _driver.GetDriverType());
        RegisterPage reg = new RegisterPage(_driver.GetIntance(), _driver.GetDriverType());
        PMLPage moneyLaunderingPage = new PMLPage(_driver.GetIntance(), _driver.GetDriverType());

        logIN.logINClienteAsesor(constants.CLIENTE);
        reg.goRegistrationPage();
        reg.acceptAvisoPrivacidad();
        reg.tapRegistrarme();

        moneyLaunderingPage.SetAllFieldsSINOACEPTO(PMLPage.aceptoField.SIACEPTO);
        moneyLaunderingPage.SetSINOACEPTOradioButton(PMLPage.aceptoField.NOACEPTO, 4);
        moneyLaunderingPage.tapACEPTOFields();
        moneyLaunderingPage.assertContinueBtnDisable();
    }

    @Test
    public void TC003_AMLQuestionnaire_AllYesSelected_EnableContinue() {
        LogIN logIN = new LogIN(_driver.GetIntance(), _driver.GetDriverType());
        RegisterPage reg = new RegisterPage(_driver.GetIntance(), _driver.GetDriverType());
        PMLPage moneyLaunderingPage = new PMLPage(_driver.GetIntance(), _driver.GetDriverType());

        logIN.logINClienteAsesor(constants.CLIENTE);
        reg.goRegistrationPage();
        reg.acceptAvisoPrivacidad();
        reg.tapRegistrarme();

        moneyLaunderingPage.SetAllFieldsSINOACEPTO(PMLPage.aceptoField.SIACEPTO);
        moneyLaunderingPage.tapACEPTOFields();
        moneyLaunderingPage.assertContinueBtnEnable();
    }
}