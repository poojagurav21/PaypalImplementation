using PayPalIntegrtion.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace PayPalIntegrtion;

[DependsOn(
    typeof(PayPalIntegrtionEntityFrameworkCoreTestModule)
    )]
public class PayPalIntegrtionDomainTestModule : AbpModule
{

}
