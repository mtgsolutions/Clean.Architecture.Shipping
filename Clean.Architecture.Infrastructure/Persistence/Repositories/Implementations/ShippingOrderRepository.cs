using Clean.Architecture.Core.Entities.Base;
using Clean.Architecture.Core.Repositories.Contracts;
using MongoDB.Driver;

namespace Clean.Architecture.Infrastructure.Persistence.Repositories.Implementations;

public class ShippingOrderRepository : IShippingOrderRepository
{
    private readonly IMongoCollection<ShippingOrder> _shippingOrderCollection;

    public ShippingOrderRepository(IMongoDatabase database)
    {
        _shippingOrderCollection = database.GetCollection<ShippingOrder>("shipping-orders");
    }

    public async Task AddAsync(ShippingOrder shippingOrder)
    {
        await _shippingOrderCollection.InsertOneAsync(shippingOrder);
    }

    public async Task<bool> DeleteAsync(string number)
    {
        var result = false;
        try
        {
            var shippingOrder = await _shippingOrderCollection.Find(x => x.TrackingNumber == number).FirstOrDefaultAsync();
            if(shippingOrder == null)
            {
                return result;
            }
            shippingOrder.DeletedDate = DateTime.UtcNow;
            shippingOrder.IsDeleted = true;
            shippingOrder.IsActive = false;

            await _shippingOrderCollection.ReplaceOneAsync(x => x.TrackingNumber == number, shippingOrder);
            result = true;
        }
        catch(Exception)
        {
            return result;
        }
        return result;
    }

    public async Task<IEnumerable<ShippingOrder>> GetAllAsync()
    {
        return await _shippingOrderCollection.Find(x => true).ToListAsync();
    }

    public async Task<ShippingOrder> GetByTrackingNumberAsync(string number)
    {
        return await _shippingOrderCollection.Find(x => x.TrackingNumber == number).SingleOrDefaultAsync();
    }

    public async Task<bool> UpdateAsync(ShippingOrder shippingOrder)
    {
        var result = false;
        try
        {
            if(shippingOrder == null)
            {
                return result;
            }
            shippingOrder.UpdatedDate = DateTime.UtcNow;

            await _shippingOrderCollection.ReplaceOneAsync(x => x.TrackingNumber == shippingOrder.TrackingNumber, shippingOrder);
            result = true;
        }
        catch(Exception)
        {
            return result;
        }
        return result;
    }
}
