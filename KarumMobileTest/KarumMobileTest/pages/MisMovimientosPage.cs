using OpenQA.Selenium;
using utility;

namespace pages
{
    public class MisMovimientosPage : BasePage
    {
        //By
        public By pagarTiendaBtn = By.Id("com.karum.credits:id/tv_purchases_main");

        //Contructor
        public MisMovimientosPage(Driver driver) : base(driver) 
        {}
    }
}