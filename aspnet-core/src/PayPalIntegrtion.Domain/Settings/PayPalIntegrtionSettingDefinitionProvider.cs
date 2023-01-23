using Volo.Abp.Settings;

namespace PayPalIntegrtion.Settings;

public class PayPalIntegrtionSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(PayPalIntegrtionSettings.MySetting1));
    }
}
