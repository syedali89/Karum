namespace pages
{
    using data;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using utility;
    using static constants;

    public partial class EstadoCuentaPage : BasePage
    {
        //By
        public By estadosCuenta = By.Id("com.karum.credits:id/tv_period_item");      
        public By passwordEstadoCuenta = By.Id("com.karum.credits:id/et_pass_login");
        public By ACEPTARpasswordbtn = By.XPath("//*[@text='ACEPTAR']");      
        public By CANCELARpasswordbtn = By.XPath("//*[@text='CANCELAR']");      
        
        //By Document
        public By pageIndicator = By.Id("com.karum.credits:id/tv_pager_indicator");      
        public By nextPageBtn = By.Id("com.karum.credits:id/iv_next_page");      
        public By previousPageBtn = By.Id("com.karum.credits:id/iv_previous_page");      
        public By DESCARGARBtn = By.Id("com.karum.credits:id/btn_download");      
        public By pdfPreview = By.Id("com.karum.credits:id/pdf_view");

        public override void SetIOSBy()
        {
            base.SetIOSBy();

            estadosCuenta = By.XPath("//XCUIElementTypeTable/XCUIElementTypeCell/XCUIElementTypeStaticText[contains(@label, ' ')]");

            passwordEstadoCuenta = By.XPath("//*[@value='Contraseña']");
            ACEPTARpasswordbtn = By.XPath("//*[@label='Aceptar']");
            CANCELARpasswordbtn = By.XPath("//*[@label='Cancelar']");

            pageIndicator = By.XPath("//*[contains(@label,'Páginas')]");

            nextPageBtn = By.XPath("//*[contains(@label, 'ic arrow down')]");
            previousPageBtn = By.XPath("//*[contains(@label, 'ic arrow up')]");

            DESCARGARBtn = By.XPath("//*[@label='DESCARGAR PDF']");
            pdfPreview = By.XPath("//XCUIElementTypeOther[4]/XCUIElementTypeOther[1]/XCUIElementTypeScrollView[1]/XCUIElementTypeOther[1]/XCUIElementTypeOther[2]");
        }
    }
}