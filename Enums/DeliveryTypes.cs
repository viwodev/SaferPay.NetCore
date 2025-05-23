﻿using Newtonsoft.Json.Converters;

namespace SaferPay.Enums;

[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
public enum DeliveryTypes
{
    EMAIL,
    SHOP,
    HOMEDELIVERY,
    PICKUP,
    HQ
}
