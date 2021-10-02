package test.java.utility;

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
    private static final String PATHEMAILONPAGE = "table.jambo_table tr";
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
        client.firstNameOne = "Antonio";
        client.firstNameTwo = "Servando";
        client.lastNameOne = "Lopez";
        client.lastNameTwo = "Rodea";
        client.birthDate = "22/03/1974";
        client.gender = "Masculino";
        client.CURP = "LORA740322HDFPDN00";
        client.jobCompany = "Karum";

        client.userName = "spring2_u1@gmail.com";
        client.userPass = "temporal#dev";
        client.userPhone = "3327885614";

        return client;
    }

    public static String RecoverSecurityCode() {
        String securityCode = "";
        String emailUrl = WebScrap.RecoverDataElementPage(
                EMAILINBOX, PATHEMAILONPAGE, "id");

        emailUrl = EMAILPATH + emailUrl.substring(4);
        String dateReturn = WebScrap.RecoverDataElementPage(
                emailUrl,"body", "", 1);

        //Regex to extract the code
        Pattern pattern = Pattern.compile("(\\d{6})");
        Matcher matcher = pattern.matcher(dateReturn);
        if(matcher.find()) {
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