namespace pages
{
    using data;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using System;
    using System.Globalization;
    using utility;

    public partial class ConsultaSaldoPage : BasePage
    {
        public By deadlinePayment = By.Id("com.karum.credits:id/tv_balance_deadline");
        public By currentPeriodMonth = By.Id("com.karum.credits:id/tv_balance_period");
        public By cutOffCreditDate = By.Id("com.karum.credits:id/tv_cutoff_date");
        public By newChargesAmount = By.Id("com.karum.credits:id/tv_new_charges");         
        public By paymentsCreditsAmount = By.Id("com.karum.credits:id/tv_payments_credits");         
        public By monthlyAmount = By.Id("com.karum.credits:id/tv_monthly");
        public By availableCreditAmount = By.Id("com.karum.credits:id/tv_available_credit");
        public By overdueAmount = By.Id("com.karum.credits:id/tv_overdue_amount");
        public By totalAmount = By.Id("com.karum.credits:id/tv_total_amount");
        
        //By large text elements
        public By pagototalDescription = By.Id("com.karum.credits:id/tv_hint_total_interest");
        public By indicationForPaymentsDescription = By.Id("com.karum.credits:id/tv_hint_stores_payment");
        public By stepOneDescription = By.Id("com.karum.credits:id/tv_balance_step_1");
        public By stepTwoDescription = By.Id("com.karum.credits:id/tv_balance_step_2");
        public By firstDescription = By.Id("com.karum.credits:id/tv_balance_description_1");
        public By stepThreeDescription = By.Id("com.karum.credits:id/tv_balance_step_3");
        public By secontDescription = By.Id("com.karum.credits:id/tv_balance_description_2");

        public override void SetIOSBy()
        {
            base.SetIOSBy();

            deadlinePayment = By.XPath("//XCUIElementTypeOther[1]/XCUIElementTypeStaticText[contains(@label, '/')]");
            currentPeriodMonth = By.XPath("//XCUIElementTypeOther[1]/XCUIElementTypeStaticText[4]");
            cutOffCreditDate = By.XPath("//XCUIElementTypeOther[2]/XCUIElementTypeStaticText[contains(@label, '/')]");

            newChargesAmount = By.XPath("//XCUIElementTypeOther[3]/XCUIElementTypeStaticText[contains(@label, '$')]");
            paymentsCreditsAmount = By.XPath("//XCUIElementTypeOther[4]/XCUIElementTypeStaticText[contains(@label, '$')]");
            monthlyAmount = By.XPath("//XCUIElementTypeOther[5]/XCUIElementTypeStaticText[contains(@label, '$')]");
            availableCreditAmount = By.XPath("//XCUIElementTypeOther[6]/XCUIElementTypeStaticText[contains(@label, '$')]");
            overdueAmount = By.XPath("//XCUIElementTypeOther[7]/XCUIElementTypeStaticText[contains(@label, '$')]");
            
            pagototalDescription = By.XPath("//*[@label='Pago para no generar intereses + mesualidades vencidadas']");
            totalAmount = By.XPath("//XCUIElementTypeOther[8]/XCUIElementTypeStaticText[contains(@label, '$')]");

            indicationForPaymentsDescription = By.XPath("//XCUIElementTypeStaticText[contains(@label, 'pagar en alguno de nuestros centros afiliados')]");

            stepOneDescription = By.XPath("//XCUIElementTypeOther[3]/XCUIElementTypeOther[1]/XCUIElementTypeStaticText[2]");
            stepTwoDescription = By.XPath("//XCUIElementTypeOther[3]/XCUIElementTypeOther[2]/XCUIElementTypeStaticText[2]");

            firstDescription = By.XPath("//XCUIElementTypeOther[3]/XCUIElementTypeOther[3]//XCUIElementTypeStaticText");

            stepThreeDescription = By.XPath("//XCUIElementTypeOther[3]/XCUIElementTypeOther[4]/XCUIElementTypeStaticText[2]");

            secontDescription = By.XPath("//XCUIElementTypeOther[3]/XCUIElementTypeOther[5]//XCUIElementTypeStaticText");
        }
    }
}