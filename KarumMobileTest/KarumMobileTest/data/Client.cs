using System.Collections.Generic;

namespace data
{
    public class Client {
        //Personal Info
        public string firstNameOne = "";
        public string firstNameTwo = "";
        public string lastNameOne = "";
        public string lastNameTwo = "";
        public string birthDate = "";
        public string gender = "";
        public string CURP = "";

        //Address Info
        public string AddressStreet = "";
        public string AddressExtNum = "";
        public string AddressIntNum = "";
        public string AddressZipCode = "";
        public string AddressCity = "";
        public string AddressSubUrb = "";

        //Contact Info
        public string Email = "";
        public string PhoneNumber = "";

        //Job Info
        public string jobCompany = "";
        public string income = "";
        public string CompanyPhoneNumber = "";

        //Credentials
        public string userEmail = "";
        public string userPass = "";
        public string userPhone = "";
        public string estadoCuentaPass = "";

        //Saldo CLient
        public string newChargesAmount = "";
        public string paymentCreditAmount = "";
        public string monthlyAmount = "";
        public string availableCreditAmount = "";
        public string overdueAmount = "";
        public string totalAmount = "";

        //Client account information
        public string accountAmount = "";
        public string creditNumber = "";
        public string creditLimitAmount = "";
        public string paymentAmount = "";
        public string totalLoyalPoints = "";

        public List<Movimiento> clientMovimientos = new List<Movimiento>();

        public string getFirstName() 
        {
            if (firstNameTwo.Equals(string.Empty))
            {
                return firstNameOne;
            }
            else {
                return firstNameOne + " " + firstNameTwo;
            }
        }

        public string getLastName() 
        {
            if (lastNameTwo.Equals(string.Empty)) 
            {
                return lastNameOne;
            }
            else 
            {
                return lastNameOne + " " + lastNameTwo;
            }
        }

        public string getFullName() 
        {
            return getFirstName() + " " + getLastName();
        }

        public string getLastCreditNumber() 
        {
            return creditNumber.Substring(creditNumber.Length - 4);
        }
    }
}