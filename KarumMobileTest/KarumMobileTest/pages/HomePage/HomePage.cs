namespace pages
{
    using data;
    using NUnit.Framework;
    using utility;
    using static constants;

    public partial class HomePage : BasePage
    {
        //Contructor
        public HomePage(Driver driver) : base(driver)
        {}

        public void verifyHomePageElements(Client clientData) 
        {
            _driver.Report.StepDescription("Verify if all elements from Home Page are on Screen");

            verifyHomePageOnScreen(clientData);

            assertElementWithTextExist("Crédito Karum");
            assertElementText(numberClient, "************" + clientData.getLastCreditNumber());

            assertElementText(totalamountClient, clientData.accountAmount);
            Assert.IsTrue(validateElementVisible(consultaSaldoBtn),
                    "Error, 'Consulta de saldo' button is not visible");
            Assert.IsTrue(validateElementVisible(pagarTiendaBtn),
                    "Error, 'Pagar en Tienda' button is not visible");
            Assert.IsTrue(validateElementVisible(misMovimientosBtn),
                    "Error, 'Mis mivimientos' button is not visible");
            Assert.IsTrue(validateElementVisible(estadoCuentaBtn),
                    "Error, 'Estado de cuenta' button is not visible");
            Assert.IsTrue(validateElementVisible(puntosLealtadBtn),
                    "Error, 'Puntos de lealtad' button is not visible");

            verifyButtonMenuScreen(DownMenuSelected.HOME);

            _driver.Report.EndStep();
        }

        public void verifyHomePageOnScreen(Client clientData) 
        {
            _driver.Report.StepDescription("Verify if Home Page is on Screen");

            assertElementText(headerTitle, "Hola, " + clientData.firstNameOne + " " + clientData.lastNameOne);

            _driver.Report.EndStep();
        }

        public ConsultaSaldoPage tapSaldoCuenta() 
        {
            _driver.Report.StepDescription("Tap Consulta de Saldo button");
            clickElement(consultaSaldoBtn);
            _driver.Report.EndStep();

            return new ConsultaSaldoPage(_driver);
        }

        public PagarTiendaPage tapPagarTiendaBtn() 
        {
            _driver.Report.StepDescription("Tap Pagar en tienda button");
            clickElement(pagarTiendaBtn);
            _driver.Report.EndStep();

            return new PagarTiendaPage(_driver);
        }

        public MisMovimientosPage tapMisMovimientosBtnBtn() 
        {
            _driver.Report.StepDescription("Tap Mis movimientos button");
            clickElement(misMovimientosBtn);
            _driver.Report.EndStep();

            return new MisMovimientosPage(_driver);
        }

        public PuntosLealtadPage tapPuntosLealtadBtn() 
        {
            _driver.Report.StepDescription("Tap Puntos de Lealtad button");
            clickElement(puntosLealtadBtn);
            _driver.Report.EndStep();

            return new PuntosLealtadPage(_driver);
        }

        public SandwichMenuPage tapSandwichBtn() 
        {
            _driver.Report.StepDescription("Tap Sandwich button");
            clickElement(sandwichBtn);
            _driver.Report.EndStep();

            return new SandwichMenuPage(_driver);
        }

        public EstadoCuentaPage tapEstadoCuentaBtn() 
        {
            _driver.Report.StepDescription("Tap Estado de Cuenta button");
            clickElement(estadoCuentaBtn);
            _driver.Report.EndStep();

            return new EstadoCuentaPage(_driver);
        }

        public void verifySaldoCuentaOnScreen() 
        {
            _driver.Report.StepDescription("Verify if Saldo de Cuenta Page is on Screen");
            assertElementText(headerTitle, "Saldo");
            _driver.Report.EndStep();
        }

        public void verifyPagarTiendaOnScreen() 
        {
            _driver.Report.StepDescription("Verify if Pagar en tienda Page is on Screen");
            assertElementText(headerTitle, "Pagar en tienda");
            _driver.Report.EndStep();
        }

        public void verifyMisMovimientosPageOnScreen() 
        {
            _driver.Report.StepDescription("Verify if Mis movimientos Page is on Screen");
            assertElementText(headerTitle, "Mis movimientos");
            _driver.Report.EndStep();
        }

        public void verifyPuntosLealtadPageOnScreen() 
        {
            _driver.Report.StepDescription("Verify if Puntos de lealtad Page is on Screen");
            assertElementText(headerTitle, "Puntos de lealtad");
            _driver.Report.EndStep();
        }

        public void verifyEstadoCuentaPageOnScreen() 
        {
            _driver.Report.StepDescription("Verify if Estado de cuenta Page is on Screen");
            assertElementText(headerTitle, "Estado de cuenta");
            _driver.Report.EndStep();
        }
    }
}