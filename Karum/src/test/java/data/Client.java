package test.java.data;

public class Client {
    public String firstNameOne = "";
    public String firstNameTwo = "";
    public String lastNameOne = "";
    public String lastNameTwo = "";
    public String birthDate = "";
    public String gender = "";
    public String CURP = "";
    public String AddressStreet = "";
    public String AddressExtNum = "";
    public String AddressIntNum = "";
    public String AddressZipCode = "";
    public String Email = "";
    public String PhoneNumber = "";

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
