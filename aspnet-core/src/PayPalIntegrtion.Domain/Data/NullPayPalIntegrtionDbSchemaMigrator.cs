using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace PayPalIntegrtion.Data;

/* This is used if database provider does't define
 * IPayPalIntegrtionDbSchemaMigrator implementation.
 */
public class NullPayPalIntegrtionDbSchemaMigrator : IPayPalIntegrtionDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
