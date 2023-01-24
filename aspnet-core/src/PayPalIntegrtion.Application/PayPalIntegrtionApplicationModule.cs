using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PayPalCheckoutSdk.Core;
using PayPalIntegrtion.PaymentMethods;
using PayPalIntegrtion.PayPal;
using System;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace PayPalIntegrtion;

[DependsOn(
    typeof(PayPalIntegrtionDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(PayPalIntegrtionApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class PayPalIntegrtionApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<PayPalIntegrtionApplicationModule>();
        });
        Configure<PayPalOptions>(context.Services.GetConfiguration().GetSection("Payment:PayPal"));

        context.Services.AddTransient(provider =>
        {
            var options = provider.GetService<IOptions<PayPalOptions>>().Value;

            if (options.Environment.IsNullOrWhiteSpace() || options.Environment == PayPalConsts.Environment.Sandbox)
            {
                return new PayPalHttpClient(new SandboxEnvironment(options.ClientId, options.Secret));
            }

            return new PayPalHttpClient(new LiveEnvironment(options.ClientId, options.Secret));
        });

        context.Services.AddTransient<PaymentMethodResolver>(provider => new PaymentMethodResolver(
            provider.GetServices<IPaymentMethod>(),
            provider.GetRequiredService<ILogger<PaymentMethodResolver>>()
        ));
    }
}
