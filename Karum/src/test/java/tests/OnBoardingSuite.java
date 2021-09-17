package test.java.tests;

import org.testng.annotations.Test;
import test.java.constants;
import test.java.pages.*;

public class OnBoardingSuite extends BaseTest {

    @Test
    public void TC002_InitialScreen() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        reg.goRegistrationPage();
        reg.assertInitialRegistrationPage();
    }

    @Test
    public void TC002_InitialScreen_AvisoPrivacidadDocument() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        reg.goRegistrationPage();
        reg.goAvisoPrivacidad();
        reg.assertAvisoPrivacidad();
    }

    @Test
    public void TC002_InitialScreen_AcceptAvisoPrivacidadRegistrarmeEnable() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        reg.goRegistrationPage();
        reg.acceptAvisoPrivacidad();
        reg.assertRegistrarmeBtnEnabled();
    }

    @Test
    public void TC003_AMLQuestionnaire_NothingSelected_DisableContinue() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        reg.goRegistrationPage();
        reg.acceptAvisoPrivacidad();
        reg.tapRegistrarme();

        moneyLaunderingPage.assertContinueBtnDisable();
    }

    @Test
    public void TC003_AMLQuestionnaire_OneYesRestUnSelected_DisableContinue() {
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
        logIN.logINClienteAsesor(constants.CLIENTE);
        reg.goRegistrationPage();
        reg.acceptAvisoPrivacidad();
        reg.tapRegistrarme();

        moneyLaunderingPage.SetAllFieldsSINOACEPTO(PMLPage.aceptoField.SIACEPTO);
        moneyLaunderingPage.tapACEPTOFields();
        moneyLaunderingPage.assertContinueBtnEnable();
    }

    @Test
    public void TC003_AMLQuestionnaire_ValidateText() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        reg.goRegistrationPage();
        reg.acceptAvisoPrivacidad();
        reg.tapRegistrarme();

        moneyLaunderingPage.assertPMLText();
    }

    @Test
    public void TC004_INEIFEEvaluation_IdentificacionVigenteCheckBoxRequired() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        reg.goRegistrationPage();
        reg.acceptAvisoPrivacidad();
        reg.tapRegistrarme();

        moneyLaunderingPage.SetAllFieldsSINOACEPTO(PMLPage.aceptoField.SIACEPTO);
        moneyLaunderingPage.tapACEPTOFields();
        moneyLaunderingPage.tapContinue();

        inePhotoPage.tapCheckboxs(false,true);
        inePhotoPage.verifycapturarINEIFEbtnState(false);
    }

    @Test
    public void TC004_INEIFEEvaluation_ValidadoElementosSeguridadCheckboxCheckBoxRequired() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        reg.goRegistrationPage();
        reg.acceptAvisoPrivacidad();
        reg.tapRegistrarme();

        moneyLaunderingPage.SetAllFieldsSINOACEPTO(PMLPage.aceptoField.SIACEPTO);
        moneyLaunderingPage.tapACEPTOFields();
        moneyLaunderingPage.tapContinue();

        inePhotoPage.tapCheckboxs(true,false);
        inePhotoPage.verifycapturarINEIFEbtnState(false);
    }

    @Test
    public void TC004_INEIFEEvaluation_AllCheckboxCheckBoxRequiredSelect() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        reg.goRegistrationPage();
        reg.acceptAvisoPrivacidad();
        reg.tapRegistrarme();

        moneyLaunderingPage.SetAllFieldsSINOACEPTO(PMLPage.aceptoField.SIACEPTO);
        moneyLaunderingPage.tapACEPTOFields();
        moneyLaunderingPage.tapContinue();

        inePhotoPage.tapCheckboxs(true,true);
        inePhotoPage.verifycapturarINEIFEbtnState(true);
    }

    @Test
    public void TC004_INEIFEEvaluation_ConfirmIFEPhotos() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        reg.goRegistrationPage();
        reg.acceptAvisoPrivacidad();
        reg.tapRegistrarme();

        moneyLaunderingPage.SetAllFieldsSINOACEPTO(PMLPage.aceptoField.SIACEPTO);
        moneyLaunderingPage.tapACEPTOFields();
        moneyLaunderingPage.tapContinue();

        inePhotoPage.tapCheckboxs(true,true);
        inePhotoPage.tapCapturarINE();
        inePhotoPage.takeFrontPhoto();
        inePhotoPage.takeBackPhoto();

        inePhotoPage.verifyCapturePhotoOK();
        inePhotoPage.verifyContinuarnextPage();
    }

    @Test
    public void TC005_AdressDocumentation_BeforePhotoAlert() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        reg.goRegistrationPage();
        reg.acceptAvisoPrivacidad();
        reg.tapRegistrarme();

        moneyLaunderingPage.SetAllFieldsSINOACEPTO(PMLPage.aceptoField.SIACEPTO);
        moneyLaunderingPage.tapACEPTOFields();
        moneyLaunderingPage.tapContinue();

        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        addressPage.verifyAlertBeforePhotos();
    }

    @Test
    public void TC005_AdressDocumentation_PhotoTakeOK() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        reg.goRegistrationPage();
        reg.acceptAvisoPrivacidad();
        reg.tapRegistrarme();

        moneyLaunderingPage.SetAllFieldsSINOACEPTO(PMLPage.aceptoField.SIACEPTO);
        moneyLaunderingPage.tapACEPTOFields();
        moneyLaunderingPage.tapContinue();

        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        addressPage.tapCapturarDocumento();
        addressPage.takeDocumentPhoto();
        addressPage.verifyPhotoTakedPage();
    }
}