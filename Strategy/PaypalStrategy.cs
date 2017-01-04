using System;

namespace Strategy
{
    public class PaypalStrategy : IPaymentStrategy
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Paypal chosen");
        }
    }
}