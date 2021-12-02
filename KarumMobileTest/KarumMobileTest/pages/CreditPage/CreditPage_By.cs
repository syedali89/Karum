namespace pages
{
    using OpenQA.Selenium;

    public partial class CreditPage : BasePage
    {
        //By button 
        public By comprarTiendaBtn = By.Id("com.karum.credits:id/tv_store_purchases");
        public By misMovimientosBtn = By.Id("com.karum.credits:id/tv_movements");
        public By estadoCuentaBtn = By.Id("com.karum.credits:id/tv_account_status");
        public By misPuntosBtn = By.Id("com.karum.credits:id/tv_my_points");
        //By Sandwich Area
        public By sandwichBtn = By.Id("com.karum.credits:id/iv_home_menu_header");
        //By CreditoKarum
        public By numberClient = By.Id("com.karum.credits:id/tv_credit_card_main");
        public By totalamountClient = By.Id("com.karum.credits:id/tv_credit_balance_main");
        //By Other
        public By creditLimitAmount = By.Id("com.karum.credits:id/tv_credit_limit");
        public By paymentAmount = By.Id("com.karum.credits:id/tv_payment_amount");
        public By nextPaymentDate = By.Id("com.karum.credits:id/tv_next_payment_date");
        //By cartField
        public By RequestCardBtn = By.Id("com.karum.credits:id/btn_request");

        public override void SetIOSBy()
        {
            base.SetIOSBy();

            comprarTiendaBtn = By.XPath("//*[@label='Comprar en tienda']");
            misPuntosBtn = By.XPath("//XCUIElementTypeButton[contains(@label, 'Mis puntos ')]");
            misMovimientosBtn = By.XPath("//*[@label='Mis movimientos']/../XCUIElementTypeButton");
            estadoCuentaBtn = By.XPath("//*[@label='Estados de cuenta']/../XCUIElementTypeButton");
            
            sandwichBtn = By.XPath("//*[@label='ic home menu']");
            
            numberClient = By.XPath("//*[contains(@label,'**********')]");
            totalamountClient = By.XPath("//XCUIElementTypeOther[1]/XCUIElementTypeStaticText[3]");
            
            creditLimitAmount = By.XPath("//XCUIElementTypeStaticText[5]");
            paymentAmount = By.XPath("//XCUIElementTypeOther[3]/*[contains(@label, '$')]");
            nextPaymentDate = By.XPath("//XCUIElementTypeOther[3]/*[contains(@label, '/')]");

            RequestCardBtn = By.XPath("//*[@label='SOLICITAR']");
        }
    }
}