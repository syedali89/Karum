namespace data
{
    public class Movimiento 
    {
        public string transactionNumber;
        public string transactionType;
        public string moneyAmount;

        public Movimiento(string transaccionNumber, string transaccionType, string moneyAmount)
        {
            this.transactionNumber = transaccionNumber;
            this.transactionType = transaccionType;
            this.moneyAmount = moneyAmount;
        }

        public bool equalMovements(Movimiento mov)
        {
            return mov.moneyAmount.Equals(this.moneyAmount)
                     && mov.transactionNumber.Equals(this.transactionNumber)
                     && mov.transactionType.Equals(this.transactionType);
        }
    }
}