package test.java.pages;

import org.openqa.selenium.By;
import org.testng.Assert;
import test.java.utility.CameraActions;
import test.java.utility.Driver;

public class AddressPhotoPage extends BasePage{
    //By checkbox
    public By takePhotoAdressdoctitle = By.id("com.karum.credits:id/text_title");
    public By takePhotoAdressdocIndications = By.id("com.karum.credits:id/text_inst");
    public By CAPTURARDOCUMENTObtn = By.id("com.karum.credits:id/button_capture_doc");
    //By Confirm Photo
    public By addresDocumentPhotoTitle = By.id("com.karum.credits:id/text_title");
    public By takedPhoto = By.id("com.karum.credits:id/imageView");
    public By continuarNextPageBtn = By.id("com.karum.credits:id/button_capture_success");
    public By capturePhotoAgainBtn = By.id("com.karum.credits:id/button_capture_again");

    //Contructor
    public AddressPhotoPage(Driver driver) {
        super(driver);
    }

    public void tapCapturarDocumento() {
        clickElement(CAPTURARDOCUMENTObtn);
    }

    public void takeDocumentPhoto() {
        CameraActions.TakePhoto(_driver);
    }

    public void tapVolverCapturar() {
        clickElement(capturePhotoAgainBtn);
    }

    public FacialRegistrationPage allProcessAddressPage() {
        this.tapCapturarDocumento();
        this.takeDocumentPhoto();
        clickElement(continuarNextPageBtn);
        return new FacialRegistrationPage(_driver);
    }

    public void verifyAlertBeforePhotos() {
        assertElementWithTextExist("Comprobante de domicilio");
        assertElementText(takePhotoAdressdoctitle,
                "Toma una fotografía del comprobante de domicilio");
        assertElementText(takePhotoAdressdocIndications,
                "Coloca el documento sobre una superficie oscura para un mejor contraste. Evita reflejos del sol y luces (como lámparas o focos).");
        assertElementText(CAPTURARDOCUMENTObtn,
                "CAPTURAR DOCUMENTO");
        Assert.assertTrue(validateElementVisible(CAPTURARDOCUMENTObtn),
                "Error, CAPTURAR DOCUMENTO is not visible");
        Assert.assertTrue(validateElementEnable(CAPTURARDOCUMENTObtn),
                "Error, CAPTURAR DOCUMENTO is not enabled");
    }

    public void verifyPhotoTakedPage() {
        assertElementText(addresDocumentPhotoTitle,
                "Comprobante de domicilio");
        Assert.assertTrue(validateElementVisible(takedPhoto),
                "Error, address document photo is not visible");
        Assert.assertTrue(validateElementVisible(continuarNextPageBtn),
                "Error, CONTINUAR button is not visible");
        Assert.assertTrue(validateElementVisible(capturePhotoAgainBtn),
                "Error, 'Volver a capturar' button is not visible");
    }

}