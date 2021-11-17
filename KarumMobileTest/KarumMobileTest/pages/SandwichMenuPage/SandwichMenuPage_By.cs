using data;
using NUnit.Framework;
using OpenQA.Selenium;
using utility;

namespace pages
{
    public partial class SandwichMenuPage : BasePage
    {
        //By
        public By closeBtn = By.Id("com.karum.credits:id/iv_close_menu");
        public By userNameDisplay = By.Id("com.karum.credits:id/tv_name_menu");
        public By cerrarSesionBtn = By.Id("com.karum.credits:id/menuLogout");

        public override void SetIOSBy()
        {
            base.SetIOSBy();

            closeBtn = By.XPath("//*[@label='ic close']");
            userNameDisplay = By.XPath("//*[@label='ic close']/../XCUIElementTypeStaticText[2]");
            cerrarSesionBtn = By.XPath("//*[@label='Cerrar Sesión']");
        }
    }
}