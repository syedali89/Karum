namespace data
{
    using System.Collections.Generic;

    public class Client 
    {
        #region Personal Info
        public string firstNameOne { get; set; }
        public string firstNameTwo { get; set; }
        public string lastNameOne { get; set; }
        public string lastNameTwo { get; set; }
        public string birthDate { get; set; }
        public string gender { get; set; }
        public string CURP { get; set; }
        #endregion

        #region Address Info
        public string AddressStreet { get; set; }
        public string AddressExtNum { get; set; }
        public string AddressIntNum { get; set; }
        public string AddressZipCode { get; set; }
        public string AddressCity { get; set; }
        public string AddressSubUrb { get; set; }
        #endregion

        #region Contact Info
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        #endregion

        #region Job Info
        public string jobCompany { get; set; }
        public string income { get; set; }
        public string CompanyPhoneNumber { get; set; }
        #endregion

        #region User Credentials
        public string userEmail { get; set; }
        public string userPass { get; set; }
        public string userPhone { get; set; }
        public string estadoCuentaPass { get; set; }
        #endregion

        #region Saldo CLient
        public string newChargesAmount { get; set; }
        public string paymentCreditAmount { get; set; }
        public string monthlyAmount { get; set; }
        public string availableCreditAmount { get; set; }
        public string overdueAmount { get; set; }
        public string totalAmount { get; set; }
        #endregion

        #region Client account information
        public string accountAmount { get; set; }
        public string creditNumber { get; set; }
        public string creditLimitAmount { get; set; }
        public string paymentAmount { get; set; }
        public string totalLoyalPoints { get; set; }
        #endregion

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