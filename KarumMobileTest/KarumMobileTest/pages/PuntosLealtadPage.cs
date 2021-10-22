using OpenQA.Selenium;
using utility;

namespace pages
{
    public class PuntosLealtadPage : BasePage
    {
        //By
        public By canjearBtn = By.Id("com.karum.credits:id/tv_item_1");
        public By beneficiosBtn = By.Id("com.karum.credits:id/tv_item_2");


        //Contructor
        public PuntosLealtadPage(Driver driver) : base(driver)
        {}
    }
}