﻿using Clean.Architecture.Core.Entities.Base;

namespace Clean.Architecture.Core.Entities;

public class ShippingOrderService : EntityBase
{
    public ShippingOrderService(string title, decimal price) : base()
    {
        Title = title;
        Price = price;
    }

    public string Title { get; private set; }
    public decimal Price { get; private set; }

}
