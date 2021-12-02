namespace pages
{
    using System;
    using data;
    using NUnit.Framework;
    using OpenQA.Selenium;    
    using utility;
    using static constants;

    public partial class CreditPage : BasePage
    {        
        //Contructor
        public CreditPage(Driver driver) : base(driver)
        {}

        public void verifyCreditPageElements(Client clientData) 
        {
            _driver.Report.StepDescription("Verify if all elements from Credito Page are on Screen");          
            verifyCreditPageOnScreen();

            assertElementWithTextExist("Crédito Karum");
            assertElementText(numberClient, "************" + clientData.getLastCreditNumber());

            assertElementText(totalamountClient, clientData.accountAmount);

            assertElementWithTextExist("Límite de crédito");
            assertElementText(creditLimitAmount, clientData.creditLimitAmount);
            assertElementText(paymentAmount, clientData.paymentAmount);

            string nextPaymentTextTwo = DateTime.Now.AddMonths(2).ToString("MM/yy");
            string nextPaymentTextOne = DateTime.Now.AddMonths(1).ToString("MM/yy");
            
            Assert.IsTrue(getTextElement(nextPaymentDate).Contains(nextPaymentTextTwo) || getTextElement(nextPaymentDate).Contains(nextPaymentTextOne), " Error next payment date is invalid");

            Assert.IsTrue(validateElementVisible(misMovimientosBtn),
                    "Error,  'Mis movimientos' button is not visible");
            Assert.IsTrue(validateElementVisible(estadoCuentaBtn),
                    "Error,  'Estado de cuenta' button is not visible");
            Assert.IsTrue(validateElementVisible(comprarTiendaBtn),
                    "Error,  'Comprar en tienda' button is not visible");
            Assert.IsTrue(validateElementVisible(misPuntosBtn),
                    "Error,  'Mis Puntos' button is not visible");

            assertTextContains(misPuntosBtn, "Mis puntos");
            assertTextContains(misPuntosBtn, clientData.totalLoyalPoints + " pts");

            assertElementWithTextExist("Solicitar tarjeta física");
            assertElementWithTextExist("Tramita tu tarjeta física y paga donde quieras y cuando quieras");

            assertElementText(RequestCardBtn, "SOLICITAR");

            verifyButtonMenuScreen(DownMenuSelected.CREDIT);
            _driver.Report.EndStep();
        }

        public void verifyCreditPageOnScreen() 
        {
            _driver.Report.StepDescription("Verify if Credito Page is on Screen");
            assertElementText(headerTitle, "Mis créditos");
            _driver.Report.EndStep();
        }

        public PagarTiendaPage tapComprarTiendaBtn() 
        {
            _driver.Report.StepDescription("Tap Comprar tienda button");
            clickElement(comprarTiendaBtn);
            _driver.Report.EndStep();

            return new PagarTiendaPage(_driver);       
        }

        public MisMovimientosPage tapMisMovimientosBtn() 
        {
            _driver.Report.StepDescription("Tap Mis movimientos button");
            clickElement(misMovimientosBtn);
            _driver.Report.EndStep();

            return new MisMovimientosPage(_driver);
        }

        public PuntosLealtadPage tapMisPuntosBtn() 
        {
            _driver.Report.StepDescription("Tap Mis Puntos button");
            clickElement(misPuntosBtn);
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