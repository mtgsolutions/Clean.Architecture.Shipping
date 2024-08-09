using Clean.Architecture.Application.Services.Contracts;
using Clean.Architecture.Application.ViewModels;
using Clean.Architecture.Core.Entities;
using Clean.Architecture.Core.Repositories.Contracts;

namespace Clean.Architecture.Application.Services.Implementations;

public class ShippingServiceService : IShippingServiceService
{
    private readonly IShippingServiceRepository _shippingServiceRepository;

    public ShippingServiceService(IShippingServiceRepository shippingServiceRepository)
    {
        _shippingServiceRepository = shippingServiceRepository;
    }

    public async Task<List<ShippingServiceViewModel>> GetAll()
    {

        var shippingServices = await _shippingServiceRepository.GetAllAsync();

        return shippingServices.Select( s => new ShippingServiceViewModel(s.Id,s.Title, s.FixedPrice, s.PricePerKilo)).ToList();
    }
}
