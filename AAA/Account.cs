namespace AAA
{
    public class Account
    {
        public Account()
        {
            Balance = 200m;
        }
        public void AddTransaction(decimal amount)
        {

        }

        public decimal Balance { get; private set; }
    }
}