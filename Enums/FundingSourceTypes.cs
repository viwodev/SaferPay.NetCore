using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaferPay.Enums;


/// <summary>
/// V:1.51
/// </summary>
[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
public enum FundingSourceTypes
{
    UNSPECIFIED, 
    CREDIT, 
    DEBIT, 
    PREPAID
}
