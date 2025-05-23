﻿using Newtonsoft.Json.Converters;

namespace SaferPay.Enums;

[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
public enum Scheme
{
    MASTERCARD, 
    VISA, 
    JCB, 
    DINERS, 
    AMEX
}
