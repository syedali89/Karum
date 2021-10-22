namespace pages
{
    using data;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using utility;

    public class ConsultaSaldoPage : BasePage
    {              
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

            ///TODO App is not working properly for this specific

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