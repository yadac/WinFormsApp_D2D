using System;

namespace Strategy
{
    public class AmazonPaymentsStrategy : IPaymentStrategy
    {
        public void ProcessPayment()
        {
            Console.WriteLine("AmazonPayments chosen");
        }
    }
}