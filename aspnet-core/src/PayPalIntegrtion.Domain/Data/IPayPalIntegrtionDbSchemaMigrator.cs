using System.Threading.Tasks;

namespace PayPalIntegrtion.Data;

public interface IPayPalIntegrtionDbSchemaMigrator
{
    Task MigrateAsync();
}
