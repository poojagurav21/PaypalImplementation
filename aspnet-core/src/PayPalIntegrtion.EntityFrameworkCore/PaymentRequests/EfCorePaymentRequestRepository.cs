using PayPalIntegrtion.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using PayPalIntegrtion.PaymentRequests;

namespace EShopOnAbp.PaymentService.PaymentRequests
{
    public class EfCorePaymentRequestRepository :
        EfCoreRepository<
            PayPalIntegrtionDbContext,
            PaymentRequest,
            Guid>,
        IPaymentRequestRepository
    {
        public EfCorePaymentRequestRepository(IDbContextProvider<PayPalIntegrtionDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public override async Task<IQueryable<PaymentRequest>> WithDetailsAsync()
        {
            return (await base.WithDetailsAsync())
                .Include(p => p.Products);
        }
    }
}
