package test.java.utility;

import test.java.data.Client;

public class DataRecover {
    public static Client RecoverClientData(){
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

        return client;
    }
}