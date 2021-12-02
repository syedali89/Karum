namespace pages
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using utility;

    public partial class RegisterPage : BasePage
    {
        //By elements
        public By registrateGobtn = By.Id("com.karum.credits:id/btn_on_boarding");
        public By registrateMessage = By.Id("com.karum.credits:id/tv_title_privacy_notice");
        public By registratemebtn = By.Id("com.karum.credits:id/btn_register_privacy_notice");
        public By avisoPrivacidadCheckbox = By.Id("com.karum.credits:id/cb_privacy_notice");
        public By avisoPrivacidadLink = By.Id("com.karum.credits:id/tv_privacy_notice");
        public By avisoPrivacidadClose = By.Id("com.karum.credits:id/iv_close_privacy_notice");

        public override void SetIOSBy()
        {
            base.SetIOSBy();

            registrateGobtn = By.XPath("//*[@label='No tienes cuenta, regístrate']");
            registrateMessage = By.XPath("//XCUIElementTypeOther[1]/XCUIElementTypeOther[1]/XCUIElementTypeOther[1]/XCUIElementTypeScrollView[1]/XCUIElementTypeOther[1]/XCUIElementTypeStaticText[1]");
            registratemebtn = By.XPath("//*[@label='REGÍSTRARME']");
            avisoPrivacidadCheckbox = By.XPath("//*[contains(@label,'checked')]");
            avisoPrivacidadLink = By.XPath("//*[@label='Autorizo el aviso de privacidad']");
            avisoPrivacidadClose = By.XPath("//*[@label='ic close']");
        }
    }
}