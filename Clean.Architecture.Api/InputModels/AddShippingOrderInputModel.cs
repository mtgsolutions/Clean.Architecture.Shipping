using Clean.Architecture.Core.Entities.Base;

namespace Clean.Architecture.Application.InputModels;

public class AddShippingOrderInputModel
{
    public string Description { get; set; }
    public decimal WeightInKg { get; set; }
    public DeliveryAddressInputModel DeliveryAddress { get; set; }
    public List<ShippingServiceInputModel> Services { get; set; }

    public ShippingOrder ToEntity()
        => new ShippingOrder(
            Description,
            WeightInKg,
            DeliveryAddress.ToValueObject()
        );
}
