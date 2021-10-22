namespace pages
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using utility;
    using data;
    using System.Collections.Generic;

    public class MisMovimientosPage : BasePage
    {
        //By
        public By allMovewmentsItems = By.XPath("//*[@resource-id='com.karum.credits:id/rv_movements']/*");
        public By amountItem = By.XPath("//*[@resource-id='com.karum.credits:id/tv_amount_item']");
        public By transactionNumber = By.XPath("//*[@resource-id='com.karum.credits:id/tv_transaction_item']");
        public By transactionType = By.XPath("//*@resource-id='com.karum.credits:id/tv_credit_item']");
        //By Movement selected
        public By movementDetail = By.Id("com.karum.credits:id/tv_movement_detail");
        public By amountDetail = By.Id("com.karum.credits:id/tv_amount_detail");
        public By requestInfoLinktext = By.Id("com.karum.credits:id/tv_request_info");
        public By closeMovementDetail = By.Id("com.karum.credits:id/touch_outside");

        //Contructor
        public MisMovimientosPage(Driver driver) : base(driver) 
        {
        }

        public Movimiento tapMovimiento()
        {
            Movimiento movimiento = new Movimiento(
                _driver.GetIntance().FindElement(transactionNumber).Text, _driver.GetIntance().FindElement(transactionType).Text, _driver.GetIntance().FindElement(amountItem).Text);
            
            clickElement(amountItem);

            return movimiento;
        }

        public void tapSolicitarAclaracion()
        {
            clickElement(requestInfoLinktext);
        }

        public void tapOutsideMovement()
        {
            clickElement(closeMovementDetail);
        }

        public void verifySolicitarAclaracionText(Client client)
        {
            assertElementWithTextExist("Solicitud de aclaración enviada");
            assertElementWithTextExist("Te hemos enviado la información sobre la solicitud de aclaración de cargo no reconocido a tu correo " + client.userEmail);
        }

        public void verifySelectedMovementText(Movimiento movimiento)
        {
            assertElementText(movementDetail, movimiento.transactionType);
            assertElementText(amountDetail, movimiento.moneyAmount);
            assertElementText(requestInfoLinktext, "Solicitar aclaración del cargo");
        }

        public void verifyMisMovimientoPageOnScreen()
        {
            assertElementText(headerTitle, "Mis movimientos");
        }

        public void verifyPageElements(Client clientData)
        {
            List<Movimiento> movimientosScreen = new List<Movimiento>();

            assertElementText(headerTitle, "Mis movimientos");
            Assert.IsTrue(validateElementVisible(backButton), "Error, goBack button is not visible");
            assertElementWithTextExist("Para mayor detalle de movimientos, favor de llamar al Credit Center al número 5570903047 opción 4");

            foreach (var element in _driver.GetIntance().FindElements(allMovewmentsItems))
            {
                movimientosScreen.Add(
                    new Movimiento(element.FindElement(transactionNumber).Text, element.FindElement(transactionType).Text, element.FindElement(amountItem).Text));
            }

            SwipeAction.swipeToDown(_driver);

            foreach (var element in _driver.GetIntance().FindElements(allMovewmentsItems))
            {
                movimientosScreen.Add(
                    new Movimiento(element.FindElement(transactionNumber).Text, element.FindElement(transactionType).Text, element.FindElement(amountItem).Text));
            }

            Assert.IsTrue(movimientosScreen.Count > 0, "Error, there are no Movimientos on Screen");

            foreach (var movimiento in movimientosScreen)
            {
                Assert.IsTrue(
                    clientData.clientMovimientos.Contains(movimiento),
                    "Error, Movimiento \n" +
                    "Transaction: " + movimiento.transactionNumber +
                    "Credit" + movimiento.transactionType +
                    "Amount: " + movimiento.moneyAmount +
                    "is not a 'Movimiento' expected for this client"
                    );
            }
        }
    }
}