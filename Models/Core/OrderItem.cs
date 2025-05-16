using Newtonsoft.Json;
using SaferPay.Enums;

namespace SaferPay.Models.Core;


/// <summary>
/// Represents an item in an order, including details such as product information, pricing, quantity, and tax.
/// </summary>
/// <remarks>
/// This class encapsulates the details of an individual order item, including its type, pricing, tax,
/// and other metadata. It supports various item types such as physical goods, digital products, services, and
/// fees.<br/><br/>
/// Update Version : <see langword="1.46"/> <br/>
/// Updated At : <see langword="2025-05-16"/> <br/> 
/// </remarks>
public class OrderItem
{
    /// <summary>
    /// Category name
    /// </summary>
    public string CategoryName { get; set; }


    /// <summary>
    /// Description
    /// </summary>
    public string Description { get; set; }


    /// <summary>
    /// Discount amount including tax
    /// </summary>
    public string DiscountAmount { get; set; }


    /// <summary>
    /// Product id
    /// </summary>
    public string Id { get; set; }


    /// <summary>
    /// URL to an image showing the product
    /// </summary>
    public string ImageUrl { get; set; }


    /// <summary>
    /// Flag, which indicates that the order item is a pre order. Per default, it is not a pre order.
    /// </summary>
    public bool IsPreOrder { get; set; }


    /// <summary>
    /// Product name
    /// </summary>
    public string @Name { get; set; }


    /// <summary>
    /// URL to the product page
    /// </summary>
    public string ProductUrl { get; set; }


    /// <summary>
    /// The quantity of the order item
    /// </summary>
    public int Quantity { get; set; }


    /// <summary>
    /// Total tax amount of the order item. This tax needs to be included in the UnitPrice and must take the Quantity of the order item into account.
    /// </summary>
    public string TaxAmount { get; set; }


    /// <summary>
    /// Tax rate of the item price in hundredth of a percent. e.g. value 1900 means 19.00%<br/><br/>
    /// Valid values are 0-99999
    /// </summary>
    public string TaxRate { get; set; }


    /// <summary>
    /// Order item type<br/><br/>
    /// <i>Possible values: DIGITAL, PHYSICAL, SERVICE, GIFTCARD, DISCOUNT, SHIPPINGFEE, SALESTAX, SURCHARGE.</i>
    /// </summary>
    public OrderItemTypes Type { get; set; }


    /// <summary>
    /// Price per single item in minor unit (CHF 15.50 ⇒ Value=1550). <strong>Only Integer values will be accepted!</strong>
    /// </summary>
    public string UnitPrice { get; set; }

    [JsonIgnore]
    public decimal UnitPriceValue
    {
        get
        {
            if (int.TryParse(UnitPrice, out int unitPrice))
            {
                return (decimal)unitPrice / 100M;
            }

            return 0M;
        }

        set
        {
            UnitPrice = (value * 100M).ToString("0");
        }
    }


    /// <summary>
    /// Product variant id
    /// </summary>
    public string VariantId { get; set; }


}
