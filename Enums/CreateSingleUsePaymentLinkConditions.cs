using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaferPay.Enums;

[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
public enum CreateSingleUsePaymentLinkConditions
{
    NONE, 
    THREE_DS_AUTHENTICATION_SUCCESSFUL_OR_ATTEMPTED, 
    WITH_SUCCESSFUL_THREE_DS_CHALLENGE
}
