package test.java.tests;

import org.testng.annotations.Test;
import test.java.constants;
import test.java.pages.*;
import test.java.utility.DataRecover;

import java.util.ArrayList;

public class OnBoardingSuite extends BaseTest {
    @Test(priority = 1)
    public void TC002_InitialScreen() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        reg.goRegistrationPage();
        reg.assertInitialRegistrationPage();
    }

    @Test(priority = 2)
    public void TC002_InitialScreen_AvisoPrivacidadDocument() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        reg.goRegistrationPage();
        reg.goAvisoPrivacidad();
        reg.assertAvisoPrivacidad();
    }

    @Test(priority = 3)
    public void TC002_InitialScreen_AcceptAvisoPrivacidadRegistrarmeEnable() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        reg.goRegistrationPage();
        reg.acceptAvisoPrivacidad();
        reg.assertRegistrarmeBtnEnabled();
    }

    @Test(priority = 4)
    public void TC003_AMLQuestionnaire_NothingSelected_DisableContinue() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();

        moneyLaunderingPage.assertContinueBtnDisable();
    }

    @Test(priority = 5)
    public void TC003_AMLQuestionnaire_OneYesRestUnSelected_DisableContinue() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();

        moneyLaunderingPage.SetSINOACEPTOradioButton(PMLPage.aceptoField.SIACEPTO, 3);
        moneyLaunderingPage.tapACEPTOFields();
        moneyLaunderingPage.assertContinueBtnDisable();
    }

    @Test(priority = 6)
    public void TC003_AMLQuestionnaire_AllNoSelected_DisableContinue() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();

        moneyLaunderingPage.SetAllFieldsSINOACEPTO(PMLPage.aceptoField.NOACEPTO);
        moneyLaunderingPage.tapACEPTOFields();
        moneyLaunderingPage.assertContinueBtnDisable();
    }

    @Test(priority = 7)
    public void TC003_AMLQuestionnaire_OneNORestYesSelected_DisableContinue() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();

        moneyLaunderingPage.SetAllFieldsSINOACEPTO(PMLPage.aceptoField.SIACEPTO);
        moneyLaunderingPage.SetSINOACEPTOradioButton(PMLPage.aceptoField.NOACEPTO, 4);
        moneyLaunderingPage.tapACEPTOFields();
        moneyLaunderingPage.assertContinueBtnDisable();
    }

    @Test(priority = 8)
    public void TC003_AMLQuestionnaire_AllYesSelected_EnableContinue() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();

        moneyLaunderingPage.SetAllFieldsSINOACEPTO(PMLPage.aceptoField.SIACEPTO);
        moneyLaunderingPage.tapACEPTOFields();
        moneyLaunderingPage.assertContinueBtnEnable();
    }

    @Test(priority = 9)
    public void TC003_AMLQuestionnaire_ValidateText() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();

        moneyLaunderingPage.assertPMLText();
    }

    @Test(priority = 10)
    public void TC004_INEIFEEvaluation_IdentificacionVigenteCheckBoxRequired() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();

        inePhotoPage.tapCheckboxs(false,true);
        inePhotoPage.verifycapturarINEIFEbtnState(false);
    }

    @Test(priority = 11)
    public void TC004_INEIFEEvaluation_ValidadoElementosSeguridadCheckboxCheckBoxRequired() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();

        inePhotoPage.tapCheckboxs(true,false);
        inePhotoPage.verifycapturarINEIFEbtnState(false);
    }

    @Test(priority = 12)
    public void TC004_INEIFEEvaluation_AllCheckboxCheckBoxRequiredSelect() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();

        inePhotoPage.tapCheckboxs(true,true);
        inePhotoPage.verifycapturarINEIFEbtnState(true);
    }

    @Test(priority = 13)
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

    @Test(priority = 14)
    public void TC005_AddressDocumentation_BeforePhotoAlert() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();

        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        addressPage.verifyAlertBeforePhotos();
    }

    @Test(priority = 15)
    public void TC005_AddressDocumentation_PhotoTakeOK() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();

        addressPage.tapCapturarDocumento();
        addressPage.takeDocumentPhoto();
        addressPage.verifyPhotoTakedPage();
    }

    @Test(priority = 16)
    public void TC005_AddressDocumentation_TakePhotoAgain() {
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

    @Test(priority = 17)
    public void TC006_SelfieBiometricCheck_VerifyInstructions() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();

        facePage.verifyInstructions();
    }

    @Test(priority = 18)
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

    @Test(priority = 19)
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

    @Test(priority = 20)
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

    @Test(priority = 21)
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

    @Test(priority = 22)
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

    @Test(priority = 23)
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

    @Test(priority = 24)
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

    @Test(priority = 25)
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

    @Test(priority = 26)
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

    @Test(priority = 27)
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

    @Test(priority = 28)
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

    @Test(priority = 29)
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

    @Test(priority = 30)
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

    @Test(priority = 31)
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

    @Test(priority = 32)
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

    @Test(priority = 33)
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

    @Test(priority = 34)
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

    @Test(priority = 35)
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

    @Test(priority = 36)
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

    @Test(priority = 37)
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

    @Test(priority = 38)
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

    @Test(priority = 39)
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

    @Test(priority = 40)
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

    @Test(priority = 41)
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

    @Test(priority = 42)
    public void TC008_PrescreenRequest_SecureCode_TextValidation() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();

        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();
        BasicHolderAddressPage basicInfoPage = facePage.allProcessFacePage();
        BasicHolderJobPage basicHolderJobPage = basicInfoPage.allProcessBasicAddressPage(clientData);
        ApplyCreditPage applyCreditPage = basicHolderJobPage.allProcessBasicAddressPage();
        RegSecureCode regSecureCode = applyCreditPage.allApplyCreditPage();

        regSecureCode.verifySecureCodePage(clientData);
    }

    @Test(priority = 43)
    public void TC008_PrescreenRequest_SecureCode_WaitCountdownAndResendCode() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();

        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();
        BasicHolderAddressPage basicInfoPage = facePage.allProcessFacePage();
        BasicHolderJobPage basicHolderJobPage = basicInfoPage.allProcessBasicAddressPage(clientData);
        ApplyCreditPage applyCreditPage = basicHolderJobPage.allProcessBasicAddressPage();
        RegSecureCode regSecureCode = applyCreditPage.allApplyCreditPage();

        regSecureCode.waitCountdown();
        regSecureCode.tapEnviarCodido();
        regSecureCode.verifyAlertSendCode();
        regSecureCode.tapACEPTAR();
        regSecureCode.verifyResendSecureCodePage();
    }

    @Test(priority = 44)
    public void TC008_PrescreenRequest_SecureCode_InputWrongCode() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();

        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();
        BasicHolderAddressPage basicInfoPage = facePage.allProcessFacePage();
        BasicHolderJobPage basicHolderJobPage = basicInfoPage.allProcessBasicAddressPage(clientData);
        ApplyCreditPage applyCreditPage = basicHolderJobPage.allProcessBasicAddressPage();
        RegSecureCode regSecureCode = applyCreditPage.allApplyCreditPage();

        regSecureCode.insertSecurityCode(false);
        regSecureCode.verifyWrongSecurity();
    }

    @Test(priority = 45)
    public void TC008_PrescreenRequest_SecureCode_InputCorrectCode() {
        logIN.logINClienteAsesor(constants.CLIENTE);
        PMLPage moneyLaunderingPage = reg.AllProcessClientReg();

        INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();
        AddressPhotoPage addressPage = inePhotoPage.allProcessIFEPhotos();
        FacialRegistrationPage facePage = addressPage.allProcessAddressPage();
        BasicHolderAddressPage basicInfoPage = facePage.allProcessFacePage();
        BasicHolderJobPage basicHolderJobPage = basicInfoPage.allProcessBasicAddressPage(clientData);
        ApplyCreditPage applyCreditPage = basicHolderJobPage.allProcessBasicAddressPage();
        RegSecureCode regSecureCode = applyCreditPage.allApplyCreditPage();

        regSecureCode.insertSecurityCode(true);
        regSecureCode.verifyCorrectSecurityCode();
    }
}