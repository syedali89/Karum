using NUnit.Framework;
using pages;
using utility;

namespace tests
{
    public class LogINSuite : BaseTest 
    {
        public LogIN logIN;
    
        [SetUp]
        public void beforeMethod()
        {
            _driver.GetIntance().LaunchApp();
            logIN = new LogIN(_driver);
            logIN.grantAllPermissions();
            clientData = DataRecover.RecoverClientData();
        }

        [Test, Order(1)]
        public void TC031_LOGIN_ExistingClient() 
        {
            logIN.logINClienteAsesor(constants.CLIENTE);
            logIN.validateSOYCLIENTELogINEmailPhone();
        }

        [Test, Order(2)]
        public void TC032_LOGIN_AllFiendsMandatory() 
        {
            logIN.logINClienteAsesor(constants.CLIENTE);
            logIN.inputEmail(clientData);
            logIN.inputPhone(clientData);

            logIN.verifyCONTINUARbtnState(true);
        }

        [Test, Order(3)]
        public void TC033_LOGIN_EmailFieldInvalidFormat_CONTINUARdisabled() 
        {
            logIN.logINClienteAsesor(constants.CLIENTE);
            clientData.userEmail = "QWERTY";

            logIN.inputEmail(clientData);
            logIN.inputPhone(clientData);

            logIN.verifyCONTINUARbtnState(false);
        }

        [Test, Order(4)]
        public void TC034_LOGIN_PhoneFieldInvalidFormat_CONTINUARdisabled() 
        {
            logIN.logINClienteAsesor(constants.CLIENTE);
            clientData.userPhone = "000";

            logIN.inputEmail(clientData);
            logIN.inputPhone(clientData);

            logIN.verifyCONTINUARbtnState(false);
        }

        [Test, Order(5)]
        public void TC035_LOGIN_IncorrectEmailPhoneCredentials() 
        {
            logIN.logINClienteAsesor(constants.CLIENTE);
            clientData.userEmail = "a@a.a";

            logIN.inputMandatoryFieldThenContinuar(clientData);
            logIN.verifyEmailPhoneIncorrect();
        }

        [Test, Order(6)]
        public void TC036_LOGIN_CorrectEmailPhoneCredentials() 
        {
            logIN.logINClienteAsesor(constants.CLIENTE);

            logIN.inputMandatoryFieldThenContinuar(clientData);
            logIN.verifyMessageActivationCode();
        }

        [Test, Order(7)]
        public void TC037_SecurityCodeLoginPage_ValidateText() 
        {
            logIN.logINClienteAsesor(constants.CLIENTE);

            logIN.inputMandatoryFieldThenContinuar(clientData);
            logIN.verifySecurityCodeLoginText(clientData);
        }

        [Test, Order(8)]
        public void TC038_SecurityCodeLoginPage_SecurityCodeMandatory() 
        {
            logIN.logINClienteAsesor(constants.CLIENTE);

            logIN.inputMandatoryFieldThenContinuar(clientData);
            logIN.insertSecurityCode(false);
            logIN.verifyCONTINUARbtnState(true);
        }

        [Test, Order(9)]
        public void TC039_SecurityCodeLoginPage_WrongSecurityCode() 
        {
            logIN.logINClienteAsesor(constants.CLIENTE);

            logIN.inputMandatoryFieldThenContinuar(clientData);
            logIN.insertSecurityCode(false);
            logIN.tapContinuar();
            logIN.verifyBadCode();
        }

        [Test, Order(10)]
        public void TC040_SecurityCodeLoginPage_CorrectSecurityCode() 
        {
            logIN.logINClienteAsesor(constants.CLIENTE);

            logIN.inputMandatoryFieldThenContinuar(clientData);
            logIN.insertSecurityCode(true);
            logIN.tapContinuar();
            logIN.verifyPasswordPage(clientData);
        }

        [Test, Order(11)]
        public void TC041_PasswordPage_InputIncorrectPassword() 
        {
            logIN.logINClienteAsesor(constants.CLIENTE);

            logIN.inputMandatoryFieldThenContinuar(clientData);
            logIN.insertSecurityCode(true);
            logIN.tapContinuar();

            clientData.userPass = "WRONG";
            logIN.iniciaSessionPassword(clientData);
            logIN.verifyBadPassword();
        }

        [Test, Order(12)]
        public void TC042_PasswordPage_InputCorrectPassword() 
        {
            logIN.logINClienteAsesor(constants.CLIENTE);

            logIN.inputMandatoryFieldThenContinuar(clientData);
            logIN.insertSecurityCode(true);
            logIN.tapContinuar();

            logIN.iniciaSessionPassword(clientData);
            logIN.verifyCorrectPassword();
        }
    }
}