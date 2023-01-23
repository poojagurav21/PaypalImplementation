using System.Threading.Tasks;
using PayPalIntegrtion.PaymentRequests;
using Volo.Abp.DependencyInjection;

namespace PayPalIntegrtion.PaymentMethods;

public interface IPaymentMethod : ITransientDependency
{
    string Name { get; }

    public Task<PaymentRequestStartResultDto> StartAsync(PaymentRequest paymentRequest, PaymentRequestStartDto input);

    public Task<PaymentRequest> CompleteAsync(IPaymentRequestRepository paymentRequestRepository, string token);

    public Task HandleWebhookAsync(string payload);
}