using PayPalIntegrtion.PaymentMethods;
using System.Linq;
using System.Threading.Tasks;

namespace PayPalIntegrtion.PaymentRequests
{
    public class PaymentRequestAppService : PayPalIntegrtionAppService, IPaymentRequestAppService
    {
        private readonly PaymentMethodResolver _paymentMethodResolver;
        protected IPaymentRequestRepository PaymentRequestRepository { get; }

        public PaymentRequestAppService(
            IPaymentRequestRepository paymentRequestRepository,
            PaymentMethodResolver paymentMethodResolver)
        {
            PaymentRequestRepository = paymentRequestRepository;
            _paymentMethodResolver = paymentMethodResolver;
        }

        public virtual async Task<PaymentRequestDto> CreateAsync(PaymentRequestCreationDto input)
        {
            var paymentRequest = new PaymentRequest(id: GuidGenerator.Create(), orderId: input.OrderId,
                orderNo: input.OrderNo, currency: input.Currency, buyerId: input.BuyerId);

            foreach (var paymentRequestProduct in input.Products
                         .Select(s => new PaymentRequestProduct(
                             GuidGenerator.Create(),
                             paymentRequestId: paymentRequest.Id,
                             code: s.Code,
                             name: s.Name,
                             unitPrice: s.UnitPrice,
                             quantity: s.Quantity,
                             totalPrice: s.TotalPrice,
                             referenceId: s.ReferenceId)))
            {
                paymentRequest.Products.Add(paymentRequestProduct);
            }
            await PaymentRequestRepository.InsertAsync(paymentRequest);

            return ObjectMapper.Map<PaymentRequest, PaymentRequestDto>(paymentRequest);
        }
        public virtual async Task<PaymentRequestStartResultDto> StartAsync(string paymentType, PaymentRequestStartDto input)
        {
            PaymentRequest paymentRequest =
                await PaymentRequestRepository.GetAsync(input.PaymentRequestId, includeDetails: true);

            var paymentService = _paymentMethodResolver.Resolve(paymentType);
            return await paymentService.StartAsync(paymentRequest, input);
        }
        public virtual async Task<PaymentRequestDto> CompleteAsync(string paymentType, PaymentRequestCompleteInputDto input)
        {
            var paymentService = _paymentMethodResolver.Resolve(paymentType);

            var paymentRequest = await paymentService.CompleteAsync(PaymentRequestRepository, input.Token);
            return ObjectMapper.Map<PaymentRequest, PaymentRequestDto>(paymentRequest);
        }
        public virtual async Task<bool> HandleWebhookAsync(string paymentType, string payload)
        {
            var paymentService = _paymentMethodResolver.Resolve(paymentType);
            await paymentService.HandleWebhookAsync(payload);
            return true;
        }
    }
}