package test.java.pages;

import org.openqa.selenium.By;
import org.testng.Assert;
import test.java.utility.Driver;
import test.java.utility.SwipeAction;

public class INEPhotoPage extends BasePage {
    //By checkbox
    public By identificacionVigenteCheckbox = By.id("com.karum.credits:id/checkbox_1");
    public By validadoElementosSeguridadCheckbox = By.id("com.karum.credits:id/checkbox_2");
    public By capturarINEIFEbtn = By.id("com.karum.credits:id/button_capture_identification");
    //By Camera Take Photo
    public By CONFIRMARbtn = By.id("com.karum.credits:id/button_continue");
    public By SIGUIENTEbtn = By.id("com.karum.credits:id/button_next");
    //By Confirm Photos
    public By messageTitle = By.id("com.karum.credits:id/text_title");
    public By takedPhotos = By.xpath("//androidx.recyclerview.widget.RecyclerView[@resource-id='com.karum.credits:id/rv_pictures_documents']/android.view.ViewGroup/android.widget.ImageView");
    public By alertbeforeGoToNextPage = By.id("//androidx.recyclerview.widget.RecyclerView[@resource-id='com.karum.credits:id/rv_pictures_documents']/android.view.ViewGroup/android.widget.ImageView");

    //Contructor
    public INEPhotoPage(Driver driver) {
        super(driver);
    }

    public void tapCheckboxs(boolean identificacionVigente, boolean validadoElementosSeguridad) {
        if(identificacionVigente) {
            clickElement(identificacionVigenteCheckbox);
        }
        if(validadoElementosSeguridad) {
            clickElement(validadoElementosSeguridadCheckbox);
        }
    }

    public void tapCapturarINE() {
        clickElement(capturarINEIFEbtn);
    }

    public void takeFrontPhoto() {
        //TODO PhotoActions.Pushphoto("frontINE");
        clickElement(CONFIRMARbtn);
    }

    public void takeBackPhoto() {
        //TODO PhotoActions.Pushphoto("backINE");
        clickElement(CONFIRMARbtn);
    }

    public AddressPhotoPage allProcessIFEPhotos() {
        this.tapCheckboxs(true,true);
        this.tapCapturarINE();
        this.takeFrontPhoto();
        this.takeBackPhoto();
        //
        SwipeAction.swipeDownUntilElementText(_driver, "SIGUIENTE");
        clickElement(SIGUIENTEbtn);
        clickElement(CONFIRMARbtn);

        return new AddressPhotoPage(_driver);
    }

    public void verifyCapturePhotoOK() {
        assertElementText(messageTitle,"Verifica la información, si es necesario edita los datos.");
        Assert.assertTrue(_driver.GetIntance().findElements(takedPhotos).size() == 2,
                "Error,There have to be two photos on screen, one for front INE and other for the back");
        assertElementWhitTextExist("LOPEZ");
        assertElementWhitTextExist("RODEA");
        assertElementWhitTextExist("ANTONIO SERVANDO");
        //assertElementWhitTextExist("LORA740322HDFPDN00");
        assertElementWhitTextExist("1992");
        assertElementWhitTextExist("2020");
        assertElementWhitTextExist("04");
        //assertElementWhitTextExist("RLPRDAN74032209460");
        assertElementWhitTextExist("3233057048259");
        assertElementWhitTextExist("2086617703");
        Assert.assertTrue(validateElementVisible(SIGUIENTEbtn), "Error, SIGUIENTE button is not visible");
    }

    public void verifycapturarINEIFEbtnState(boolean isEnabled) {
        String state = "Disabled";
        if(isEnabled) {
            state = "Enabled";
        }

        Assert.assertEquals(isEnabled, validateElementEnable(capturarINEIFEbtn),
                "Error, checkbox 'Identificacion Vigente' and 'elementos de seguridad validados' are mandatory and 'Capturar INE/IFE' has to be "+ state + ".");
    }

    public void verifyContinuarnextPage() {
        Assert.assertTrue(validateElementVisible(CONFIRMARbtn), "Error, CONFIRMAR button is not visible");
        assertElementText(alertbeforeGoToNextPage, "Asegúrate que la información sea correcta");
    }
}