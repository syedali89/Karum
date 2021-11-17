namespace pages
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using utility;
    using data;
    using System.Collections.Generic;

    public partial class MisMovimientosPage : BasePage
    {
        //By
        public By allMovewmentsItems = By.XPath("//*[@resource-id='com.karum.credits:id/rv_movements']/*");
        public By amountItem = By.XPath("//*[@resource-id='com.karum.credits:id/tv_amount_item']");
        public By transactionNumber = By.XPath("//*[@resource-id='com.karum.credits:id/tv_transaction_item']");
        public By transactionType = By.XPath("//*[@resource-id='com.karum.credits:id/tv_credit_item']");
        //By Movement selected
        public By movementDetail = By.Id("com.karum.credits:id/tv_movement_detail");
        public By amountDetail = By.Id("com.karum.credits:id/tv_amount_detail");
        public By requestInfoLinktext = By.Id("com.karum.credits:id/tv_request_info");
        public By closeMovementDetail = By.Id("com.karum.credits:id/touch_outside");

        public override void SetIOSBy()
        {
            base.SetIOSBy();

            allMovewmentsItems = By.XPath("//XCUIElementTypeTable/XCUIElementTypeCell");
            amountItem = By.XPath("//XCUIElementTypeStaticText[contains(@label, '$')]");
            transactionNumber = By.XPath("//XCUIElementTypeStaticText[not(@label='')][1]");
            transactionType = By.XPath("//XCUIElementTypeStaticText[not(@label='')][2]");

            movementDetail = By.XPath("//XCUIElementTypeOther[3]/XCUIElementTypeOther[1]/XCUIElementTypeOther[1]/XCUIElementTypeStaticText[1]");
            amountDetail = By.XPath("//XCUIElementTypeOther[3]/XCUIElementTypeOther[1]/XCUIElementTypeOther[1]/XCUIElementTypeStaticText[2]");
            requestInfoLinktext = By.XPath("//*[@label='Solicitar aclaración del cargo']");

            closeMovementDetail = By.XPath("//*[@label='Karum UAT']/XCUIElementTypeWindow[1]/XCUIElementTypeOther[2]/XCUIElementTypeOther[1]/XCUIElementTypeOther[2]");
        }
    }
}