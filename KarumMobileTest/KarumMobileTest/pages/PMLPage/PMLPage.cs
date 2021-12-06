namespace pages
{
    using static constants;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using utility;

    //PreventMoneyLaunderingPageObject
    public partial class PMLPage : BasePage 
    {
        //Other Variables
        public enum aceptoField
        {
            SIACEPTO,
            NOACEPTO,
            UNINFORMED
        }

        public List<aceptoField> aceptoButtons = new List<aceptoField>
        {
                    aceptoField.UNINFORMED,
                    aceptoField.UNINFORMED,
                    aceptoField.UNINFORMED,
                    aceptoField.UNINFORMED,
                    aceptoField.UNINFORMED,
                    aceptoField.UNINFORMED
        };

        //Contructor
        public PMLPage(Driver driver) : base(driver) 
        {
        }

        public void SetSINOACEPTOradioButton(aceptoField siNoAcepto, int position) 
        {
            --position;
            aceptoButtons[position] = siNoAcepto;
        }

        public void SetAllFieldsSINOACEPTO(aceptoField siNoAcepto) 
        {            
            for (int position = 0; position < aceptoButtons.Count; position++) 
            {
                aceptoButtons[position] = siNoAcepto;
            }
        }

        public void tapACEPTOFields() 
        {
            _driver.Report.StepDescription("Check the 'ACEPTO' fields");

            int position = 1;
            foreach(aceptoField radiobutton in aceptoButtons) 
            {
                tapRadiobuttonSINOAcepto(radiobutton, position);
                position++;
            }

            _driver.Report.EndStep();
        }

        public void tapContinue() 
        {
            _driver.Report.StepDescription("Tap CONTINUAR button");

            SwipeAction.swipeDownUntilElementExist(_driver, continueBtn);
            clickElement(continueBtn);

            _driver.Report.EndStep();
        }

        public INEPhotoPage allProcessPNLProcess() 
        {
            this.SetAllFieldsSINOACEPTO(aceptoField.SIACEPTO);
            this.tapACEPTOFields();
            this.tapContinue();
            return new INEPhotoPage(_driver);
        }

        public void assertContinueBtnDisable() 
        {
            _driver.Report.StepDescription("Verify if CONTINUAR button is disabled");

            Assert.IsTrue(!validateElementEnable(continueBtn), "Error, CONTINUE button is enabled and all 'SI ACEPTO' aren't selected.");

            _driver.Report.EndStep();
        }

        public void assertContinueBtnEnable() 
        {
            _driver.Report.StepDescription("Verify if CONTINUAR button is enabled");

            Assert.IsTrue(validateElementEnable(continueBtn), "Error, CONTINUE button is disable and all 'SI ACEPTO' are selected.");

            _driver.Report.EndStep();
        }

        public void assertPMLText() 
        {
            _driver.Report.StepDescription("Verify if all elements from Prevent Laundering are on screen");

            if (_driver.GetDevice().Equals(OS.ANDROID))
            {
                assertElementWithTextExist(
                        @"Te queremos conocer mejor, por favor responde las preguntas para poder hacerlo:");
                assertElementWithTextExist(
                        @"Declaro bajo protesta de decir la verdad que no desempeño actualmente ni durante el año inmediato anterior algún cargo público destacado a nivel federal, estatal, municipal o distrito en México o en el extranjero.");
                assertElementWithTextExist(
                        @"Declaro también que mi cónyuge, en su caso, o pariente por consanguinidad o afinidad hasta el 2º grado, no desempeña actualmente ni durante el año inmediato anterior ningún cargo público destacado a nivel federal, estatal, municipal o distrital en México o en el extranjero.");
                assertElementWithTextExist(
                        @"Declaro que ningún tercero obtendrá los beneficios derivados de las operaciones realizadas con KUALI SERVICIOS INTEGRALES DE EMPRENDIMIENTO SAPI DE C.V SOFOM E.N.R. ni ejercerá los derechos de uso, aprovechamiento o disposición de los recursos operados, siendo el verdadero propietario de los mismos. (Propietario real)");
                assertElementWithTextExist(
                        @"Declaro que ningún tercero aportará regularmente recursos para el cumplimiento de las obligaciones derivadas del contrato que se establece con KUALI SERVICIOS INTEGRALES DE EMPRENDIMIENTO SAPI DE C.V SOFOM E.N.R. sin ser el titular de dicho contrato ni obtener los beneficios económicos derivados del mismo.");
                assertElementWithTextExist(
                        @"Declaro que bajo protesta de decir verdad que para efectos de la realización de las operaciones con KUALI SERVICIOS INTEGRALES DE EMPRENDIMIENTO SAPI DE C.V SOFOM E.N.R. estoy actuando por cuenta propia.");
                assertElementWithTextExist(
                        @"Declaro que los recursos que utilizaré para el pago de este producto provienen de una fuente licita.");
            }
            else if (_driver.GetDevice().Equals(OS.IOS))
            {
                assertElementText(By.XPath("//*[contains(@label, 'Te queremos conocer mejor')]"), "Te queremos conocer mejor, por favor responde las preguntas para poder hacerlo:");
                
                assertElementText(By.XPath("//XCUIElementTypeOther[1]/XCUIElementTypeOther[1]/XCUIElementTypeOther[1]/XCUIElementTypeStaticText[1]"), "Declaro bajo protesta de decir la verdad que no desempeño actualmente ni durante el año inmediato anterior algún cargo público destacado a nivel federal, estatal, municipal o distrito en México o en el extranjero.");
                
                assertElementText(By.XPath("//XCUIElementTypeOther[1]/XCUIElementTypeOther[2]/XCUIElementTypeOther[1]/XCUIElementTypeStaticText[1]"), "Declaro también que mi cónyuge, en su caso, o pariente por consanguinidad o afinidad hasta el 2º grado, no desempeña actualmente ni durante el año inmediato anterior ningún cargo público destacado a nivel federal, estatal, municipal o distrital en México o en el extranjero.");
                
                assertElementText(By.XPath("//XCUIElementTypeOther[1]/XCUIElementTypeOther[3]/XCUIElementTypeOther[1]/XCUIElementTypeStaticText[1]"), "Declaro que ningún tercero obtendrá los beneficios derivados de las operaciones realizadas con KUALI SERVICIOS INTEGRALES DE EMPRENDIMIENTO SAPI DE C.V SOFOM E.N.R. ni ejercerá los derechos de uso, aprovechamiento o disposición de los recursos operados, siendo el verdadero propietario de los mismos. (Propietario real)");
                
                assertElementText(By.XPath("//XCUIElementTypeOther[1]/XCUIElementTypeOther[4]/XCUIElementTypeOther[1]/XCUIElementTypeStaticText[1]"), "Declaro que ningún tercero aportará regularmente recursos para el cumplimiento de las obligaciones derivadas del contrato que se establece con KUALI SERVICIOS INTEGRALES DE EMPRENDIMIENTO SAPI DE C.V SOFOM E.N.R. sin ser el titular de dicho contrato ni obtener los beneficios económicos derivados del mismo.");

                assertElementText(By.XPath("//XCUIElementTypeOther[1]/XCUIElementTypeOther[5]/XCUIElementTypeOther[1]/XCUIElementTypeStaticText[1]"), "Declaro que bajo protesta de decir verdad que para efectos de la realización de las operaciones con KUALI SERVICIOS INTEGRALES DE EMPRENDIMIENTO SAPI DE C.V SOFOM E.N.R. estoy actuando por cuenta propia.");

                assertElementText(By.XPath("//XCUIElementTypeOther[1]/XCUIElementTypeOther[6]/XCUIElementTypeOther[1]/XCUIElementTypeStaticText[1]"), "Declaro que los recursos que utilizaré para el pago de este producto provienen de una fuente licita.");
            }

            Assert.IsTrue(SwipeAction.swipeDownUntilElementExist(_driver, continueBtn), "Error, CONTINUE button doesn't exist");

            _driver.Report.EndStep();
        }

        private void tapRadiobuttonSINOAcepto(aceptoField aceptoFieldradiobutton, int radPosition) 
        {
            if (aceptoFieldradiobutton != aceptoField.UNINFORMED) 
            {
                By tapField = GetSINOACEPTOBy(aceptoFieldradiobutton, radPosition);

                SwipeAction.swipeDownUntilElementExist(_driver, tapField);
                clickElement(tapField);
            }
        }
    }
}