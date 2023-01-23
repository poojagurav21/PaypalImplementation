using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PayPalIntegrtion.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class PayPalIntegrtionDbContextFactory : IDesignTimeDbContextFactory<PayPalIntegrtionDbContext>
{
    public PayPalIntegrtionDbContext CreateDbContext(string[] args)
    {
        PayPalIntegrtionEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<PayPalIntegrtionDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new PayPalIntegrtionDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../PayPalIntegrtion.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
