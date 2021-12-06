using NUnit.Framework;
using utility;

namespace tests
{
    [TestFixture("Log IN Suite")]
    public class LogINSuite : BaseTest 
    {
        public LogINSuite(string testClass)
        {
            this.testClass = testClass;
        }

        [SetUp]
        public override void beforeMethod()
        {
            base.beforeMethod();
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
            clientData.userEmail = "test1@mail.com";

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
            logIN.insertSecurityCode(false, clientData);
            logIN.verifyCONTINUARbtnState(true);
        }

        [Test, Order(13)]
        public void TC039_SecurityCodeLoginPage_WrongSecurityCode() 
        {
            logIN.logINClienteAsesor(constants.CLIENTE);

            logIN.inputMandatoryFieldThenContinuar(clientData);
            logIN.insertSecurityCode(false, clientData);
            logIN.tapContinuar();
            logIN.verifyBadCode();
        }

        [Test, Order(9)]
        public void TC040_SecurityCodeLoginPage_CorrectSecurityCode() 
        {
            logIN.logINClienteAsesor(constants.CLIENTE);

            logIN.inputMandatoryFieldThenContinuar(clientData);
            logIN.insertSecurityCode(true, clientData);
            logIN.tapContinuar();
            logIN.verifyPasswordPage(clientData);
        }

        [Test, Order(10)]
        public void TC041_PasswordPage_InputIncorrectPassword() 
        {
            logIN.logINClienteAsesor(constants.CLIENTE);

            logIN.inputMandatoryFieldThenContinuar(clientData);
            logIN.insertSecurityCode(true, clientData);
            logIN.tapContinuar();

            clientData.userPass = "WRONG";
            logIN.iniciaSessionPassword(clientData);
            logIN.verifyBadPassword();
        }

        [Test, Order(11)]
        public void TC042_PasswordPage_InputCorrectPassword() 
        {
            logIN.logINClienteAsesor(constants.CLIENTE);

            logIN.inputMandatoryFieldThenContinuar(clientData);
            logIN.insertSecurityCode(true, clientData);
            logIN.tapContinuar();

            logIN.iniciaSessionPassword(clientData);
            logIN.verifyCorrectPassword(clientData);
        }
    }
}