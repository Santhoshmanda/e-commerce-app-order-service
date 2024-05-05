using System;
using System.Collections.Generic;

namespace OGANI.OrderService.Domain.Models;

public partial class OrderStatus
{
    public int OrderStatusId { get; set; }

    public string? StatusName { get; set; }

    public int OrderId { get; set; }

    //public virtual Order Order { get; set; } = null!;
}
