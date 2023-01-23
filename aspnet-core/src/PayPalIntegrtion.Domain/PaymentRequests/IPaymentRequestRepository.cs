using System;
using Volo.Abp.Domain.Repositories;

namespace PayPalIntegrtion.PaymentRequests
{
    public interface IPaymentRequestRepository : IBasicRepository<PaymentRequest, Guid>
    {
    }
}
