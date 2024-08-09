using Clean.Architecture.Core.Entities.Base;

namespace Clean.Architecture.Core.Repositories.Contracts;

public interface IShippingOrderRepository
{
    Task<ShippingOrder> GetByTrackingNumberAsync(string number);
    Task AddAsync(ShippingOrder shippingOrder);
    Task<bool> UpdateAsync(ShippingOrder shippingOrder);
    Task<bool> DeleteAsync(string number);
    Task<IEnumerable<ShippingOrder>> GetAllAsync();
}
