namespace pages
{
    using data;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using utility;

    public partial class PuntosLealtadPage : BasePage
    {
        //By
        public By canjearBtn = By.Id("com.karum.credits:id/tv_item_1");
        public By beneficiosBtn = By.Id("com.karum.credits:id/tv_item_2");
        public By pointsValue = By.Id("com.karum.credits:id/tv_available_points");

        public override void SetIOSBy()
        {
            base.SetIOSBy();

            canjearBtn = By.XPath("//*[@label='Canjear']");
            beneficiosBtn = By.XPath("//*[@label='Beneficios']");
            pointsValue = By.XPath("//XCUIElementTypeOther[3]/XCUIElementTypeStaticText[2]");
        }
    }
}