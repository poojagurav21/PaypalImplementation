using Volo.Abp.Modularity;

namespace PayPalIntegrtion;

[DependsOn(
    typeof(PayPalIntegrtionApplicationModule),
    typeof(PayPalIntegrtionDomainTestModule)
    )]
public class PayPalIntegrtionApplicationTestModule : AbpModule
{

}
