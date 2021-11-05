namespace pages
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using utility;

    public class RegisterPage : BasePage
    {
        //By elements
        public By registrateGobtn = By.Id("com.karum.credits:id/btn_on_boarding");
        public By registrateMessage = By.Id("com.karum.credits:id/tv_title_privacy_notice");
        public By registratemebtn = By.Id("com.karum.credits:id/btn_register_privacy_notice");
        public By avisoPrivacidadCheckbox = By.Id("com.karum.credits:id/cb_privacy_notice");
        public By avisoPrivacidadLink = By.Id("com.karum.credits:id/tv_privacy_notice");
        public By avisoPrivacidadClose = By.Id("com.karum.credits:id/iv_close_privacy_notice");

        //Contructor
        public RegisterPage(Driver driver) : base(driver)
        {}

        public void goRegistrationPage()
        {
            clickElement(registrateGobtn);
        }

        public void goAvisoPrivacidad()
        {
            SwipeAction.swipeDownUntilElementExist(_driver, avisoPrivacidadLink);
            clickElement(avisoPrivacidadLink);
        }

        public void acceptAvisoPrivacidad()
        {
            SwipeAction.swipeDownUntilElementExist(_driver, avisoPrivacidadCheckbox);
            clickElement(avisoPrivacidadCheckbox);
        }

        public void tapRegistrarme()
        {
            SwipeAction.swipeDownUntilElementExist(_driver, registratemebtn);
            clickElement(registratemebtn);
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
            Assert.IsTrue(validateElementEnable(registratemebtn), "Error, REGISTRARME button is not enabled after accept 'Aviso Privacidad'.");
        }

        public void assertAvisoPrivacidad()
        {
            assertElementWithTextExist("Aviso de privacidad");
            Assert.IsTrue(validateElementVisible(avisoPrivacidadClose),
                    "Error, document close button 'Aviso Privacidad' is not visible.");
            assertDocumentText(
                    "Aviso de privacidad", DataRecover.AvisoPrivacidadDocument());
            clickElement(avisoPrivacidadClose);
            Assert.IsTrue(validateElementVisible(registratemebtn),
                    "Error, REGISTRARME button is not visible after tap on close Aviso Privacidad button.");
        }

        public void assertInitialRegistrationPage()
        {
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
        }
    }
}