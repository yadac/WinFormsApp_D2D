using System.Collections.Generic;

namespace Strategy
{
    public class OnlineCart
    {
        private readonly IDictionary<PaymentType, IPaymentStrategy> paymentStrategies;

        public OnlineCart()
        {
            paymentStrategies = new Dictionary<PaymentType, IPaymentStrategy>();
            paymentStrategies.Add(PaymentType.CreditCard, new CreditCardStrategy());
            paymentStrategies.Add(PaymentType.Paypal, new PaypalStrategy());
            paymentStrategies.Add(PaymentType.AmazonPayments, new AmazonPaymentsStrategy());
            paymentStrategies.Add(PaymentType.GoogleCheckout, new GoogleCheckoutStrategy());
        }

        public void CheckOut(PaymentType paymentType)
        {
            paymentStrategies[paymentType].ProcessPayment();
        }
    }
}