package test.java.data;

public class Client {
    //Personal Info
    public String firstNameOne = "";
    public String firstNameTwo = "";
    public String lastNameOne = "";
    public String lastNameTwo = "";
    public String birthDate = "";
    public String gender = "";
    public String CURP = "";

    //Address Info
    public String AddressStreet = "";
    public String AddressExtNum = "";
    public String AddressIntNum = "";
    public String AddressZipCode = "";
    public String AddressCity = "";
    public String AddressSubUrb = "";

    //Contact Info
    public String Email = "";
    public String PhoneNumber = "";

    //Job Info
    public String jobCompany = "";
    public String income = "";

    //Credentials
    public String userName = "";
    public String userPass = "";

    public String getFirstName() {
        if(firstNameTwo.isEmpty()) {
            return firstNameOne;
        }
        else {
            return firstNameOne + " " + firstNameTwo;
        }
    }

    public String getLastName() {
        if(lastNameTwo.isEmpty()) {
            return lastNameOne;
        }
        else {
            return lastNameOne + " " + lastNameTwo;
        }
    }

    public String getFullName() {
        return getFirstName() + " " + getLastName();
    }
}
