namespace pages
{
    using data;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using System;
    using System.Globalization;
    using utility;

    public partial class ConsultaSaldoPage : BasePage
    {
        //Contructor
        public ConsultaSaldoPage(Driver driver) : base(driver) 
        {}

        public void verifyPageElements(Client clientData)
        {
            _driver.Report.StepDescription("Verify if all elements from Consulta Saldo Page are on screen");

            assertElementText(headerTitle, "Saldo");
            Assert.IsTrue(validateElementVisible(backButton), "Error, goBack button is not visible");

            verifyCreditoKarumNumber(clientData);

            assertElementWithTextExist("Fecha l�mite de pago");
            assertElementWithTextExist("Periodo");
            assertElementWithTextExist("Fecha de corte");

            var todayDate = DateTime.Now;

            string currentPeriodTimeText = getTextElement(currentPeriodMonth).ToUpper();
            string currentPeriotDate = todayDate.ToString("MMMM", new CultureInfo("es-ES")).ToUpper();

            string payLimitDate;
            string cutoffDate;

            if (currentPeriodTimeText.Contains(currentPeriotDate))
            {
                payLimitDate = todayDate.AddMonths(1).ToString("MM/yy");
                currentPeriotDate = todayDate.ToString("MMMM yyyy", new CultureInfo("es-ES")).ToUpper();
                cutoffDate = todayDate.ToString("MM/yy");
            }
            else
            {
                payLimitDate = todayDate.AddMonths(2).ToString("MM/yy");
                currentPeriotDate = todayDate.AddMonths(1).ToString("MMMM yyyy", new CultureInfo("es-ES")).ToUpper();
                cutoffDate = todayDate.AddMonths(1).ToString("MM/yy");
            }

            assertTextContains(deadlinePayment, payLimitDate);            
            assertTextContains(currentPeriodTimeText, currentPeriotDate);
            assertTextContains(cutOffCreditDate, cutoffDate);

            assertElementWithTextExist("Nuevos Cargos");
            assertElementText(newChargesAmount, clientData.newChargesAmount);

            assertElementWithTextExist("Pagos y cr�ditos");
            assertElementText(paymentsCreditsAmount, clientData.paymentCreditAmount);

            assertElementWithTextExist("Mensualidad");
            assertElementText(monthlyAmount, clientData.monthlyAmount);

            assertElementWithTextExist("Cr�dito Disponible");
            assertElementText(availableCreditAmount, clientData.availableCreditAmount);

            assertElementWithTextExist("Mensualidad vencida");
            assertElementText(overdueAmount, clientData.overdueAmount);

            assertElementWithTextExist("Pago total requerido");

            string pagototalDescriptionText = getTextElement(pagototalDescription);
            assertTextContains(pagototalDescriptionText, "Pago para no generar intereses");
            assertTextContains(pagototalDescriptionText, "+ mensualidades vencidas");
            assertElementText(totalAmount, clientData.totalAmount);

            string indicationForPaymentsDescriptionText = getTextElement(indicationForPaymentsDescription);
            assertTextContains(indicationForPaymentsDescriptionText, "Realiza los siguientes pasos para pagar en alguno");
            
            assertTextContains(indicationForPaymentsDescriptionText, "nuestros centros afiliados");

            SwipeAction.swipeDownUntilElementExist(_driver, secontDescription);

            string stepOneDescriptionText = getTextElement(stepOneDescription);
            assertTextContains(stepOneDescriptionText, "Paso 1");            
            assertTextContains(stepOneDescriptionText, "Ubica tu n�mero de referencia (Puedes encontrarlo en tu estado de cuenta o llamando al 800 286 2726)");

            string stepTwoDescriptionText = getTextElement(stepTwoDescription);
            assertTextContains(stepTwoDescriptionText, "Paso 2");
            assertTextContains(stepTwoDescriptionText, "Busca tu centro de pago m�s cercano y lleva contigo tu n�mero de referencia");

            string description1 = getTextElement(firstDescription);
            assertTextContains(description1, "Ponemos a tu disposici�n m�s de 30,000 centros");
            assertTextContains(description1, "de pago o tambi�n puedes pagar en la misma tienda");
            assertTextContains(description1, "donde realizaste tus compras");

            string stepThreeDescriptionText = getTextElement(stepThreeDescription);
            assertTextContains(stepThreeDescriptionText, "Paso 3");
            assertTextContains(stepThreeDescriptionText, "Realiza tu pago en efectivo con tu n�mero de referencia y mencionando el pago mediante Paynet");

            assertElementWithTextExist("Tu pago quedar� registrado en l�nea autom�ticamente, guarda tu comprobante de pago para cualquier aclaraci�n al n�mero 800 286 2726");

            _driver.Report.EndStep();
        }
    }
}