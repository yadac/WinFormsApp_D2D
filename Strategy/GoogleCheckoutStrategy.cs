using System;

namespace Strategy
{
    public class GoogleCheckoutStrategy : IPaymentStrategy
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Google Checkout chosen");
        }
    }
}