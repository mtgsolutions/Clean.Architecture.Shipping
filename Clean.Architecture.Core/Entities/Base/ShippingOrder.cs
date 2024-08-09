using Clean.Architecture.Core.Enums;
using Clean.Architecture.Core.ValueObjects;

namespace Clean.Architecture.Core.Entities.Base;

public class ShippingOrder : EntityBase
{
    
    public ShippingOrder(string description, decimal weightInKilo, DeliveryAddress deliveryAddress)
    {
        TrackingNumber = GenerateTrackingNumber();  
        Description = description;
        PostedAt = DateTime.UtcNow;
        WeightInKilo = weightInKilo;
        DeliveryAddress = deliveryAddress;

        Status = ShippingOrderStatus.Started;
        Services = new List<ShippingOrderService>();
    }

    public ShippingOrder(string trackingNumber, string description, DateTime postedAt, decimal weightInKilo, DeliveryAddress deliveryAddress, ShippingOrderStatus status, decimal totalPrice, List<ShippingOrderService> services)
    {
        TrackingNumber = trackingNumber;
        Description = description;
        PostedAt = postedAt;
        WeightInKilo = weightInKilo;
        DeliveryAddress = deliveryAddress;
        Status = status;
        TotalPrice = totalPrice;
        Services = services;
    }

    public string TrackingNumber { get; private set; }
    public string Description { get; private set; }
    public DateTime PostedAt { get; private set; }
    public decimal WeightInKilo { get; private set; }
    public DeliveryAddress DeliveryAddress { get; private set; }
    public ShippingOrderStatus Status { get; private set; }
    public decimal TotalPrice { get; private set; }
    public List<ShippingOrderService> Services { get; private set; }


    public void SetupServices(List<ShippingService> services)
    {
        foreach(var service in services)
        {
            var servicePrice = service.PricePerKilo * WeightInKilo + service.FixedPrice;
            TotalPrice += servicePrice;
            Services.Add(new ShippingOrderService(service.Title, servicePrice));
        }
    }

    private string GenerateTrackingNumber()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string digits = "0123456789";

        var code = new char[10];
        var random = new Random();

        for(int i = 0; i < 2; i++)
        {
            code[i] = chars[random.Next(chars.Length)];
        }

        for(int i = 2; i < 10; i++)
        {
            code[i] = digits[random.Next(digits.Length)];
        }
        return new string(code);
    }
}
