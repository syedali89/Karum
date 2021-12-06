namespace pages
{
    using data;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using utility;
    using static constants;

    public partial class LogIN : BasePage
    {        
        public LogIN(Driver driver) : base(driver) 
        {
        }

        public void logINClienteAsesor(string type) 
        {
            _driver.Report.StepDescription("Tap button:" + type);

            if (type.Equals(CLIENTE))
            {
                clickElement(soyClienteBtn);
            }

            _driver.Report.EndStep();
        }

        public void insertSecurityCode(bool correct, Client client) 
        {
            _driver.Report.StepDescription("Insert the Security Code");

            string code;
            if(correct) 
            {
                code = DataRecover.RecoverSecurityCode(_driver, client);

                if(code.Equals(string.Empty))
                {
                    _driver.exception = new NotFoundException(ERROR_RECOVERING_SECURITY_CODE);
                    throw _driver.exception;
                }
            }
            else 
            {
                code = "123456";
            }

            if (_driver.GetDevice().Equals(OS.ANDROID))
            {
                sendTextElement(inputSecurityCode, code);
            }
            else
            {
                _driver.GetIntance().FindElement(inputSecurityCode).SendKeys(code);
            }

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
            this.logINClienteAsesor(CLIENTE);

            this.inputMandatoryFieldThenContinuar(clientData);
            this.insertSecurityCode(true, clientData);
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
            if (_driver.GetDevice().Equals(OS.ANDROID))
            {
                assertElementText(resendcodeLinktext, "Enviar de nuevo");
                assertElementWithTextExist("¿No recibiste el código?");
            }
            else
            {
                assertElementText(resendcodeLinktext, "¿No recibiste el código? Enviar de nuevo");
            }

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

            string title = getTextElement(titleScreenCLIENTE);
            
            assertTextContains(title, "Comienza a comprar");
            assertTextContains(title, "desde tu celular");

            assertElementWithTextExist(@"Ingresa tu número celular (10 dígitos) *");

            Assert.IsTrue(validateElementVisible(inputPhoneNumber), "Error, input phone number field is not visible.");
            Assert.IsTrue(validateElementVisible(inputPhoneNumberArea), "Error, input phone area field is not visible.");

            assertElementWithTextExist(@"Correo electrónico *");
            Assert.IsTrue(validateElementVisible(inputemail), "Error, input phone number field is not Visible.");

            assertElementWithTextExist(@"* Campos obligatorios");

            if (_driver.GetDevice().Equals(OS.ANDROID))
            {
                assertElementWithTextExist("No tienes cuenta,");
            }

            Assert.IsTrue(validateElementVisible(registrateGobtn), "Error, registrate linktext is not Visible.");

            Assert.IsTrue(validateElementVisible(CONTINUARbtn), "Error, CONTINUAR button is not Visible.");
            verifyCONTINUARbtnState(false);

            _driver.Report.EndStep();
        }

        public void verifyEmailPhoneIncorrect() 
        {
            _driver.Report.StepDescription("Verify error login message when you introduce a email and phone that doesn't match");
            
            assertElementWithTextExist("Los datos proporcionados no coinciden con ningun registro");
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

        public void verifyCorrectPassword(Client clientData) 
        {
            _driver.Report.StepDescription("Verify correct Login when is introduce a correct password");

            assertElementText(headerTitle, "Hola, " + clientData.firstNameOne + " " + clientData.lastNameOne);

            _driver.Report.EndStep();
        }
    }
}