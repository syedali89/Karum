using NUnit.Framework;
using OpenQA.Selenium;
using utility;

namespace pages
{
    public class INEPhotoPage : BasePage
    {
        //By checkbox
        public By identificacionVigenteCheckbox = By.Id("com.karum.credits:id/checkbox_1");
        public By validadoElementosSeguridadCheckbox = By.Id("com.karum.credits:id/checkbox_2");
        public By capturarINEIFEbtn = By.Id("com.karum.credits:id/button_capture_identification");

        //Contructor
        public INEPhotoPage(Driver driver) : base(driver)
        {
        }

        public void tapCheckboxs(bool identificacionVigente, bool validadoElementosSeguridad)
        {
            if (identificacionVigente)
            {
                clickElement(identificacionVigenteCheckbox);
            }
            if (validadoElementosSeguridad)
            {
                clickElement(validadoElementosSeguridadCheckbox);
            }
        }
        public void verifycapturarINEIFEbtnState(bool isEnabled)
        {
            string state = "Disabled";
            if (isEnabled)
            {
                state = "Enabled";
            }

            Assert.AreEqual(isEnabled, validateElementEnable(capturarINEIFEbtn),
                    "Error, checkbox 'Identificacion Vigente' and 'elementos de seguridad validados' are mandatory and 'Capturar INE/IFE' has to be " 
                    + state + ".");
        }
    }
}