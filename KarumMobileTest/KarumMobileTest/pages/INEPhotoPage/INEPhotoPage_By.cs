using NUnit.Framework;
using OpenQA.Selenium;
using utility;

namespace pages
{
    public partial class INEPhotoPage : BasePage
    {
        //By checkbox
        public By identificacionVigenteCheckbox = By.Id("com.karum.credits:id/checkbox_1");
        public By validadoElementosSeguridadCheckbox = By.Id("com.karum.credits:id/checkbox_2");
        public By capturarINEIFEbtn = By.Id("com.karum.credits:id/button_capture_identification");

        public override void SetIOSBy()
        {
            base.SetIOSBy();

            ///TODO
            identificacionVigenteCheckbox = By.Id("com.karum.credits:id/checkbox_1");
            validadoElementosSeguridadCheckbox = By.Id("com.karum.credits:id/checkbox_2");
            capturarINEIFEbtn = By.Id("com.karum.credits:id/button_capture_identification");
        }
    }
}