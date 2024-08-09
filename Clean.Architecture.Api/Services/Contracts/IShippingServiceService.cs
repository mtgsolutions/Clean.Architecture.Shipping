using Clean.Architecture.Application.ViewModels;

namespace Clean.Architecture.Application.Services.Contracts;

public interface IShippingServiceService
{
    Task<List<ShippingServiceViewModel>> GetAll();
}
