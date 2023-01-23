using PayPalIntegrtion.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace PayPalIntegrtion.Permissions;

public class PayPalIntegrtionPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(PayPalIntegrtionPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(PayPalIntegrtionPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<PayPalIntegrtionResource>(name);
    }
}
