using Clean.Architecture.Application.InputModels;
using Clean.Architecture.Application.Services.Contracts;
using Clean.Architecture.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Clean.ArchitectureApi.Controllers;

[ApiController]
[Route("api/shipping-orders")]
public class ShippingOrdersController : ControllerBase
{
    private readonly IShippingOrderService _shippingOrderService;

    public ShippingOrdersController(IShippingOrderService shippingOrderService)
    {
        _shippingOrderService = shippingOrderService;
    }

    [HttpGet("{code}")]
    public async Task<IActionResult> GetByTrackingNumber(string code)
    {
        return await _shippingOrderService.GetByTrackingNumber(code) switch
        {
            null => NotFound(),
            var shippingOrder => Ok(shippingOrder)
        };
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddShippingOrderInputModel model)
    {
        var code = await _shippingOrderService.Add(model);
        return CreatedAtAction(nameof(GetByTrackingNumber), new { code }, model);
    }
}
