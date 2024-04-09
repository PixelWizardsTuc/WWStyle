using System;
using System.Collections.Generic;

namespace WWStyle;

public partial class Order
{
    public int OrderId { get; set; }

    public string CustomerId { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public DateTime OrderDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
