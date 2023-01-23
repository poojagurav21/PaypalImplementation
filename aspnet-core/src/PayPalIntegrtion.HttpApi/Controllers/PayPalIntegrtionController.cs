using PayPalIntegrtion.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace PayPalIntegrtion.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class PayPalIntegrtionController : AbpControllerBase
{
    protected PayPalIntegrtionController()
    {
        LocalizationResource = typeof(PayPalIntegrtionResource);
    }
}
