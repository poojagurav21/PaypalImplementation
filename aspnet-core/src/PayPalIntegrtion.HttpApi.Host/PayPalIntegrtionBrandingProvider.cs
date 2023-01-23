using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace PayPalIntegrtion;

[Dependency(ReplaceServices = true)]
public class PayPalIntegrtionBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "PayPalIntegrtion";
}
