using Clean.Architecture.Core.Entities.Base;
using Clean.Architecture.Core.Enums;

namespace Clean.Architecture.Application.InputModels;

public class UpdateShippingOrderInputModel
{
    public string TrackingNumber { get; set; }
    public DateTime PostedAt { get; set; }
    public string Description { get; set; }
    public decimal WeightInKg { get; set; }
    public DeliveryAddressInputModel DeliveryAddress { get; set; }
    public ShippingOrderStatus Status { get; set; }
    public decimal TotalPrice { get; set; }
    public List<ShippingServiceInputModel> Services { get; set; }

    public ShippingOrder ToEntity()
        => new ShippingOrder(Description,
            WeightInKg,
            DeliveryAddress.ToValueObject()
        );
}

