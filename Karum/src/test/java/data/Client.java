package test.java.data;

public class Client {
    public String firstNameOne = "";
    public String firstNameTwo = "";
    public String lastNameOne = "";
    public String lastNameTwo = "";
    public String birthDate = "";
    public String gender = "";
    public String CURP = "";

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
