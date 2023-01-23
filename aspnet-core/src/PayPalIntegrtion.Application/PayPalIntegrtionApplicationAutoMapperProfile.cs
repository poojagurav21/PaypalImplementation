using AutoMapper;
using PayPalIntegrtion.PaymentRequests;

namespace PayPalIntegrtion;

public class PayPalIntegrtionApplicationAutoMapperProfile : Profile
{
    public PayPalIntegrtionApplicationAutoMapperProfile()
    {
        CreateMap<PaymentRequest, PaymentRequestDto>();
        CreateMap<PaymentRequestProduct, PaymentRequestProductDto>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
