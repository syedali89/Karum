namespace pages
{
    using data;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using System;
    using utility;

    public class ConsultaSaldoPage : BasePage
    {
        public By deadlinePayment = By.Id("com.karum.credits:id/tv_balance_deadline");
        public By currentPeriodAmount = By.Id("com.karum.credits:id/tv_balance_period");

        public By newChargesAmount = By.Id("com.karum.credits:id/tv_new_charges");         
        public By paymentsCreditsAmount = By.Id("com.karum.credits:id/tv_payments_credits");         
        public By monthlyAmount = By.Id("com.karum.credits:id/tv_monthly");
        public By availableCreditAmount = By.Id("com.karum.credits:id/tv_available_credit");
        public By overdueAmount = By.Id("com.karum.credits:id/tv_overdue_amount");
        public By totalAmount = By.Id("com.karum.credits:id/tv_total_amount");

        //Contructor
        public ConsultaSaldoPage(Driver driver) : base(driver) 
        {}

        public void verifyPageElements(Client clientData)
        {
            string lastPhone = clientData.PhoneNumber.Substring(clientData.PhoneNumber.Length - 4);

            assertElementText(headerTitle, "Saldo");
            Assert.IsTrue(validateElementVisible(backButton), "Error, goBack button is not visible");

            assertElementWithTextExist("Cr�dito Karum");
            assertElementText(clientNumber, "************" + lastPhone);

            assertElementWithTextExist("Fecha l�mite de pago");
            assertElementWithTextExist("Periodo");
            assertElementWithTextExist("Fecha de corte");

            ///TODO deadline pay time values
            ///

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
            assertElementWithTextExist("Pago para no generar intereses + mensualidades vencidas");
            assertElementText(totalAmount, clientData.totalAmount);

            assertElementWithTextExist("Realiza los siguientes pasos para pagar en alguno de nuestros centros afiliados");
            assertElementWithTextExist("Paso 1 Ubica tu n�mero de referencia(Puedes encontrarlo en tu estado de cuenta o llamando al 800 286 2726)");
            assertElementWithTextExist("Paso 2 Busca tu centro de pago m�s cercano y lleva contigo tu n�mero de referencia");
            assertElementWithTextExist("Ponemos a tu disposici�n m�s de 30,000 centros de pago o tambi�n puedes pagar en la misma tienda donde realizaste tus compras");
            assertElementWithTextExist("Ponemos a tu disposici�n m�s de 30,000 centros de pago o tambi�n puedes pagar en la misma tienda donde realizaste tus compras");
            assertElementWithTextExist("Paso 3 Realiza tu pago en efectivo con tu n�mero de referencia y mencionando el pago mediante Paynet");
            assertElementWithTextExist("Tu pago quedar� registrado en l�nea autom�ticamente, guarda tu comprobante de pago para cualquier aclaraci�n al n�mero 800 286 2726");
        }
    }
}