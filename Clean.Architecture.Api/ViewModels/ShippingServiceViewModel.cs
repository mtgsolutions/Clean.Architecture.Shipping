namespace Clean.Architecture.Application.ViewModels;

public class ShippingServiceViewModel
{
    public ShippingServiceViewModel(Guid id, string title, decimal pricePerKilo, decimal fixedPrice)
    {
        Id = id;
        Title = title;
        PricePerKilo = pricePerKilo;
        FixedPrice = fixedPrice;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public decimal PricePerKilo { get; private set; }
    public decimal FixedPrice { get; private set; }

}
