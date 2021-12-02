namespace pages
{
    using data;
    using NUnit.Framework;
    using utility;

    public partial class SandwichMenuPage : BasePage
    {        
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