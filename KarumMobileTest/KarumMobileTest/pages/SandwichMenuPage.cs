using data;
using NUnit.Framework;
using OpenQA.Selenium;
using utility;

namespace pages
{
    public class SandwichMenuPage : BasePage
    {
        //By
        public By closeBtn = By.Id("com.karum.credits:id/iv_close_menu");
        public By userNameDisplay = By.Id("com.karum.credits:id/tv_name_menu");
        public By cerrarSesionBtn = By.Id("com.karum.credits:id/menuLogout");

        //Contructor
        public SandwichMenuPage(Driver driver) : base(driver)
        {}

        public void verifytextElements(Client clientData) 
        {
            _driver.Report.StepDescription("Verify if all elements from Sandwich area are on screen");

            Assert.IsTrue(validateElementVisible(closeBtn), "Error, close button is not visible");
            assertElementText(userNameDisplay, clientData.firstNameOne + " " + clientData.lastNameOne);
            Assert.IsTrue(validateElementVisible(cerrarSesionBtn), "Error, 'Cerrar Sesión' button is not visible");

            _driver.Report.EndStep();
        }

        public void tapCloseBtn() 
        {
            _driver.Report.StepDescription("Tap close button");
            clickElement(closeBtn);
            _driver.Report.EndStep();
        }

        public void tapCerrarSesionBtn() 
        {
            _driver.Report.StepDescription("Tap CERRAR SESION button");
            clickElement(cerrarSesionBtn);
            _driver.Report.EndStep();
        }
    }
}