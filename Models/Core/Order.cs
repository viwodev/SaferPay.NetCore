using SaferPay.Enums;

namespace SaferPay.Models.Core;

public class Order
{
    /// <summary>
    /// Order items
    /// </summary>
    public List<OrderItem> Items { get; set; }
}

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
    /// Price per single item in minor unit (CHF 15.50 ⇒ Value=1550). Only Integer values will be accepted!
    /// </summary>
    public string UnitPrice { get; set; }


    /// <summary>
    /// Product variant id
    /// </summary>
    public string VariantId { get; set; }


}
