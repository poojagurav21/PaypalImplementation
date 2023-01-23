using PayPalIntegrtion.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace PayPalIntegrtion.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(PayPalIntegrtionEntityFrameworkCoreModule),
    typeof(PayPalIntegrtionApplicationContractsModule)
    )]
public class PayPalIntegrtionDbMigratorModule : AbpModule
{

}
