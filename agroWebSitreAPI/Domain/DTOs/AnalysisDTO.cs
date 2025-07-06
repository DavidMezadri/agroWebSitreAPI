using agroWebSitreAPI.Domain.Model.FarmAggregate;
using System.ComponentModel.DataAnnotations.Schema;

namespace agroWebSitreAPI.Domain.DTOs
{
    public class AnalysisDTO
    {
        public int id { get; set; }
        public int idFarm { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public float currentPh { get; set; }
        public float currentMo { get; set; }
        public float currentCo { get; set; }
        public float currentP { get; set; }
        public float currentK { get; set; }
        public float currentCa { get; set; }
        public float currentMg { get; set; }
        public float currentS { get; set; }
        public float currentB { get; set; }
        public float currentZn { get; set; }
        public float currentCu { get; set; }
        public float currentMn { get; set; }
        public float currentFe { get; set; }
        public float currentAl { get; set; }
        public float currentCtc { get; set; }
        public float currentV { get; set; }
        public float currentHal { get; set; }
        public float missingPh { get; set; }
        public float missingMo { get; set; }
        public float missingCo { get; set; }
        public float missingP { get; set; }
        public float missingK { get; set; }
        public float missingCa { get; set; }
        public float missingMg { get; set; }
        public float missingS { get; set; }
        public float missingB { get; set; }
        public float missingZn { get; set; }
        public float missingCu { get; set; }
        public float missingMn { get; set; }
        public float missingFe { get; set; }
        public float missingAl { get; set; }
        public float missingCtc { get; set; }
        public float missingV { get; set; }
        public float missingHal { get; set; }
    }
}
