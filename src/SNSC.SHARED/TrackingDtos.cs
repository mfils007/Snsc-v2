using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNSC.SHARED
{
    public class TrackingDtos
    {
        public record TrackingRequest(string NumeroDossier, DateOnly DateNaissance);

        public record TrackingResponse(
            string NumeroDossier,
            string StatutActuel,
            DateTime DerniereMiseAJourUtc,
            IReadOnlyList<TrackingHistoryItem> Historique
        );

        public record TrackingHistoryItem(string Statut, DateTime DateUtc, string? Commentaire);
    }
}
