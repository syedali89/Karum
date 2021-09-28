package test.java.pages;

import org.openqa.selenium.By;
import org.testng.Assert;
import test.java.utility.Driver;

public class FacialRegistrationPage extends BasePage{
    //By instructions
    public By instructionTitle = By.id("com.karum.credits:id/textTitle");
    public By capturarRostroBtn = By.id("com.karum.credits:id/button");
    //By Face Recognition
    public By ContinuarBtnFaceCapture = By.xpath("//*[@text='Continuar']");
    public By TOMARDENUEVOBtnFaceCapture = By.xpath("//*[@text='Tomar de nuevo']");
    public By CONFIRMARBtnFaceCapture = By.id("com.karum.credits:id/buttonConfirm");
    public By CerrarBtnFaceCaptureFail = By.id("android:id/button2");
    public By RecapturarBtnFaceCaptureFail = By.id("android:id/button1");


    //Contructor
    public FacialRegistrationPage(Driver driver) {
        super(driver);
    }

    public void tapCapturarRostro() {
        clickElement(capturarRostroBtn);
    }

    public void captureFace(boolean photoMatch) {
        clickElement(ContinuarBtnFaceCapture);
        if(photoMatch) {
            //TODO Camera.Pushphoto("Goodface")
            //TODO WaitAcercar
            //TODO Camera.Pushphoto("GoodfaceCLOSE")
        }
        else {
            //TODO Camera.Pushphoto("Badface")
            //TODO WaitAcercar
            //TODO Camera.Pushphoto("bADfaceCLOSE")
        }
        clickElement(CONFIRMARBtnFaceCapture);
    }

    public void captureWrong() {
        clickElement(ContinuarBtnFaceCapture);
            //TODO Camera.Pushphoto("Wrongface")
            //TODO WaitAcercar
            //TODO Camera.Pushphoto("WrongCLOSE")
    }

    public BasicHolderAddressPage allProcessFacePage() {
        this.tapCapturarRostro();
        this.captureFace(true);

        return new BasicHolderAddressPage(_driver);
    }

    public void verifyWrongphoto() {
        assertElementWithTextExist("Intentemos de nuevo");
        assertElementWithTextExist("Pero primero, veamos tu foto y validemos un ambiente correcto.");
        assertElementWithTextExist("Expresión normal, no sonreir");
        assertElementWithTextExist("Sin brillo luz externa");
    }

    public void verifyPhotoDontMatch() {
        assertElementWithTextExist("El rostro no coincide con la identificación");
        Assert.assertTrue(validateElementVisible(CerrarBtnFaceCaptureFail),
                "Error, CERRAR btn is not visible");
        Assert.assertTrue(validateElementEnable(CerrarBtnFaceCaptureFail),
                "Error, CERRAR btn is not enabled");
        Assert.assertTrue(validateElementVisible(RecapturarBtnFaceCaptureFail),
                "Error, RECAPTURAR btn is not visible");
        Assert.assertTrue(validateElementEnable(RecapturarBtnFaceCaptureFail),
                "Error, RECAPTURAR btn is not enabled");
    }

    public void verifyButtoContinuarCaptureFace() {
        Assert.assertTrue(validateElementVisible(ContinuarBtnFaceCapture), "Error, CONTINUE button is not visible.");
    }

    public void verifyCaptureFace() {
        Assert.assertTrue(validateElementVisible(CONFIRMARBtnFaceCapture), "Error, CONFIRMAR button is not visible.");
        Assert.assertTrue(validateElementVisible(TOMARDENUEVOBtnFaceCapture), "Error, TOMAR DE NUEVO button is not visible.");
    }

    public void verifyPhotoMatch() {
        assertElementWithTextExist("Completa tu información");
    }

    public void verifyInstructions() {
        assertElementText(instructionTitle, "Registro facial del cliente");
        assertElementWithTextExist(
                "Toma una fotografía al cliente.");
        assertElementWithTextExist(
                "Una vez que se detecte el rostro del cliente, indícale que realice los movimientos señalados en la pantalla. Evita contraluces, lugares oscuros y asegúrate de enfocar el rostro correctamente. Toma la fotografía con rostro descubierto sin gorra ni lentes.");
        Assert.assertTrue(validateElementVisible(capturarRostroBtn), "Error, 'CAPTURAR ROSTRO' button is not visible");
    }
}