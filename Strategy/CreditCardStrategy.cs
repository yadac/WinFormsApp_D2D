using System;

namespace Strategy
{
    public class CreditCardStrategy : IPaymentStrategy
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Credit card payment chosen");
        }
    }
}