namespace pages
{
    using OpenQA.Selenium;

    public partial class HomePage : BasePage
    {
        //By Home buttonS
        public By pagarTiendaBtn = By.Id("com.karum.credits:id/tv_purchases_main");
        public By misMovimientosBtn = By.Id("com.karum.credits:id/tv_movements_main");
        public By estadoCuentaBtn = By.Id("com.karum.credits:id/tv_account_status_main");
        public By puntosLealtadBtn = By.Id("com.karum.credits:id/tv_loyalty_main");
        public By consultaSaldoBtn = By.Id("com.karum.credits:id/tv_balance_consult_main");
        //By Sandwich Area
        public By sandwichBtn = By.Id("com.karum.credits:id/iv_home_menu_header");
        //By CreditoKarum
        public By numberClient = By.Id("com.karum.credits:id/tv_credit_card_main");
        public By totalamountClient = By.Id("com.karum.credits:id/tv_credit_balance_main");

        public override void SetIOSBy()
        {
            base.SetIOSBy();

            pagarTiendaBtn = By.XPath("//XCUIElementTypeCollectionView/XCUIElementTypeCell[1]");
            misMovimientosBtn = By.XPath("//XCUIElementTypeCollectionView/XCUIElementTypeCell[2]");
            estadoCuentaBtn = By.XPath("//XCUIElementTypeCollectionView/XCUIElementTypeCell[3]");
            puntosLealtadBtn = By.XPath("//XCUIElementTypeCollectionView/XCUIElementTypeCell[4]");
            consultaSaldoBtn = By.XPath("//*[@label='Consulta tu saldo']/../XCUIElementTypeButton");  
            sandwichBtn = By.XPath("//*[@label='ic home menu']");
            numberClient = By.XPath("//XCUIElementTypeStaticText[contains(@label, '**********')]");
            totalamountClient = By.XPath("//XCUIElementTypeOther/XCUIElementTypeStaticText[3]");
        }
    }
}