using data;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
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
        public By wrongPasswordMessage = By.XPath("//*[contains(@text, 'Contraseña incorrecta')]");

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
            _driver.Report.StepDescription("Tap button:" + type);

            if (type.Equals(constants.CLIENTE))
            {
                clickElement(soyClienteBtn);
            }

            _driver.Report.EndStep();
        }

        public void insertSecurityCode(bool correct) 
        {
            _driver.Report.StepDescription("Insert the Security Code");

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
            _driver.Report.EndStep();
        }

        public void inputEmail(Client client) 
        {
            _driver.Report.StepDescription("Inform the input email field");
            sendTextElement(inputemail, client.userEmail);
            _driver.Report.EndStep();
        }

        public void inputPhone(Client client) 
        {
            _driver.Report.StepDescription("Inform the input phone field");
            sendTextElement(inputPhoneNumber, client.userPhone);
            _driver.Report.EndStep();
        }

        public void inputPassword(Client client) 
        {
            _driver.Report.StepDescription("Inform the input Password field");
            sendTextElement(logINPassword, client.userPass);
            _driver.Report.EndStep();
        }

        public void tapContinuar() 
        {
            _driver.Report.StepDescription("Tap CONTINUAR button");
            clickElement(CONTINUARbtn);
            _driver.Report.EndStep();
        }

        public void inputMandatoryFieldThenContinuar(Client client) 
        {
            inputEmail(client);
            inputPhone(client);
            tapContinuar();
        }

        public void iniciaSessionPassword(Client client) 
        {            
            inputPassword(client);
            _driver.Report.StepDescription("Tap Inicia Sesion");
            clickElement(iniciaSesionBtn);
            _driver.Report.EndStep();
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
            _driver.Report.StepDescription("Verify error message when input a incorrect Security code");
            assertElementText(alertMessageBadCode, "Código incorrecto, inténtalo nuevamente");
            _driver.Report.EndStep();
        }

        public void verifyMessageActivationCode()
        {
            _driver.Report.StepDescription("Verify Security Code Message is on Screen");
            Assert.IsTrue(validateElementVisible(inputSecurityCode),
                    "Error, Security Code Input Field is not visible.");
            _driver.Report.EndStep();
        }

        public void verifySecurityCodeLoginText(Client client) 
        {
            _driver.Report.StepDescription("Verify if all elements from Security Code Page are on Screen");
            string lastPhone = client.userPhone.Substring(client.userPhone.Length - 4);

            assertElementText(greatingsActivationDevice, "Hola, "+ client.firstNameOne);
            assertElementText(messageActivationDevice, "Activa tu dispositivo, ingresando el código de activación que te enviamos por SMS al ******" + lastPhone);
            assertElementText(resendcodeLinktext, "Enviar de nuevo");
            assertElementWithTextExist("¿No recibiste el código?");

            Assert.IsTrue(validateElementVisible(inputSecurityCode),
                    "Error, Security Code Input Field is not visible.");

            Assert.IsTrue(validateElementVisible(CONTINUARbtn),
                    "Error, CONTINUAR button is not visible.");

            _driver.Report.EndStep();
        }

        public void verifyCONTINUARbtnState(bool isEnable) 
        {            
            string enabledDisabledMessage = "disabled";
            if(isEnable) {
                enabledDisabledMessage = "enabled";
            }

            _driver.Report.StepDescription("Verify if CONTINUAR button is " + enabledDisabledMessage);

            Assert.AreEqual(validateElementEnable(CONTINUARbtn), isEnable,
                    "Error, CONTINUAR btn input should be " + enabledDisabledMessage);

            _driver.Report.EndStep();
        }

        public void validateSOYCLIENTELogINEmailPhone() 
        {
            _driver.Report.StepDescription("Verify if all elements from LogIN Email and Phone are on screen");

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

            _driver.Report.EndStep();
        }

        public void verifyEmailPhoneIncorrect() 
        {
            _driver.Report.StepDescription("Verify error login message when you introduce a email and phone that doesn't match");

            assertElementText(alertMessage, "Los datos proporcionados no coinciden con ningun registro");
            assertElementWithTextExist("ACEPTAR");

            _driver.Report.EndStep();
        }

        public void verifyPasswordPage(Client client) 
        {
            _driver.Report.StepDescription("Verify if all elements from LogIN Password Page are on screen");

            assertElementWithTextExist("Hola, "+ client.firstNameOne);
            assertElementWithTextExist("Usuario");
            assertElementText(userEmailOnScreen, client.userEmail);
            assertElementText(changeUserBtn, "Cambiar usuario");

            assertElementWithTextExist(@"Contraseña *");
            Assert.IsTrue(validateElementVisible(logINPassword),
                    "Error, input Password field is not visible");

            assertElementText(iniciaSesionBtn, "INICIA SESIÓN");

            _driver.Report.EndStep();
        }

        public void verifyBadPassword() 
        {
            _driver.Report.StepDescription("Verify error message when is introduce a incorrect password");

            Assert.IsTrue(_driver.GetIntance().FindElements(wrongPasswordMessage).Count > 0, "Error, the error message for wrong password was not displayed on screen");

            _driver.Report.EndStep();
        }

        public void verifyCorrectPassword() 
        {
            _driver.Report.StepDescription("Verify correct Login when is introduce a correct password");

            assertElementWithTextExist("Crédito Karum");

            _driver.Report.EndStep();
        }
    }
}