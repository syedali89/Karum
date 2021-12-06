namespace pages
{
    using OpenQA.Selenium;

    public partial class INEPhotoPage : BasePage
    {
        //By checkbox
        public By identificacionVigenteCheckbox = By.Id("com.karum.credits:id/checkbox_1");
        public By validadoElementosSeguridadCheckbox = By.Id("com.karum.credits:id/checkbox_2");
        public By capturarINEIFEbtn = By.Id("com.karum.credits:id/button_capture_identification");

        public override void SetIOSBy()
        {
            base.SetIOSBy();

            identificacionVigenteCheckbox = By.XPath("//*[contains(@label, 'checked')][1]");
            validadoElementosSeguridadCheckbox = By.XPath("//*[contains(@label, 'checked')][2]");
            capturarINEIFEbtn = By.XPath("//*[@label='CAPTURAR INE/IFE']");
        }
    }
}