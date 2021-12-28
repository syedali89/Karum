namespace pages
{
    using OpenQA.Selenium;

    public partial class LogIN : BasePage
    {
        //LogIN
        public By soyClienteBtn = By.Id("com.karum.credits:id/btn_client");
        public By inputemail = By.Id("com.karum.credits:id/et_email");
        public By inputPhoneNumber = By.Id("com.karum.credits:id/et_phone");
        public By inputPhoneNumberArea = By.Id("com.karum.credits:id/et_code_area");
        public By registrateGobtn = By.Id("com.karum.credits:id/btn_on_boarding");
        public By CONTINUARbtn = By.Id("com.karum.credits:id/btn_continue");
        public By titleScreenCLIENTE = By.Id("com.karum.credits:id/tv_title_login");

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
        public By alertMessageBadCode = By.Id("com.karum.credits:id/tv_error_login");
        public By resendcodeLinktext = By.Id("com.karum.credits:id/btn_resend_sms");
        
        public override void SetIOSBy()
        {
            base.SetIOSBy();

            soyClienteBtn = By.XPath("//XCUIElementTypeButton[@label='SOY CLIENTE']");
            inputemail = By.XPath("//XCUIElementTypeScrollView/XCUIElementTypeOther[1]/XCUIElementTypeOther[2]/XCUIElementTypeOther[1]/XCUIElementTypeTextField[1]");
            inputPhoneNumber = By.XPath("//XCUIElementTypeScrollView/XCUIElementTypeOther[1]/XCUIElementTypeOther[1]/XCUIElementTypeOther[2]/XCUIElementTypeOther[1]/XCUIElementTypeTextField[1]");
            inputPhoneNumberArea = By.XPath("//*[@value='+52']");

            registrateGobtn = By.XPath("//*[@label='No tienes cuenta, regístrate']");
            CONTINUARbtn = By.XPath("//*[@label='CONTINUAR']");
            titleScreenCLIENTE = By.XPath("//*[contains(@label,'Comienza a comprar')]");

            alertMessageBadCode = By.XPath("//*[contains(@label, 'Código incorrecto')]");
            greatingsActivationDevice = By.XPath("//*[contains(@label, 'Hola, ')]");
            wrongPasswordMessage = By.XPath("//*[contains(@label, 'Contraseña incorrecta')]");
            messageActivationDevice = By.XPath("//*[contains(@label,'Activa tu dispositivo')]");
            inputSecurityCode = By.XPath("//XCUIElementTypeTextField");
            resendcodeLinktext = By.XPath("//*[@label='¿No recibiste el código? Enviar de nuevo']");

            ///TODO
            logINPassword = By.XPath("//XCUIElementTypeSecureTextField");
            userEmailOnScreen = By.XPath("//*[contains(@label, '@')]");
            changeUserBtn = By.XPath("//XCUIElementTypeScrollView/XCUIElementTypeOther[1]/XCUIElementTypeButton[1]");
            iniciaSesionBtn = By.XPath("//XCUIElementTypeButton[3]");
        }
    }
}