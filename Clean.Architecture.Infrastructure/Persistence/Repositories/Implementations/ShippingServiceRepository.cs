using Clean.Architecture.Core.Entities;
using Clean.Architecture.Core.Repositories.Contracts;
using MongoDB.Driver;

namespace Clean.Architecture.Infrastructure.Persistence.Repositories.Implementations;

public class ShippingServiceRepository : IShippingServiceRepository
{
    private readonly IMongoCollection<ShippingService> _shippingServiceCollection;

    public ShippingServiceRepository(IMongoDatabase database)
    {
        _shippingServiceCollection = database.GetCollection<ShippingService>("initiate-shipping-services");
    }

    public async Task AddAsync(ShippingService shippingService)
    {
        await _shippingServiceCollection.InsertOneAsync(shippingService);
    }

    public async Task<bool> DeleteAsync(string title)
    {
        var result = false;
        try
        {
            var shippingServiceDelete = await _shippingServiceCollection.Find(x => x.Title == title).SingleOrDefaultAsync();
            if (shippingServiceDelete == null)
            {
                return result;
            }
            shippingServiceDelete.DeletedDate = DateTime.UtcNow;
            shippingServiceDelete.IsDeleted = true;
            shippingServiceDelete.IsActive = false;

            await _shippingServiceCollection.ReplaceOneAsync(x => x.Title == title, shippingServiceDelete);
            result = true;
        }
        catch(Exception)
        {
            return result;
        }
        return result;
    }

    public async Task<IEnumerable<ShippingService>> GetAllAsync()
    {
        return await _shippingServiceCollection.Find(x => true).ToListAsync();
    }

    public async Task<ShippingService> GetByNameAsync(string title)
    {
        return await _shippingServiceCollection.Find(x => x.Title == title).SingleOrDefaultAsync();
    }

    public async Task<bool> UpdateAsync(ShippingService shippingService)
    {
        var result = false;
        try
        {
            if(shippingService == null)
            {
                return result;
            }
            shippingService.UpdatedDate = DateTime.UtcNow;

            await _shippingServiceCollection.ReplaceOneAsync(x => x.Title == shippingService.Title, shippingService);
            result = true;
        }
        catch(Exception)
        {
            return result;
        }
        return result;
    }
}
