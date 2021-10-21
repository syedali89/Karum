using OpenQA.Selenium;
using utility;

namespace pages 
{
    public class PagarTiendaPage : BasePage
    {
        //By
        public By pagarTiendaBtn = By.Id("com.karum.credits:id/tv_purchases_main");

        //Contructor
        public PagarTiendaPage(Driver driver) : base(driver)
        {}
    }
}