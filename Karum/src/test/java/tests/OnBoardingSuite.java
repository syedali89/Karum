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
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();

        moneyLaunderingPage.assertContinueBtnDisable();
    }

    @Test
    public void TC003_AMLQuestionnaire_OneYesRestUnSelected_DisableContinue() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();

        moneyLaunderingPage.SetSINOACEPTOradioButton(PMLPage.aceptoField.SIACEPTO, 3);
        moneyLaunderingPage.tapACEPTOFields();
        moneyLaunderingPage.assertContinueBtnDisable();
    }

    @Test
    public void TC003_AMLQuestionnaire_AllNoSelected_DisableContinue() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();

        moneyLaunderingPage.SetAllFieldsSINOACEPTO(PMLPage.aceptoField.NOACEPTO);
        moneyLaunderingPage.tapACEPTOFields();
        moneyLaunderingPage.assertContinueBtnDisable();
    }

    @Test
    public void TC003_AMLQuestionnaire_OneNORestYesSelected_DisableContinue() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();

        moneyLaunderingPage.SetAllFieldsSINOACEPTO(PMLPage.aceptoField.SIACEPTO);
        moneyLaunderingPage.SetSINOACEPTOradioButton(PMLPage.aceptoField.NOACEPTO, 4);
        moneyLaunderingPage.tapACEPTOFields();
        moneyLaunderingPage.assertContinueBtnDisable();
    }

    @Test
    public void TC003_AMLQuestionnaire_AllYesSelected_EnableContinue() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();

        moneyLaunderingPage.SetAllFieldsSINOACEPTO(PMLPage.aceptoField.SIACEPTO);
        moneyLaunderingPage.tapACEPTOFields();
        moneyLaunderingPage.assertContinueBtnEnable();
    }

    @Test
    public void TC003_AMLQuestionnaire_ValidateText() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();

        moneyLaunderingPage.assertPMLText();
    }

    @Test
    public void TC004_INEIFEEvaluation_IdentificacionVigenteCheckBoxRequired() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();

        inePhotoPage.tapCheckboxs(false,true);
        inePhotoPage.verifycapturarINEIFEbtnState(false);
    }

    @Test
    public void TC004_INEIFEEvaluation_ValidadoElementosSeguridadCheckboxCheckBoxRequired() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();

        inePhotoPage.tapCheckboxs(true,false);
        inePhotoPage.verifycapturarINEIFEbtnState(false);
    }

    @Test
    public void TC004_INEIFEEvaluation_AllCheckboxCheckBoxRequiredSelect() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();

        inePhotoPage.tapCheckboxs(true,true);
        inePhotoPage.verifycapturarINEIFEbtnState(true);
    }

    @Test
    public void TC004_INEIFEEvaluation_ConfirmIFEPhotos() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();

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
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();

        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        addressPage.verifyAlertBeforePhotos();
    }

    @Test
    public void TC005_AdressDocumentation_PhotoTakeOK() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();

        addressPage.tapCapturarDocumento();
        addressPage.takeDocumentPhoto();
        addressPage.verifyPhotoTakedPage();
    }

    @Test
    public void TC005_AdressDocumentation_TakePhotoAgain() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();

        addressPage.tapCapturarDocumento();
        addressPage.takeDocumentPhoto();
        addressPage.tapVolverCapturar();
        addressPage.takeDocumentPhoto();
        addressPage.verifyPhotoTakedPage();
    }

    @Test
    public void TC006_SelfieBiometricCheck_VerifyIntructions() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();

        facePage.verifyInstructions();
    }

    @Test
    public void TC006_SelfieBiometricCheck_VerifyFaceActionT() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();

        facePage.tapCapturarRostro();
        facePage.verifyButtoContinuarCaptureFace();
        facePage.captureFace(true);
        facePage.verifyCaptureFace();
    }

    @Test
    public void TC006_SelfieBiometricCheck_CaptureGoWrong() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();

        facePage.tapCapturarRostro();
        facePage.captureWrong();
        facePage.verifyWrongphoto();
    }

    @Test
    public void TC006_SelfieBiometricCheck_FaceFailMatchingINE() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();

        facePage.tapCapturarRostro();
        facePage.captureFace(false);
        facePage.verifyPhotoDontMatch();
    }

    @Test
    public void TC006_SelfieBiometricCheck_FaceMatchINE() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();

        facePage.tapCapturarRostro();
        facePage.captureFace(true);
        facePage.verifyPhotoMatch();
    }

    @Test
    public void TC007_KeyLoadBasicAcctHolderInformation_ValidateTextAddressInfo() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();
        BasicHolderAddressPage basicInfoPage = facePage.allProcessFacePage();

        basicInfoPage.verifyTextAddressInfo(clientData);
        basicInfoPage.verifyCONTINUARbtnState(false);
    }

    @Test
    public void TC007_KeyLoadBasicAcctHolderInformation_ValidateAddressAllFieldsInformet() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();
        BasicHolderAddressPage basicInfoPage = facePage.allProcessFacePage();

        basicInfoPage.informAddress(clientData, true);
        basicInfoPage.informRetireCardDefault();
        basicInfoPage.verifyCONTINUARbtnState(true);
    }

    @Test
    public void TC007_KeyLoadBasicAcctHolderInformation_ValidateOnlyAddressMandatoryFields() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();
        BasicHolderAddressPage basicInfoPage = facePage.allProcessFacePage();

        clientData.AddressIntNum = "";

        basicInfoPage.informAddress(clientData, true);
        basicInfoPage.informRetireCardDefault();
        basicInfoPage.verifyCONTINUARbtnState(true);
    }

    @Test
    public void TC007_KeyLoadBasicAcctHolderInformation_ValidateEmailIncorrectFormat() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();
        BasicHolderAddressPage basicInfoPage = facePage.allProcessFacePage();

        clientData.Email = "email";

        basicInfoPage.informAddress(clientData, true);
        basicInfoPage.informRetireCardDefault();
        basicInfoPage.verifyCONTINUARbtnState(false);
    }

    @Test
    public void TC007_KeyLoadBasicAcctHolderInformation_ValidatePhoneNumberNotEquals() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();
        BasicHolderAddressPage basicInfoPage = facePage.allProcessFacePage();

        basicInfoPage.informAddress(clientData, false);
        basicInfoPage.verifyAlertPhonesDoestMatch();
        basicInfoPage.informRetireCardDefault();
        basicInfoPage.verifyCONTINUARbtnState(false);
    }

    @Test
    public void TC007_KeyLoadBasicAcctHolderInformation_ConfirmationAddressText() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();
        BasicHolderAddressPage basicInfoPage = facePage.allProcessFacePage();

        basicInfoPage.informAddress(clientData, true);
        basicInfoPage.informRetireCardDefault();
        basicInfoPage.tapCONTINUARbtn();
        basicInfoPage.verifyConfirmAddressText(clientData);
    }

    @Test
    public void TC007_KeyLoadBasicAcctHolderInformation_ConfirmationAddress_ModificarButton() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();
        BasicHolderAddressPage basicInfoPage = facePage.allProcessFacePage();

        basicInfoPage.informAddress(clientData, true);
        basicInfoPage.informRetireCardDefault();
        basicInfoPage.tapCONTINUARbtn();
        basicInfoPage.tapModificarBtn();

        basicInfoPage.verifyModificarBtnWork();
    }

    @Test
    public void TC007_KeyLoadBasicAcctHolderInformation_ConfirmationAddress_ContinuarEnabledWhenConfirmCheckbox() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();
        BasicHolderAddressPage basicInfoPage = facePage.allProcessFacePage();

        basicInfoPage.informAddress(clientData, true);
        basicInfoPage.informRetireCardDefault();
        basicInfoPage.tapCONTINUARbtn();

        basicInfoPage.verifyCONTINUARbtnState(false);
        basicInfoPage.checkConfirmAddressCheckbox();
        basicInfoPage.verifyCONTINUARbtnState(true);
    }

    @Test
    public void TC007_KeyLoadBasicAcctHolderInformation_JobInformation_DoYouHaveJobStep() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();
        BasicHolderAddressPage basicInfoPage = facePage.allProcessFacePage();
        BasicHolderJobPage basicHolderJobPage = basicInfoPage.allProcessBasicAddressPage(clientData);

        basicHolderJobPage.verifyDoYouHaveJobText();
    }

    @Test
    public void TC007_KeyLoadBasicAcctHolderInformation_JobInformation_DoYouHaveJob_GoBackButton() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();

        BasicHolderAddressPage basicInfoPage = facePage.allProcessFacePage();
        BasicHolderJobPage basicHolderJobPage = basicInfoPage.allProcessBasicAddressPage(clientData);

        basicHolderJobPage.tapGoBack();
        basicInfoPage.verifyConfirmAddressText(clientData);
    }

    @Test
    public void TC007_KeyLoadBasicAcctHolderInformation_JobInformation_SIButton() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();
        BasicHolderAddressPage basicInfoPage = facePage.allProcessFacePage();
        BasicHolderJobPage basicHolderJobPage = basicInfoPage.allProcessBasicAddressPage(clientData);

        basicHolderJobPage.tapSINOhaveJob(true);
        basicHolderJobPage.verifyJobDescription();
    }

    @Test
    public void TC007_KeyLoadBasicAcctHolderInformation_JobInformation_CompanyNameMandatory() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();
        BasicHolderAddressPage basicInfoPage = facePage.allProcessFacePage();
        BasicHolderJobPage basicHolderJobPage = basicInfoPage.allProcessBasicAddressPage(clientData);

        basicHolderJobPage.tapSINOhaveJob(true);
        basicHolderJobPage.informCompanyName(clientData);
        basicHolderJobPage.verifyCONTINUARState(true);
    }

    @Test
    public void TC007_KeyLoadBasicAcctHolderInformation_JobInformation_WorkIndependentlyCheckbox() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();
        BasicHolderAddressPage basicInfoPage = facePage.allProcessFacePage();
        BasicHolderJobPage basicHolderJobPage = basicInfoPage.allProcessBasicAddressPage(clientData);

        basicHolderJobPage.tapSINOhaveJob(true);
        basicHolderJobPage.tapWorkIndependently(clientData);
        basicHolderJobPage.verifyCONTINUARState(true);
        basicHolderJobPage.verifyJobCompany(clientData);
    }

    @Test
    public void TC007_KeyLoadBasicAcctHolderInformation_JobInformation_CompleteCompanyNameThemContinue() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();
        BasicHolderAddressPage basicInfoPage = facePage.allProcessFacePage();
        BasicHolderJobPage basicHolderJobPage = basicInfoPage.allProcessBasicAddressPage(clientData);

        basicHolderJobPage.tapSINOhaveJob(true);
        basicHolderJobPage.tapWorkIndependently(clientData);
        basicHolderJobPage.tapCONTINUAR();
        basicHolderJobPage.verifyMonthlyIncome();
    }

    @Test
    public void TC007_KeyLoadBasicAcctHolderInformation_JobInformation_NOButton() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();
        BasicHolderAddressPage basicInfoPage = facePage.allProcessFacePage();
        BasicHolderJobPage basicHolderJobPage = basicInfoPage.allProcessBasicAddressPage(clientData);

        basicHolderJobPage.tapSINOhaveJob(false);
        basicHolderJobPage.verifyMonthlyIncome();
    }

    @Test
    public void TC007_KeyLoadBasicAcctHolderInformation_JobInformation_MountlyIncomeMandatory() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();
        BasicHolderAddressPage basicInfoPage = facePage.allProcessFacePage();
        BasicHolderJobPage basicHolderJobPage = basicInfoPage.allProcessBasicAddressPage(clientData);

        basicHolderJobPage.tapSINOhaveJob(false);
        basicHolderJobPage.verifyCONTINUARState(false);
        basicHolderJobPage.setIncomeFromBar();
        basicHolderJobPage.verifyCONTINUARState(true);
    }

    @Test
    public void TC007_KeyLoadBasicAcctHolderInformation_JobInformation_MonthlyIncomeAmount() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();
        BasicHolderAddressPage basicInfoPage = facePage.allProcessFacePage();
        BasicHolderJobPage basicHolderJobPage = basicInfoPage.allProcessBasicAddressPage(clientData);

        basicHolderJobPage.tapSINOhaveJob(false);
        basicHolderJobPage.setIncomeFromBar();
        basicHolderJobPage.verifyAmountIsCorrect();
    }

    @Test
    public void TC007_KeyLoadBasicAcctHolderInformation_ApplyForCredit_AuthorizeTextValidation() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();
        BasicHolderAddressPage basicInfoPage = facePage.allProcessFacePage();
        BasicHolderJobPage basicHolderJobPage = basicInfoPage.allProcessBasicAddressPage(clientData);
        ApplyCreditPage applyCreditPage = basicHolderJobPage.allProcessBasicAddressPage();

        applyCreditPage.verifyTextApplyForCreditFirstPage();
    }

    @Test
    public void TC007_KeyLoadBasicAcctHolderInformation_ApplyForCredit_DocumentsTextValidation() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();
        BasicHolderAddressPage basicInfoPage = facePage.allProcessFacePage();
        BasicHolderJobPage basicHolderJobPage = basicInfoPage.allProcessBasicAddressPage(clientData);
        ApplyCreditPage applyCreditPage = basicHolderJobPage.allProcessBasicAddressPage();

        applyCreditPage.tapTerminosCondiciones();
        applyCreditPage.verifyTerminosCondicionesDocument();
        applyCreditPage.tapCloseDocument();
        applyCreditPage.tapUsoMediosTecnologicos();
        applyCreditPage.verifyUsoMediosTecnologicosDocument();
        applyCreditPage.tapCloseDocument();
        applyCreditPage.tapConsultaBuroCredito();
        applyCreditPage.verifyConsultaBuroCreditoDocument();
    }

    @Test
    public void TC007_KeyLoadBasicAcctHolderInformation_ApplyForCredit_AllCheckboxMandatory() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();
        BasicHolderAddressPage basicInfoPage = facePage.allProcessFacePage();
        BasicHolderJobPage basicHolderJobPage = basicInfoPage.allProcessBasicAddressPage(clientData);
        ApplyCreditPage applyCreditPage = basicHolderJobPage.allProcessBasicAddressPage();

        applyCreditPage.verifyContinuarEnabled(false);
        applyCreditPage.tapAllAuthorizeCheckbox();
        applyCreditPage.verifyContinuarEnabled(true);
    }
}