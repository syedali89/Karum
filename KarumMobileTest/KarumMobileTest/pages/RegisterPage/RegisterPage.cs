namespace pages
{
    using NUnit.Framework;
    using utility;

    public partial class RegisterPage : BasePage
    {
        //Contructor
        public RegisterPage(Driver driver) : base(driver)
        {}

        public void goRegistrationPage()
        {
            _driver.Report.StepDescription("Tap 'Registrate' Linktext");

            clickElement(registrateGobtn);

            _driver.Report.EndStep();
        }

        public void goAvisoPrivacidad()
        {
            _driver.Report.StepDescription("Tap 'Aviso Privacidad' Linktext");

            SwipeAction.swipeDownUntilElementExist(_driver, avisoPrivacidadLink);
            clickElement(avisoPrivacidadLink);

            _driver.Report.EndStep();
        }

        public void acceptAvisoPrivacidad()
        {
            _driver.Report.StepDescription("Tap 'Acepto aviso Privacidad' Checkbox");

            SwipeAction.swipeDownUntilElementExist(_driver, avisoPrivacidadCheckbox);
            clickElement(avisoPrivacidadCheckbox);

            _driver.Report.EndStep();
        }

        public void tapRegistrarme()
        {
            _driver.Report.StepDescription("Tap 'Registrarme' button");

            SwipeAction.swipeDownUntilElementExist(_driver, registratemebtn);
            clickElement(registratemebtn);

            _driver.Report.EndStep();
        }

        public PMLPage AllProcessClientReg()
        {
            this.goRegistrationPage();
            this.acceptAvisoPrivacidad();
            this.tapRegistrarme();
            return new PMLPage(_driver);
        }

        public void assertRegistrarmeBtnEnabled()
        {
            _driver.Report.StepDescription("Verify if REGISTRARME button is enabled");

            Assert.IsTrue(validateElementEnable(registratemebtn), "Error, REGISTRARME button is not enabled after accept 'Aviso Privacidad'.");

            _driver.Report.EndStep();
        }

        public void assertAvisoPrivacidad()
        {
            _driver.Report.StepDescription("Verify Aviso de privacidad Document");

            assertElementWithTextExist("Aviso de privacidad");
            Assert.IsTrue(validateElementVisible(avisoPrivacidadClose),
                    "Error, document close button 'Aviso Privacidad' is not visible.");
            assertDocumentText(
                    "Aviso de privacidad", DataRecover.AvisoPrivacidadDocument());
            clickElement(avisoPrivacidadClose);
            Assert.IsTrue(validateElementVisible(registratemebtn),
                    "Error, REGISTRARME button is not visible after tap on close Aviso Privacidad button.");

            _driver.Report.EndStep();
        }

        public void assertInitialRegistrationPage()
        {
            _driver.Report.StepDescription("Verify if all elements from Registration Page are on Screen");

            assertElementText(registrateMessage, "Regístrate ahora y solicita tu crédito en menos de 5 minutos");
            assertElementWithTextExist("Debes contar con la siguiente documentación para iniciar tu registro:");
            assertElementWithTextExist("Identificación oficial");
            assertElementWithTextExist("INE / IFE vigente");

            assertElementWithTextExist("Comprobante de domicilio");
            assertElementWithTextExist("CFE Luz");
            assertElementWithTextExist("Agua");
            assertElementWithTextExist("Predial");
            assertElementWithTextExist("Telmex (línea fija)");
            assertElementWithTextExist("TV de paga cable fijo");
            assertElementWithTextExist("Gas Natural / conexión fija");
            assertElementWithTextExist("Contrato de arrendamiento a nombre del solicitante");
            assertElementWithTextExist("Edos. de Cta. bancarios a nombre del solicitante");
            assertElementWithTextExist("(cheques, ahorro, crédito, débito)");

            assertElementWithTextExist("Registro facial");
            assertElementWithTextExist("Considera también que te pediremos tomarte una selfie.");
            assertElementWithTextExist("Autorizo el");

            Assert.IsTrue(SwipeAction.swipeDownUntilElementExist(_driver, avisoPrivacidadLink), "Error, 'aviso  de privacidad' LinkText is not visible.");
            
            Assert.IsTrue(SwipeAction.swipeDownUntilElementExist(_driver, registratemebtn), "Error, REGISTRARME button is not visible.");

            _driver.Report.EndStep();
        }
    }
}