using Microsoft.AspNetCore.Mvc;
using Report.Api.Models;

namespace Report.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
    private readonly ILogger<ReportController> _logger;

    public ReportController(ILogger<ReportController> logger)
    {
        _logger = logger;
    }

    [HttpGet("getlocation")]
    public async Task<IActionResult> GetLocationByNumbers()
    {
        return Ok(Enumerable.Empty<LocationNumber>());
    }

    [HttpGet("count/{assetType}")]
    public async Task<IActionResult> GetNumberOfRegistered(AssetType assetType)
    {

        return Ok(default(int));
    }
}
