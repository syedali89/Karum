package test.java.utility;

import test.java.data.Client;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class DataRecover {
    private static final String EMAILINBOX = "https://www.mailinator.com/v4/public/inboxes.jsp?to=codigomovil";
    private static final String EMAILPATH = "https://www.mailinator.com/v4/public/inboxes.jsp?msgid=";
    private static final String PATHEMAILONPAGE = "table.jambo_table tr";

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
        client.PhoneNumber = "5551234567";
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
}