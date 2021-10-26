using NUnit.Framework;
using pages;
using utility;

namespace tests
{    
    public class OnBoardingSuite : BaseTest
    {
        public LogIN logIN;
        public RegisterPage reg;

        [SetUp]
        public void beforeMethod() 
        {
            _driver.GetIntance().LaunchApp();
            logIN = new LogIN(_driver);
            reg = new RegisterPage(_driver);
            logIN.grantAllPermissions();
            clientData = DataRecover.RecoverClientData();
        }

        [Test, Order(1)]
        public void TC002_InitialScreen() 
        {
            logIN.logINClienteAsesor(constants.CLIENTE);
            reg.goRegistrationPage();
            reg.assertInitialRegistrationPage();
        }

        [Test, Order(2)]
        public void TC002_InitialScreen_AvisoPrivacidadDocument() 
        {
            logIN.logINClienteAsesor(constants.CLIENTE);
            reg.goRegistrationPage();
            reg.goAvisoPrivacidad();
            reg.assertAvisoPrivacidad();
        }

        [Test, Order(3)]
        public void TC002_InitialScreen_AcceptAvisoPrivacidadRegistrarmeEnable() 
        {
            logIN.logINClienteAsesor(constants.CLIENTE);
            reg.goRegistrationPage();
            reg.acceptAvisoPrivacidad();
            reg.assertRegistrarmeBtnEnabled();
        }

        [Test, Order(4)]
        public void TC003_AMLQuestionnaire_NothingSelected_DisableContinue() 
        {
            logIN.logINClienteAsesor(constants.CLIENTE);
            PMLPage moneyLaunderingPage = reg.AllProcessClientReg();

            moneyLaunderingPage.assertContinueBtnDisable();
        }

        [Test, Order(5)]
        public void TC003_AMLQuestionnaire_OneYesRestUnSelected_DisableContinue() 
        {
            logIN.logINClienteAsesor(constants.CLIENTE);
            PMLPage moneyLaunderingPage = reg.AllProcessClientReg();

            moneyLaunderingPage.SetSINOACEPTOradioButton(PMLPage.aceptoField.SIACEPTO, 3);
            moneyLaunderingPage.tapACEPTOFields();
            moneyLaunderingPage.assertContinueBtnDisable();
        }

        [Test, Order(6)]
        public void TC003_AMLQuestionnaire_AllNoSelected_DisableContinue() 
        {
            logIN.logINClienteAsesor(constants.CLIENTE);
            PMLPage moneyLaunderingPage = reg.AllProcessClientReg();

            moneyLaunderingPage.SetAllFieldsSINOACEPTO(PMLPage.aceptoField.NOACEPTO);
            moneyLaunderingPage.tapACEPTOFields();
            moneyLaunderingPage.assertContinueBtnDisable();
        }

        [Test, Order(7)]
        public void TC003_AMLQuestionnaire_OneNORestYesSelected_DisableContinue() 
        {
            logIN.logINClienteAsesor(constants.CLIENTE);
            PMLPage moneyLaunderingPage = reg.AllProcessClientReg();

            moneyLaunderingPage.SetAllFieldsSINOACEPTO(PMLPage.aceptoField.SIACEPTO);
            moneyLaunderingPage.SetSINOACEPTOradioButton(PMLPage.aceptoField.NOACEPTO, 1);
            moneyLaunderingPage.tapACEPTOFields();
            moneyLaunderingPage.assertContinueBtnDisable();
        }

        [Test, Order(8)]
        public void TC003_AMLQuestionnaire_AllYesSelected_EnableContinue() 
        {
            logIN.logINClienteAsesor(constants.CLIENTE);
            PMLPage moneyLaunderingPage = reg.AllProcessClientReg();

            moneyLaunderingPage.SetAllFieldsSINOACEPTO(PMLPage.aceptoField.SIACEPTO);
            moneyLaunderingPage.tapACEPTOFields();
            moneyLaunderingPage.assertContinueBtnEnable();
        }

        [Test, Order(9)]
        public void TC003_AMLQuestionnaire_ValidateText() 
        {
            logIN.logINClienteAsesor(constants.CLIENTE);
            PMLPage moneyLaunderingPage = reg.AllProcessClientReg();

            moneyLaunderingPage.assertPMLText();
        }

        [Test, Order(10)]
        public void TC004_INEIFEEvaluation_IdentificacionVigenteCheckBoxRequired() 
        {
            logIN.logINClienteAsesor(constants.CLIENTE);
            PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
            INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();

            inePhotoPage.tapCheckboxs(false, true);
            inePhotoPage.verifycapturarINEIFEbtnState(false);
        }

        [Test, Order(11)]
        public void TC004_INEIFEEvaluation_ValidadoElementosSeguridadCheckboxCheckBoxRequired() 
        {
            logIN.logINClienteAsesor(constants.CLIENTE);
            PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
            INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();

            inePhotoPage.tapCheckboxs(true, false);
            inePhotoPage.verifycapturarINEIFEbtnState(false);
        }

        [Test, Order(12)]
        public void TC004_INEIFEEvaluation_AllCheckboxCheckBoxRequiredSelect() 
        {
            logIN.logINClienteAsesor(constants.CLIENTE);
            PMLPage moneyLaunderingPage = reg.AllProcessClientReg();
            INEPhotoPage inePhotoPage = moneyLaunderingPage.allProcessPNLProcess();

            inePhotoPage.tapCheckboxs(true, true);
            inePhotoPage.verifycapturarINEIFEbtnState(true);
        }
    }
}