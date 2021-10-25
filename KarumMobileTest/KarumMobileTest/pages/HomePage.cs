using data;
using NUnit.Framework;
using OpenQA.Selenium;
using utility;

namespace pages
{
    public class HomePage : BasePage{

        //By Home buttons
        public By pagarTiendaBtn = By.Id("com.karum.credits:id/tv_purchases_main");
        public By misMovimientosBtn = By.Id("com.karum.credits:id/tv_movements_main");
        public By estadoCuentaBtn = By.Id("com.karum.credits:id/tv_account_status_main");
        public By puntosLealtadBtn = By.Id("com.karum.credits:id/tv_loyalty_main");
        public By consultaSaldoBtn = By.Id("com.karum.credits:id/tv_balance_consult_main");
        //By Sandwich Area
        public By sandwichBtn = By.Id("com.karum.credits:id/iv_home_menu_header");
        public By greetingsClient = By.Id("com.karum.credits:id/tv_title_header");
        //By CreditoKarum
        public By numberClient = By.Id("com.karum.credits:id/tv_credit_card_main");
        public By totalamountClient = By.Id("com.karum.credits:id/tv_credit_balance_main");


        //Contructor
        public HomePage(Driver driver) : base(driver)
        {}

        public void verifyHomePageElements(Client clientData) 
        {
            verifyHomePageOnScreen(clientData);

            assertElementWithTextExist("Crédito Karum");
            assertElementText(numberClient, "************" + clientData.getLastCreditNumber());

            assertElementText(totalamountClient, clientData.accountAmount);
            Assert.IsTrue(validateElementVisible(consultaSaldoBtn),
                    "Error,  'Consulta de saldo' button is not visible");
            Assert.IsTrue(validateElementVisible(pagarTiendaBtn),
                    "Error,  'Pagar en Tienda' button is not visible");
            Assert.IsTrue(validateElementVisible(misMovimientosBtn),
                    "Error,  'Mis mivimientos' button is not visible");
            Assert.IsTrue(validateElementVisible(estadoCuentaBtn),
                    "Error,  'Estado de cuenta' button is not visible");
            Assert.IsTrue(validateElementVisible(puntosLealtadBtn),
                    "Error,  'Puntos de lealtad' button is not visible");
        }

        public void verifyHomePageOnScreen(Client clientData) 
        {           
            assertElementText(headerTitle, "Hola, " + clientData.firstNameOne + " " + clientData.lastNameOne);
        }

        public ConsultaSaldoPage tapSaldoCuenta() 
        {
            clickElement(consultaSaldoBtn);
            return new ConsultaSaldoPage(_driver);
        }

        public PagarTiendaPage tapPagarTiendaBtn() 
        {
            clickElement(pagarTiendaBtn);
            return new PagarTiendaPage(_driver);
        }

        public MisMovimientosPage tapMisMovimientosBtnBtn() 
        {
            clickElement(misMovimientosBtn);
            return new MisMovimientosPage(_driver);
        }

        public PuntosLealtadPage tapPuntosLealtadBtn() 
        {
            clickElement(puntosLealtadBtn);
            return new PuntosLealtadPage(_driver);
        }

        public SanwichMenuPage tapSandwichBtn() 
        {
            clickElement(sandwichBtn);
            return new SanwichMenuPage(_driver);
        }

        public void verifySaldoCuentaOnScreen() 
        {
            assertElementText(headerTitle, "Saldo");
        }

        public void verifyPagarTiendaOnScreen() 
        {
            assertElementText(headerTitle, "Pagar en tienda");
        }

        public void verifyMisMovimientosPageOnScreen() 
        {
            assertElementText(headerTitle, "Mis movimientos");
        }

        public void verifyPuntosLealtadPageOnScreen() 
        {
            assertElementText(headerTitle, "Puntos de lealtad");
        }
    }
}