using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PayPalIntegrtion.Data;
using Volo.Abp.DependencyInjection;

namespace PayPalIntegrtion.EntityFrameworkCore;

public class EntityFrameworkCorePayPalIntegrtionDbSchemaMigrator
    : IPayPalIntegrtionDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCorePayPalIntegrtionDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the PayPalIntegrtionDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<PayPalIntegrtionDbContext>()
            .Database
            .MigrateAsync();
    }
}
