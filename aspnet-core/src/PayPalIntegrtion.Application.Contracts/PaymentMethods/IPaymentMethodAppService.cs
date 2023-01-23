using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace PayPalIntegrtion.PaymentMethods;

public interface IPaymentMethodAppService : IApplicationService
{
    Task<List<PaymentMethodDto>> GetListAsync();
}
