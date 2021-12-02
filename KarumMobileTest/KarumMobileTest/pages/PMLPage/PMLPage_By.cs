using data;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using utility;

namespace pages
{
    //PreventMoneyLaunderingPageObject
    public partial class PMLPage : BasePage 
    {
        //By elements
        public By continueBtn = By.Id("com.karum.credits:id/btn_continue");

        public override void SetIOSBy()
        {
            base.SetIOSBy();

            continueBtn = By.XPath("//*[@label='CONTINUAR']");
        }

        public By GetSINOACEPTOBy(aceptoField aceptoFieldradiobutton, int radPosition)
        {
            By returnBy = null;

            if (aceptoFieldradiobutton == aceptoField.SIACEPTO)
            {
                if (_driver.GetDevice().Equals(EnvironmentData.DEVICE.ANDROID))
                {
                    returnBy = By.Id("com.karum.credits:id/rb_yes_" + radPosition);
                }
                else
                {
                    returnBy = By.XPath(string.Format("//XCUIElementTypeOther[1]/XCUIElementTypeOther[{0}]/XCUIElementTypeOther[1]/XCUIElementTypeButton[1]", radPosition));
                }
            }
            else if (aceptoFieldradiobutton == aceptoField.NOACEPTO)
            {
                if (_driver.GetDevice().Equals(EnvironmentData.DEVICE.ANDROID))
                {
                    returnBy = By.Id("com.karum.credits:id/rb_no_" + radPosition);
                }
                else
                {
                    returnBy = By.XPath(string.Format("//XCUIElementTypeOther[1]/XCUIElementTypeOther[{0}]/XCUIElementTypeOther[1]/XCUIElementTypeButton[2]", radPosition));
                }
            }

            return returnBy;
        }
    }
}