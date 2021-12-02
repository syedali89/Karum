namespace pages 
{
    using data;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using utility;

    public partial class PagarTiendaPage : BasePage
    {
        public By codigoQRbutton = By.Id("com.karum.credits:id/tv_item_1");
        public By codigoBarrasbutton = By.Id("com.karum.credits:id/tv_item_2");
        public By QRcodeDisplay = By.Id("com.karum.credits:id/iv_qr_purchases");
        public By bardcodeDisplay = By.Id("com.karum.credits:id/iv_barcode_purchases");

        public override void SetIOSBy()
        {
            base.SetIOSBy();

            codigoQRbutton = By.XPath("//*[@label='Código QR']");
            codigoBarrasbutton = By.XPath("//*[@label='Código de barras']");
            QRcodeDisplay = By.XPath("//XCUIElementTypeOther[1]/XCUIElementTypeOther[1]/XCUIElementTypeOther[1]/XCUIElementTypeScrollView[1]/XCUIElementTypeOther[1]/XCUIElementTypeOther[last()]");
            bardcodeDisplay = By.XPath("//XCUIElementTypeOther[4]/XCUIElementTypeImage[1]/..");
        }
    }
}