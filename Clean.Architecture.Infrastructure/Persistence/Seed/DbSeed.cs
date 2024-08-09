using Clean.Architecture.Core.Entities;
using MongoDB.Driver;

namespace Clean.Architecture.Infrastructure.Persistence.Seed;

public class DbSeed
{
    private readonly IMongoCollection<ShippingService> _shippingServiceCollection;

    public DbSeed(IMongoDatabase database)
    {
        _shippingServiceCollection = database.GetCollection<ShippingService>("initiate-shipping-services");
    }
    private List<ShippingService> _shippingService = new List<ShippingService>
    {
        new("DHL",4.75m,40),
        new("Fedex",5.25m,50),
        new("UPS",5.75m,60),

    };

    public void Seed()
    {
        if(!_shippingServiceCollection.Find(x => true).Any())
        {
            _shippingServiceCollection.InsertMany(_shippingService);
        }
    }
}
