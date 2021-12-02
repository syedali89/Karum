using NUnit.Framework;
using OpenQA.Selenium;
using utility;

namespace pages
{
    public partial class INEPhotoPage : BasePage
    {
        //Contructor
        public INEPhotoPage(Driver driver) : base(driver)
        {
        }

        public void tapCheckboxs(bool identificacionVigente, bool validadoElementosSeguridad)
        {
            _driver.Report.StepDescription("Tap CheckBox");

            if (identificacionVigente)
            {
                clickElement(identificacionVigenteCheckbox);
            }
            if (validadoElementosSeguridad)
            {
                clickElement(validadoElementosSeguridadCheckbox);
            }

            _driver.Report.EndStep();
        }
        public void verifycapturarINEIFEbtnState(bool isEnabled)
        {            
            string state = "Disabled";
            if (isEnabled)
            {
                state = "Enabled";
            }

            _driver.Report.StepDescription("Verify if 'Capturar INE' button is " + state);

            Assert.AreEqual(isEnabled, validateElementEnable(capturarINEIFEbtn),
                    "Error, checkbox 'Identificacion Vigente' and 'elementos de seguridad validados' are mandatory and 'Capturar INE/IFE' has to be " 
                    + state + ".");

            _driver.Report.EndStep();
        }
    }
}