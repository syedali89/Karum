using OpenQA.Selenium;
using utility;

namespace pages
{
    public class ConsultaSaldoPage : BasePage
    {
        //By
        public By pagarTiendaBtn = By.Id("com.karum.credits:id/tv_purchases_main");

        //Contructor
        public ConsultaSaldoPage(Driver driver) : base(driver) 
        {}
    }
}