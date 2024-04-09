﻿using System;
using System.Collections.Generic;

namespace WWStyle;

public partial class OrderDetail
{
    public int Odid { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal PricePerUnit { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
