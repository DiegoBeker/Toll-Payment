using Microsoft.AspNetCore.Mvc;
using Toll_Payment.Services;

namespace Toll_Payment.Controllers;

[ApiController]
[Route("health")]
public class HealthController : ControllerBase
{
    private readonly HealthService _healthService;

    public HealthController(HealthService healthService)
    {
        _healthService = healthService;
    }

    [HttpGet]
    public IActionResult GetHealth()
    {
        String message = _healthService.GetHealthMessage();
        return Ok(message);
    }
}