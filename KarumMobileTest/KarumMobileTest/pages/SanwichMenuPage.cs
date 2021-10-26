using data;
using NUnit.Framework;
using OpenQA.Selenium;
using utility;

namespace pages
{
    public class SanwichMenuPage : BasePage
    {
        //By
        public By closeBtn = By.Id("com.karum.credits:id/iv_close_menu");
        public By userNameDisplay = By.Id("com.karum.credits:id/tv_name_menu");
        public By cerrarSesionBtn = By.Id("com.karum.credits:id/menuLogout");

        //Contructor
        public SanwichMenuPage(Driver driver) : base(driver)
        {}

        public void verifytextElements(Client clientData) 
        {
            Assert.IsTrue(validateElementVisible(closeBtn), "Error, close button is not visible");
            assertElementText(userNameDisplay, clientData.firstNameOne + " " + clientData.lastNameOne);
            Assert.IsTrue(validateElementVisible(cerrarSesionBtn), "Error, 'Cerrar Sesión' button is not visible");
        }

        public void tapCloseBtn() 
        {
            clickElement(closeBtn);
        }

        public void tapCerrarSesionBtn() 
        {
            clickElement(cerrarSesionBtn);
        }
    }
}