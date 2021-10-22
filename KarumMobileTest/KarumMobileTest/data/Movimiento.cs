namespace data
{
    public class Movimiento 
    {
        public string transactionNumber;
        public string transactionType;
        public string moneyAmount;

        public Movimiento(string transaccionNumber, string transaccionType, string moneyAmount)
        {
            transactionNumber = transaccionNumber;
            transactionType = transaccionType;
            this.moneyAmount = moneyAmount;
        }
    }
}