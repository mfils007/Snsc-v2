using static SNSC.SHARED.TrackingDtos;

namespace SNSC.PORTAL.API.Services
{
    public interface ITrackingProvider
    {
        Task<TrackingResponse?> GetStatusAsync(TrackingRequest request, CancellationToken ct);
    }
}
