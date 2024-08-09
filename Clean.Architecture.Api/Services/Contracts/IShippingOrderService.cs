using Clean.Architecture.Application.InputModels;
using Clean.Architecture.Application.ViewModels;

namespace Clean.Architecture.Application.Services.Contracts;

public interface IShippingOrderService
{
    Task<string> Add(AddShippingOrderInputModel model);
    Task<ShippingOrderViewModel> GetByTrackingNumber(string trackingNumber);
}
