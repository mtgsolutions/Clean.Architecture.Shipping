using Clean.Architecture.Application.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Clean.ArchitectureApi.Controllers;

[ApiController]
[Route("api/shipping-services")]
public class ShippingServicesController : ControllerBase
{
    private readonly IShippingServiceService _shippingServiceService;

    public ShippingServicesController(IShippingServiceService shippingServiceService)
    {
        _shippingServiceService = shippingServiceService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {

        return await _shippingServiceService.GetAll() switch
        {
            null => NotFound(),
            var shippingServices => Ok(shippingServices)
        };

    }
}
