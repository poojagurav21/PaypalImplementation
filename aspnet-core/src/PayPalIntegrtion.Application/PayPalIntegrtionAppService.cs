using System;
using System.Collections.Generic;
using System.Text;
using PayPalIntegrtion.Localization;
using Volo.Abp.Application.Services;

namespace PayPalIntegrtion;

/* Inherit your application services from this class.
 */
public abstract class PayPalIntegrtionAppService : ApplicationService
{
    protected PayPalIntegrtionAppService()
    {
        LocalizationResource = typeof(PayPalIntegrtionResource);
    }
}
