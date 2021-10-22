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

            assertElementWithTextExist("Crédito Karum");
            assertElementText(clientNumber, "************" + lastPhone);

            assertElementWithTextExist("Fecha límite de pago");
            assertElementWithTextExist("Periodo");
            assertElementWithTextExist("Fecha de corte");

            ///TODO deadline pay time values
            ///

            assertElementWithTextExist("Nuevos Cargos");
            assertElementText(newChargesAmount, clientData.newChargesAmount);

            assertElementWithTextExist("Pagos y créditos");
            assertElementText(paymentsCreditsAmount, clientData.paymentCreditAmount);

            assertElementWithTextExist("Mensualidad");
            assertElementText(monthlyAmount, clientData.monthlyAmount);

            assertElementWithTextExist("Crédito Disponible");
            assertElementText(availableCreditAmount, clientData.availableCreditAmount);

            assertElementWithTextExist("Mensualidad vencida");
            assertElementText(overdueAmount, clientData.overdueAmount);

            assertElementWithTextExist("Pago total requerido");
            assertElementWithTextExist("Pago para no generar intereses + mensualidades vencidas");
            assertElementText(totalAmount, clientData.totalAmount);

            assertElementWithTextExist("Realiza los siguientes pasos para pagar en alguno de nuestros centros afiliados");
            assertElementWithTextExist("Paso 1 Ubica tu número de referencia(Puedes encontrarlo en tu estado de cuenta o llamando al 800 286 2726)");
            assertElementWithTextExist("Paso 2 Busca tu centro de pago más cercano y lleva contigo tu número de referencia");
            assertElementWithTextExist("Ponemos a tu disposición más de 30,000 centros de pago o también puedes pagar en la misma tienda donde realizaste tus compras");
            assertElementWithTextExist("Ponemos a tu disposición más de 30,000 centros de pago o también puedes pagar en la misma tienda donde realizaste tus compras");
            assertElementWithTextExist("Paso 3 Realiza tu pago en efectivo con tu número de referencia y mencionando el pago mediante Paynet");
            assertElementWithTextExist("Tu pago quedará registrado en línea automáticamente, guarda tu comprobante de pago para cualquier aclaración al número 800 286 2726");
        }
    }
}