namespace pages
{
    using data;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using utility;
    using static constants;

    public partial class MisMovimientosPage : BasePage
    {
        //Contructor
        public MisMovimientosPage(Driver driver) : base(driver) 
        {
        }

        public Movimiento tapMovimiento()
        {
            _driver.Report.StepDescription("Tap First Movimiento");

            assertElementWithTextExist("Mis movimientos");
            var firstMovbimiento = _driver.GetIntance().FindElements(allMovewmentsItems)[0];

            Movimiento movimiento = new Movimiento(
               firstMovbimiento.FindElement(transactionNumber).Text, firstMovbimiento.FindElement(transactionType).Text, firstMovbimiento.FindElement(amountItem).Text);

            firstMovbimiento.Click();
            _driver.Report.EndStep();

            return movimiento;
        }

        public void tapSolicitarAclaracion()
        {
            _driver.Report.StepDescription("Tap Solicitar Aclaracion");
            clickElement(requestInfoLinktext);
            _driver.Report.EndStep();
        }

        public void tapOutsideMovement()
        {
            _driver.Report.StepDescription("Tap Outside Movimiento");
            clickElement(closeMovementDetail);
            _driver.Report.EndStep();
        }

        public void verifySolicitarAclaracionText(Client client)
        {
            _driver.Report.StepDescription("Verify Solicitar Aclaracion message is on screen");

            if (_driver.GetDevice().Equals(OS.ANDROID))
            {
                assertElementWithTextExist("Solicitud de aclaración enviada");
                assertElementWithTextExist("Te hemos enviado la información sobre la solicitud de aclaración de cargo no reconocido a tu correo " + client.userEmail);
            }
            else if (_driver.GetDevice().Equals(OS.IOS))
            {
                assertTextContains(By.XPath("//*[contains(@label, 'Solicitud de')]") ,"Solicitud de");                
                assertTextContains(By.XPath("//*[contains(@label, 'Solicitud de')]") ,"aclaración enviada");

                assertTextContains(By.XPath("//*[contains(@label, 'Te hemos enviado la')]"),  "Te hemos enviado la información sobre la");
                assertTextContains(By.XPath("//*[contains(@label, 'Te hemos enviado la')]"),  "solicitud de aclaración de cargo no reconocido a");
                assertTextContains(By.XPath("//*[contains(@label, 'Te hemos enviado la')]"),  "tu correo " + client.userEmail);
            }

            _driver.Report.EndStep();
        }

        public void verifySelectedMovementText(Movimiento movimiento)
        {
            _driver.Report.StepDescription("Verify text from movimiento selected");

            assertElementText(movementDetail, movimiento.transactionType);
            assertElementText(amountDetail, movimiento.moneyAmount);
            assertElementText(requestInfoLinktext, "Solicitar aclaración del cargo");

            _driver.Report.EndStep();
        }

        public void verifyMisMovimientoPageOnScreen()
        {
            _driver.Report.StepDescription("Verify if Mis movmientos Page is on screen");
            assertElementText(headerTitle, "Mis movimientos");
            _driver.Report.EndStep();
        }

        public void verifyPageElements(Client clientData)
        {
            _driver.Report.StepDescription("Verify if all elements from Mis movimientos are on screen");

            List<Movimiento> movimientosScreen = new List<Movimiento>();

            assertElementText(headerTitle, "Mis movimientos");
            Assert.IsTrue(validateElementVisible(backButton), "Error, goBack button is not visible");
            assertElementWithTextExist("Para mayor detalle de movimientos, favor de llamar al Credit Center al número 5570903047 opción 4");
                        
            foreach (var element in _driver.GetIntance().FindElements(allMovewmentsItems))
            {
                movimientosScreen.Add(
                    new Movimiento(element.FindElement(transactionNumber).Text, element.FindElement(transactionType).Text, element.FindElement(amountItem).Text));
            }

            if (_driver.GetDevice().Equals(OS.ANDROID))
            {
                SwipeAction.swipeDownUntilElementText(_driver, clientData.clientMovimientos[clientData.clientMovimientos.Count - 1].moneyAmount);

                foreach (var element in _driver.GetIntance().FindElements(allMovewmentsItems))
                {
                    movimientosScreen.Add(
                        new Movimiento(element.FindElement(transactionNumber).Text, element.FindElement(transactionType).Text, element.FindElement(amountItem).Text));
                }
            }

            Assert.IsTrue(movimientosScreen.Count > 0, "Error, there are no Movimientos on Screen");

            foreach (var movimientoScreen in movimientosScreen)
            {
                bool match = false;

                foreach (var movimientoClient in clientData.clientMovimientos)
                {
                    match = movimientoScreen.equalMovements(movimientoClient);

                    if (match)
                    {
                        break;
                    }
                }
                
                Assert.IsTrue(match,
                        "Error, Movimiento \n" +
                        "Transaction: " + movimientoScreen.transactionNumber +
                        "\nCredit" + movimientoScreen.transactionType +
                        "\nAmount: " + movimientoScreen.moneyAmount +
                        "\nIs not a 'Movimiento' expected for this client"
                        );                
            }

            _driver.Report.EndStep();
        }
    }
}