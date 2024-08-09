using Clean.Architecture.Core.Entities;

namespace Clean.Architecture.Application.InputModels
{
    public class ShippingServiceInputModel
    {
        public string Title { get; set; }
        public decimal PricePerKg { get; set; }
        public decimal FixedPrice { get; set; }

        public ShippingService ToEntity()
            => new ShippingService(Title, PricePerKg, FixedPrice);
    }
}
