package test.java.utility;

import org.openqa.selenium.By;
import test.java.constants;
import test.java.data.Client;

import java.io.File;
import java.util.ArrayList;
import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class DataRecover {
    private static final String EMAILINBOX =
            "https://www.mailinator.com/v4/public/inboxes.jsp?to=codigomovil";
    private static final String EMAILPATH =
            "https://www.mailinator.com/v4/public/inboxes.jsp?msgid=";
    private static final By PATHEMAILONPAGE = By.cssSelector("table.jambo_table tr");
    private static final By WAITJUSTNOWEMAIL = By.xpath("//table[@class='table-striped jambo_table']//tr//td[contains(text(), 'just now')]");
    private static final String AVISOPRIVACIDAD_DOCUMENT =
            "AVISO DE PRIVACIDAD (22sep2021).pdf";
    private static final String TERMINOSCONDICIONES_DOCUMENT =
            "TÉRMINOS Y CONDICIONES (22sep2021).pdf";
    private static final String USOMEDIOSTECNOLOGICOS_DOCUMENT =
            "TERMS Y COND MEDIOS ELECTRONICOS (22sep2021).pdf";
    private static final String BUROCREDITO_DOCUMENT =
            "AUTORIZACIÓN BURÓ DE CRÉDITO (22sep2021).pdf";

    public static Client RecoverClientData() {
        //TODO For now the informations is hardcode. Later is gonna refactor.
        Client client = new Client();
        client.AddressStreet = "Some Street";
        client.AddressExtNum = "1234";
        client.AddressIntNum = "1234";
        client.AddressCity = "Ciudad de México";
        client.AddressSubUrb = "Piedad Narvarte";
        client.AddressZipCode = "03000";
        client.Email = "some@email.com";
        client.PhoneNumber = "3327885614";
        //client.firstNameOne = "Antonio";
        client.firstNameOne = "Jose";
        client.firstNameTwo = "Servando";
        client.lastNameOne = "Lopez";
        client.lastNameTwo = "Rodea";
        client.birthDate = "22/03/1974";
        client.gender = "Masculino";
        client.CURP = "LORA740322HDFPDN00";
        client.jobCompany = "Karum";
        client.CompanyPhoneNumber = "1234567890";

        client.userName = "spring2_u1@gmail.com";
        client.userEmail = "spring2_u1@gmail.com";
        client.userPass = "temporal#dev";
        client.userPhone = "3327885614";

        client.accountAmount = "$14,277.13";

        return client;
    }

    public static Client RecoverClientData(String File) {
        //TODO For now the informations is hardcode. Later is gonna refactor.
        Client client = new Client();
        return client;
    }

    public static String RecoverSecurityCode() {
        String securityCode = "";
        String dateReturn = "";


        WebScrap webScrap = new WebScrap();
        try {
            webScrap.waitElementExist(EMAILINBOX, WAITJUSTNOWEMAIL);

            String emailUrl = webScrap.RecoverDataElementPage(
                    EMAILINBOX, PATHEMAILONPAGE, "id");

            emailUrl = EMAILPATH + emailUrl.substring(4);
            dateReturn = webScrap.RecoverDataElementPage(
                    emailUrl, By.cssSelector("body"), "", "html_msg_body");

            webScrap.KillSession();

        }
        catch (Exception ex) {
            webScrap.KillSession();
        }

        //Regex to extract the code
        Pattern pattern = Pattern.compile("(\\d{6})");

        Matcher matcher = pattern.matcher(dateReturn);
        if (matcher.find()) {
            securityCode = matcher.group();
        }
        return securityCode;
    }

    public static String AvisoPrivacidadDocument() {
        File docFile = new File(constants.DOCUMENTS_FOLDER + AVISOPRIVACIDAD_DOCUMENT);
        return PDFDocument.readDocument(docFile);
    }

    public static String TerminosCondicionesDocument() {
        File docFile = new File(constants.DOCUMENTS_FOLDER + TERMINOSCONDICIONES_DOCUMENT);
        return PDFDocument.readDocument(docFile);
    }

    public static String UsoMediosTecnologicosDocument() {
        File docFile = new File(constants.DOCUMENTS_FOLDER + USOMEDIOSTECNOLOGICOS_DOCUMENT);
        return PDFDocument.readDocument(docFile);
    }

    public static String BuroCreditoDocument() {
        File docFile = new File(constants.DOCUMENTS_FOLDER + BUROCREDITO_DOCUMENT);
        return PDFDocument.readDocument(docFile);
    }
}