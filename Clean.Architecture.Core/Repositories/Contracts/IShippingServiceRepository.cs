using Clean.Architecture.Core.Entities;

namespace Clean.Architecture.Core.Repositories.Contracts;

public interface IShippingServiceRepository
{
    Task<ShippingService> GetByNameAsync(string title);
    Task AddAsync(ShippingService shippingService);
    Task<bool> UpdateAsync(ShippingService shippingService);
    Task<bool> DeleteAsync(string title);
    Task<IEnumerable<ShippingService>> GetAllAsync();
}
