using System;

namespace PayPalIntegrtion.PaymentRequests
{
    [Serializable]
    public class PaymentRequestStartResultDto
    {
        public string CheckoutLink { get; set; }
    }
}