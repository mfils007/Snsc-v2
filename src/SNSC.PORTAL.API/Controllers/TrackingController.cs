using Microsoft.AspNetCore.Mvc;
using SNSC.PORTAL.API.Services;
using SNSC.SHARED;
using static SNSC.SHARED.TrackingDtos;

namespace SNSC.PORTAL.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TrackingController : ControllerBase
{
    private readonly ITrackingProvider _provider;

    public TrackingController(ITrackingProvider provider)
    {
        _provider = provider;
    }

    [HttpPost]
    public async Task<ActionResult<TrackingResponse>> Post([FromBody] TrackingRequest request, CancellationToken ct)
    {
        var result = await _provider.GetStatusAsync(request, ct);
        return result is null ? NotFound() : Ok(result);
    }
}