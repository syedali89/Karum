using OpenQA.Selenium;
using utility;

namespace pages
{
    public class PuntosLealtadPage : BasePage
    {
        //By
        public By pagarTiendaBtn = By.Id("com.karum.credits:id/tv_purchases_main");


        //Contructor
        public PuntosLealtadPage(Driver driver) : base(driver)
        {}
    }
}