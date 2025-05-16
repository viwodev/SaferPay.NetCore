using SaferPay.Models.Attributes;

namespace SaferPay.Models.Core;

/// <summary>
/// Represents a customer order containing a collection of order items.
/// </summary>
/// <remarks>
/// The <see cref="Order"/> class is used to manage and process customer orders.  Each order consists of
/// one or more <see cref="OrderItem"/> objects, which represent the individual items in the order.<br/><br/>
/// Update Version : <see langword="1.46"/> <br/>
/// Updated At : <see langword="2025-05-16"/> <br/> 
/// </remarks>
public class Order
{
    /// <summary>
    /// Order items
    /// </summary>
    [Mandatory("Order Items is mandatory!")]
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();


    public void Add(OrderItem item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item), "Item cannot be null.");
        Items.Add(item);
    }

    public void Remove(OrderItem item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item), "Item cannot be null.");
        Items.Remove(item);
    }

    public void Clear()
    {
        Items.Clear();
    }

    public decimal TotalAmount()
    {
        return Items.Sum(item => item.UnitPriceValue * (item.Quantity));
    }
}

