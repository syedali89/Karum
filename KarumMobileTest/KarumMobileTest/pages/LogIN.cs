using data;
using NUnit.Framework;
using OpenQA.Selenium;
using utility;

namespace pages
{
    public class LogIN : BasePage
    {
        //LogIN
        public By soyClienteBtn = By.Id("com.karum.credits:id/btn_client");
        public By inputemail = By.Id("com.karum.credits:id/et_email");
        public By inputPhoneNumber = By.Id("com.karum.credits:id/et_phone");
        public By inputPhoneNumberArea = By.Id("com.karum.credits:id/et_code_area");
        public By registrateGobtn = By.Id("com.karum.credits:id/btn_on_boarding");
        public By CONTINUARbtn = By.Id("com.karum.credits:id/btn_continue");
        public By titleScreenCLIENTE = By.Id("com.karum.credits:id/tv_title_login");
        public By alertMessage = By.Id("android:id/message");

        //Password
        public By logINPassword = By.Id("com.karum.credits:id/et_pass_login");
        public By userEmailOnScreen = By.Id("com.karum.credits:id/tv_username");
        public By changeUserBtn = By.Id("com.karum.credits:id/tv_change_user");
        public By iniciaSesionBtn = By.Id("com.karum.credits:id/btn_login");

        //Security Code Menu
        public By greatingsActivationDevice = By.Id("com.karum.credits:id/tv_sms_title");
        public By messageActivationDevice = By.Id("com.karum.credits:id/tv_instructions_sms");
        public By inputSecurityCode = By.Id("com.karum.credits:id/pv_otp");
        public By continueBtn = By.Id("com.karum.credits:id/btn_continue");
        public By alertMessageBadCode = By.Id("com.karum.credits:id/tv_error_login");
        public By resendcodeLinktext = By.Id("com.karum.credits:id/btn_resend_sms");

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="driver"></param>
        public LogIN(Driver driver) : base(driver) 
        {   
        }

        public void logINClienteAsesor(string type) {
            if(type.Equals(constants.CLIENTE)) 
            {
                clickElement(soyClienteBtn);
            }
        }

        public void insertSecurityCode(bool correct) 
        {
            string code;
            if(correct) 
            {
                code = DataRecover.RecoverSecurityCode();

                if(code.Equals(string.Empty))
                {
                    throw new NotFoundException("Error trying to recover security code");
                }
            }
            else 
            {
                code = "111111";
            }

            sendTextElement(inputSecurityCode, code);
        }

        public void inputEmail(Client client) 
        {
            sendTextElement(inputemail, client.userEmail);
        }

        public void inputPhone(Client client) 
        {
            sendTextElement(inputPhoneNumber, client.userPhone);
        }

        public void inputPassword(Client client) 
        {
            sendTextElement(logINPassword, client.userPass);
        }

        public void tapContinuar() 
        {
            clickElement(CONTINUARbtn);
        }

        public void inputMandatoryFieldThenContinuar(Client client) 
        {
            inputEmail(client);
            inputPhone(client);
            clickElement(CONTINUARbtn);
        }

        public void iniciaSessionPassword(Client client) 
        {
            inputPassword(client);
            clickElement(iniciaSesionBtn);
        }

        public HomePage allLoginProcess(Client clientData) 
        {
            this.logINClienteAsesor(constants.CLIENTE);

            this.inputMandatoryFieldThenContinuar(clientData);
            this.insertSecurityCode(true);
            this.tapContinuar();

            this.iniciaSessionPassword(clientData);
            return new HomePage(_driver);
        }

        public void verifyBadCode() 
        {
            assertElementText(alertMessageBadCode, "Código incorrecto, inténtalo nuevamente");
        }

        public void verifyMessageActivationCode() 
        {
            Assert.IsTrue(validateElementVisible(inputSecurityCode),
                    "Error, Security Code Input Field is not visible.");
        }

        public void verifySecurityCodeLoginText(Client client) 
        {
            string lastPhone = client.userPhone.Substring(client.userPhone.Length - 4);

            assertElementText(greatingsActivationDevice, "Hola, "+ client.firstNameOne);
            assertElementText(messageActivationDevice, "Activa tu dispositivo, ingresando el código de activación que te enviamos por SMS al ******" + lastPhone);
            assertElementText(resendcodeLinktext, "Enviar de nuevo");
            assertElementWithTextExist("¿No recibiste el código?");

            Assert.IsTrue(validateElementVisible(inputSecurityCode),
                    "Error, Security Code Input Field is not visible.");

            Assert.IsTrue(validateElementVisible(CONTINUARbtn),
                    "Error, CONTINUAR button is not visible.");
        }

        public void verifyCONTINUARbtnState(bool isEnable) 
        {
            string enabledDisabledMessage = "disabled";
            if(isEnable) {
                enabledDisabledMessage = "enabled";
            }

            Assert.AreEqual(validateElementEnable(CONTINUARbtn), isEnable,
                    "Error, CONTINUAR btn input should be " + enabledDisabledMessage);
        }

        public void validateSOYCLIENTELogINEmailPhone() 
        {
            assertElementText(titleScreenCLIENTE, "Comienza a comprar\r\ndesde tu celular");

            assertElementWithTextExist("Ingresa tu número celular (10 digitos) *");
            Assert.IsTrue(validateElementVisible(inputPhoneNumber), "Error, input phone number field is not visible.");
            Assert.IsTrue(validateElementVisible(inputPhoneNumberArea), "Error, input phone area field is not visible.");

            assertElementWithTextExist("Correo electrónico *");
            Assert.IsTrue(validateElementVisible(inputemail), "Error, input phone number field is not Visible.");

            assertElementWithTextExist("* Campos obligatorios");
            assertElementWithTextExist("No tienes cuenta,");
            Assert.IsTrue(validateElementVisible(registrateGobtn), "Error, registrate linktext is not Visible.");

            Assert.IsTrue(validateElementVisible(CONTINUARbtn), "Error, CONTINUAR button is not Visible.");
            verifyCONTINUARbtnState(false);
        }

        public void verifyEmailPhoneIncorrect() 
        {
            assertElementText(alertMessage, "Los datos proporcionados no coinciden con ningun registro");
            assertElementWithTextExist("ACEPTAR");
        }

        public void verifyPasswordPage(Client client) 
        {
            assertElementWithTextExist("Hola, "+ client.firstNameOne);
            assertElementWithTextExist("Usuario");
            assertElementText(userEmailOnScreen, client.userEmail);
            assertElementText(changeUserBtn, "Cambiar usuario");

            assertElementWithTextExist("Contraseña *");
            Assert.IsTrue(validateElementVisible(logINPassword),
                    "Error, input Password field is not visible");

            assertElementText(iniciaSesionBtn, "INICIA SESIÓN");
        }

        public void verifyBadPassword() 
        {
            assertElementWithTextExist("Contraseña incorrecta");
        }

        public void verifyCorrectPassword() 
        {
            assertElementWithTextExist("Crédito Karum");
        }
    }
}