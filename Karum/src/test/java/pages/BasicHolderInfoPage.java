package test.java.pages;

import org.openqa.selenium.By;
import org.testng.Assert;
import test.java.data.Client;
import test.java.utility.Driver;
import test.java.utility.SwipeAction;

public class BasicHolderInfoPage extends BasePage {
    //By elements
    //DATA from INE
    public By textClientName = By.id("com.karum.credits:id/tv_client_name");
    public By textClientFullName = By.id("com.karum.credits:id/tv_client_full_name");
    public By textClientBirthDay = By.id("com.karum.credits:id/tv_client_born_date");
    public By textClientGender = By.id("com.karum.credits:id/tv_client_gender");
    public By textClientCURP = By.id("com.karum.credits:id/tv_client_curp");

    //Input Address/Contact Data
    public By inputClientStreet = By.id("com.karum.credits:id/et_street_client");
    public By inputClientExtNum = By.id("com.karum.credits:id/et_ext_num");
    public By inputClientIntNum = By.id("com.karum.credits:id/et_int_num");
    public By inputClientCity = By.id("com.karum.credits:id/et_city");
    public By inputClientSubUrb = By.id("com.karum.credits:id/et_suburb");
    public By inputClientEmail = By.id("com.karum.credits:id/et_email");

    public By textClientNumberCountry = By.id("com.karum.credits:id/tv_hint_code_area");
    public By textClientNumber = By.id("com.karum.credits:id/tv_hint_phone");
    public By textClientNumberCountryConfirm = By.id("com.karum.credits:id/tv_hint_code_area_confirm");
    public By textClientNumberConfirm = By.id("com.karum.credits:id/tv_hint_phone_confirm");

    public By inputClientNumberCountry = By.id("com.karum.credits:id/et_code_area");
    public By inputClientNumber = By.id("com.karum.credits:id/et_phone");
    public By inputClientNumberCountryConfirm = By.id("com.karum.credits:id/et_code_area_confirm");
    public By inputClientNumberConfirm = By.id("com.karum.credits:id/et_phone_confirm");

    public By inputRetireCardState = By.id("com.karum.credits:id/et_state_branch_data");
    public By inputRetireCardLocaly = By.id("com.karum.credits:id/et_locality_branch_data");
    public By inputRetireCardSucursal = By.id("com.karum.credits:id/et_branch_data");
    public By CONTINUARbtn = By.id("com.karum.credits:id/btn_continue");

    //Contructor
    public BasicHolderInfoPage(Driver driver) {
        super(driver);
    }

    public void verifyTextAddressInfo(Client client) {
        //Data recover From INE
        assertElementWhitTextExist("Completa tu información");
        assertElementText(textClientName, client.getFirstName());
        assertElementWhitTextExist("Nombre");
        assertElementText(textClientFullName, client.getFullName());
        assertElementWhitTextExist("Fecha de nacimiento");
        assertElementText(textClientBirthDay, client.birthDate);
        assertElementWhitTextExist("Género");
        assertElementText(textClientGender, client.gender);
        assertElementWhitTextExist("CURP");
        assertElementText(textClientCURP, client.CURP);

        //Address/Contact Input data
        assertElementWhitTextExist("Calle *");
        Assert.assertTrue(validateElementEnable(inputClientStreet),
                "Error, 'CALLE' input is not enabled");

        assertElementWhitTextExist("No. exterior *");
        Assert.assertTrue(validateElementEnable(inputClientExtNum),
                "Error, 'No. exterior' input is not enabled");

        assertElementWhitTextExist("Ciudad *");
        Assert.assertTrue(validateElementEnable(inputClientCity),
                "Error, 'Ciudad' input is not enabled");

        assertElementWhitTextExist("No. interior");
        Assert.assertTrue(validateElementEnable(inputClientIntNum),
                "Error, 'No. interior' input is not enabled");

        assertElementWhitTextExist("Colonia *");
        Assert.assertTrue(validateElementEnable(inputClientSubUrb),
                "Error, 'Colonia' input is not enabled");

        assertElementWhitTextExist("Correo electrónico *");
        Assert.assertTrue(validateElementEnable(inputClientEmail),
                "Error, 'Correo Electrónico' input is not enabled");

        assertElementWhitTextExist("Pais *");
        Assert.assertTrue(validateElementEnable(inputClientEmail),
                "Error, 'Correo Electrónico' input is not enabled");

        assertElementText(textClientNumberCountry,"País *");
        Assert.assertTrue(validateElementEnable(inputClientNumberCountry),
                "Error, 'Pais *' input is not enabled");

        assertElementText(textClientNumber, "Celular 10 dígitos *");
        Assert.assertTrue(validateElementEnable(inputClientNumber),
                "Error, 'Celular 10 dígitos *' input is not enabled");

        assertElementText(textClientNumberCountryConfirm, "País *");
        Assert.assertTrue(validateElementEnable(inputClientNumberCountryConfirm),
                "Error, 'País *' confirm input is not enabled");

        assertElementText(textClientNumberConfirm, "Celular 10 dígitos *");
        Assert.assertTrue(validateElementEnable(inputClientNumberConfirm),
                "Error, 'Celular 10 dígitos *' confirm input is not enabled");

        assertElementWhitTextExist("* Campos obligatorios");
        assertElementWhitTextExist("Selecciona el estado");
        Assert.assertTrue(validateElementEnable(inputRetireCardState),
                "Error, 'Selecciona el estado' confirm input is not enabled");

        assertElementWhitTextExist("Selecciona la localidad");
        Assert.assertTrue(validateElementEnable(inputRetireCardLocaly),
                "Error, 'Selecciona la localidad' confirm input is not enabled");

        assertElementWhitTextExist("Selecciona la sucursal");
        Assert.assertTrue(validateElementEnable(inputRetireCardSucursal),
                "Error, 'Selecciona la sucursal' input is not enabled");

        Assert.assertTrue(validateElementEnable(CONTINUARbtn),
                "Error, CONTINUAR btn input is not enabled");

    }
}