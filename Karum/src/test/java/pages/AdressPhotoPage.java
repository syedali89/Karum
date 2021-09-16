package test.java.pages;

import org.openqa.selenium.By;
import org.testng.Assert;
import test.java.utility.Driver;
import test.java.utility.TouchActions;

public class AdressPhotoPage extends BasePage{
    private String user;

    //By checkbox
    public By identificacionVigenteCheckbox = By.id("com.karum.credits:id/checkbox_1");
    public By validadoElementosSeguridadCheckbox = By.id("com.karum.credits:id/checkbox_2");
    public By capturarINEIFEbtn = By.id("com.karum.credits:id/button_capture_identification");
    //By Camera Take Photo
    public By CONFIRMARbtn = By.id("com.karum.credits:id/button_continue");
    public By SIGUIENTEbtn = By.id("com.karum.credits:id/button_next");
    //By Confirm Photos
    public By takedPhotos = By.xpath("//androidx.recyclerview.widget.RecyclerView[@resource-id='com.karum.credits:id/rv_pictures_documents']/android.view.ViewGroup/android.widget.ImageView");

    //Contructor
    public AdressPhotoPage(Driver driver, String type) {
        super(driver, type);
    }

    public void tapCheckboxs(boolean identificacionVigente, boolean validadoElementosSeguridad) {
        if(identificacionVigente)
        {
            clickElement(identificacionVigenteCheckbox);
        }
        if(validadoElementosSeguridad)
        {
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

    public void confirmPhotos() {
        TouchActions.swipeDownUntilElementExist(_driver.GetIntance(), SIGUIENTEbtn);
        clickElement(SIGUIENTEbtn);
    }

    public void verifyCapturePhotoOK(boolean isEnabled)
    {
        String state = "Disabled";
        if(isEnabled) {
            state = "Enabled";
        }

        Assert.assertEquals(isEnabled, validateElementEnable(capturarINEIFEbtn),
                "Error, checkbox 'Identificacion Vigente' and 'elementos de seguridad validados' are mandatory and 'Capturar INE/IFE' has to be "+ state + ".");
    }



    public void verifycapturarINEIFEbtnState(boolean isEnabled)
    {
        String state = "Disabled";
        if(isEnabled) {
            state = "Enabled";
        }

        Assert.assertEquals(isEnabled, validateElementEnable(capturarINEIFEbtn),
                "Error, checkbox 'Identificacion Vigente' and 'elementos de seguridad validados' are mandatory and 'Capturar INE/IFE' has to be "+ state + ".");
    }
}