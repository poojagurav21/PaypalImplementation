using System;

namespace PayPalIntegrtion.PaymentRequests;

[Serializable]
public class PaymentRequestCompleteInputDto
{
    public string Token { get; set; }
    public int PaymentTypeId { get; set; }
}