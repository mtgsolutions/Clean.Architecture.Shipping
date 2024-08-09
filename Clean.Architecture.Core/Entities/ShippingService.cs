using Clean.Architecture.Core.Entities.Base;

namespace Clean.Architecture.Core.Entities;

public class ShippingService : EntityBase
{
    public ShippingService(string title, decimal pricePerKilo, decimal fixedPrice): base()
    {
        Title = title;
        PricePerKilo = pricePerKilo;
        FixedPrice = fixedPrice;
    }
    public string Title { get; private set; }
    public decimal PricePerKilo { get; private set; }
    public decimal FixedPrice { get; private set; }

}
