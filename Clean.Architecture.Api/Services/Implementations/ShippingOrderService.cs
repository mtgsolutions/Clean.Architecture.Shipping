using Clean.Architecture.Application.InputModels;
using Clean.Architecture.Application.Services.Contracts;
using Clean.Architecture.Application.ViewModels;
using Clean.Architecture.Core.Entities.Base;
using Clean.Architecture.Core.Repositories.Contracts;
using Clean.Architecture.Core.ValueObjects;
using System.Text.Json;

namespace Clean.Architecture.Application.Services.Implementations;

public class ShippingOrderService : IShippingOrderService
{
    private readonly IShippingOrderRepository _shippingOrderRepository;

    public ShippingOrderService(IShippingOrderRepository shippingOrderRepository)
    {
        _shippingOrderRepository = shippingOrderRepository;
    }

    public async Task<string> Add(AddShippingOrderInputModel model)
    {
        var shippingOrder = model.ToEntity();
        var shippingService = model.Services.Select(s => s.ToEntity()).ToList();
        shippingOrder.SetupServices(shippingService);

        await _shippingOrderRepository.AddAsync(shippingOrder);

        return shippingOrder.TrackingNumber;
    }

    public async Task<ShippingOrderViewModel> GetByTrackingNumber(string trackingNumber)
    {
        var shippingOrder = await _shippingOrderRepository.GetByTrackingNumberAsync(trackingNumber);
        return ShippingOrderViewModel.FromEntity(shippingOrder);

    }
}
