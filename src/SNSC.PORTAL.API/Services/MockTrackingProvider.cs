using static SNSC.SHARED.TrackingDtos;

namespace SNSC.PORTAL.API.Services
{
    public class MockTrackingProvider : ITrackingProvider
    {
        private static readonly Random Rng = new();

        public Task<TrackingResponse?> GetStatusAsync(TrackingRequest request, CancellationToken ct)
        {
            if (string.IsNullOrWhiteSpace(request.NumeroDossier) || request.NumeroDossier.Trim().Length < 6)
                return Task.FromResult<TrackingResponse?>(null);

            var steps = new[]
            {
            "Dossier reçu",
            "Vérification en cours",
            "Biométrie validée",
            "Production en cours",
            "Impression",
            "Disponible pour retrait"
        };

            var maxStep = Rng.Next(0, steps.Length);
            var now = DateTime.UtcNow;

            var history = new List<TrackingHistoryItem>();
            for (int i = 0; i <= maxStep; i++)
            {
                history.Add(new TrackingHistoryItem(
                    steps[i],
                    now.AddDays(-(maxStep - i)),
                    i == 1 ? "Dossier en validation" : null
                ));
            }

            return Task.FromResult<TrackingResponse?>(new TrackingResponse(
                request.NumeroDossier.Trim(),
                steps[maxStep],
                history.Max(h => h.DateUtc),
                history.OrderByDescending(h => h.DateUtc).ToList()
            ));
        }
    }
}
