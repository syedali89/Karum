using data;
using NUnit.Framework;
using OpenQA.Selenium;
using utility;

namespace pages
{
    public class SanwichMenuPage : BasePage
    {
        //By
        public By closeBtn = By.Id("close");
        public By userNameDisplay = By.Id("username");
        public By cerrarSesionBtn = By.Id("cerrarsesion");

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