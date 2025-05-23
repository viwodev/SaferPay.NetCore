﻿using Newtonsoft.Json.Converters;

namespace SaferPay.Enums;

[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
public enum AddressSources
{
    NONE, 
    SAFERPAY, 
    PREFER_PAYMENTMETHOD
}
