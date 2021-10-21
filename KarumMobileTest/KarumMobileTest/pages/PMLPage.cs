using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using utility;

namespace pages
{
    //PreventMoneyLaunderingPageObject
    public class PMLPage : BasePage {
        //By elements
        public By continueBtn = By.Id("com.karum.credits:id/btn_continue");

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

        public void tapACEPTOFields() {
            int position = 1;
            foreach(aceptoField radiobutton in aceptoButtons) 
            {
                tapRadiobuttonSINOAcepto(radiobutton, position);
                position++;
            }
        }

        public void tapContinue() 
        {
            SwipeAction.swipeDownUntilElementExist(_driver, continueBtn);
            clickElement(continueBtn);
        }

        public INEPhotoPage allProcessPNLProcess() 
        {
            this.SetAllFieldsSINOACEPTO(PMLPage.aceptoField.SIACEPTO);
            this.tapACEPTOFields();
            this.tapContinue();
            return new INEPhotoPage(_driver);
        }

        public void assertContinueBtnDisable() 
        {
            Assert.IsTrue(!validateElementEnable(continueBtn), "Error, CONTINUE button is enabled and all 'SI ACEPTO' aren't selected.");
        }

        public void assertContinueBtnEnable() 
        {
            Assert.IsTrue(validateElementEnable(continueBtn), "Error, CONTINUE button is disable and all 'SI ACEPTO' are selected.");
        }

        public void assertPMLText() 
        {
            assertElementWithTextExist(
                    "Te queremos conocer mejor, por favor responde las preguntas para poder hacerlo:");
            assertElementWithTextExist(
                    "Declaro bajo protesta de decir la verdad que no desempeño actualmente ni durante el año inmediato anterior algún cargo público destacado a nivel federal, estatal, municipal o distrito en México o en el extranjero.");
            assertElementWithTextExist(
                    "Declaro también que mi cónyuge, en su caso, o pariente por consanguinidad o afinidad hasta el 2º grado, no desempeña actualmente ni durante el año inmediato anterior ningún cargo público destacado a nivel federal, estatal, municipal o distrital en México o en el extranjero.");
            assertElementWithTextExist(
                    "Declaro que ningún tercero obtendrá los beneficios derivados de las operaciones realizadas con KUALI SERVICIOS INTEGRALES DE EMPRENDIMIENTO SAPI DE C.V SOFOM E.N.R. ni ejercerá los derechos de uso, aprovechamiento o disposición de los recursos operados, siendo el verdadero propietario de los mismos. (Propietario real)");
            assertElementWithTextExist(
                    "Declaro que ningún tercero aportará regularmente recursos para el cumplimiento de las obligaciones derivadas del contrato que se establece con KUALI SERVICIOS INTEGRALES DE EMPRENDIMIENTO SAPI DE C.V SOFOM E.N.R. sin ser el titular de dicho contrato ni obtener los beneficios económicos derivados del mismo.");
            assertElementWithTextExist(
                    "Declaro que bajo protesta de decir verdad que para efectos de la realización de las operaciones con KUALI SERVICIOS INTEGRALES DE EMPRENDIMIENTO SAPI DE C.V SOFOM E.N.R. estoy actuando por cuenta propia.");
            assertElementWithTextExist(
                    "Declaro que los recursos que utilizaré para el pago de este producto provienen de una fuente licita.");

            Assert.IsTrue(SwipeAction.swipeDownUntilElementExist(_driver, continueBtn), "Error, CONTINUE button doesn't exist");
        }

        public void tapRadiobuttonSINOAcepto(aceptoField aceptoFieldradiobutton, int radPosition) 
        {
            if (aceptoFieldradiobutton != aceptoField.UNINFORMED) 
            {
                By tapField;

                if (aceptoFieldradiobutton == aceptoField.SIACEPTO) 
                {
                    tapField = By.Id("com.karum.credits:id/rb_yes_" + radPosition);
                    SwipeAction.swipeDownUntilElementExist(_driver, tapField);
                    clickElement(tapField);
                }
                else if (aceptoFieldradiobutton == aceptoField.NOACEPTO) 
                {
                    tapField = By.Id("com.karum.credits:id/rb_no_" + radPosition);
                    SwipeAction.swipeDownUntilElementExist(_driver, tapField);
                    clickElement(tapField);
                }
            }
        }
    }
}