using agroWebSitreAPI.Domain.Model.FarmAggregate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace agroWebSitreAPI.Domain.Model.Analysis
{
    [Table("analysis")]
    public class Analysis
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("Farm")]
        public int idFarm { get; set; }
        public Farm Farm { get; set; }
        public string name { get; set; }
		public DateTime date { get; set; }
        //Dados
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
        //Faltante
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



        public Analysis(int id, int idFarm, string name, DateTime date, float currentPh, float currentMo, float currentCo, float currentP, float currentK, float currentCa, float currentMg, float currentS, float currentB, float currentZn, float currentCu, float currentMn, float currentFe, float currentAl, float currentCtc, float currentV, float currentHal, float missingPh, float missingMo, float missingCo, float missingP, float missingK, float missingCa, float missingMg, float missingS, float missingB, float missingZn, float missingCu, float missingMn, float missingFe, float missingAl, float missingCtc, float missingV, float missingHal)
        {
            this.id = id;
            this.idFarm = idFarm;
            this.name = name;
            this.date = date;
            this.currentPh = currentPh;
            this.currentMo = currentMo;
            this.currentCo = currentCo;
            this.currentP = currentP;
            this.currentK = currentK;
            this.currentCa = currentCa;
            this.currentMg = currentMg;
            this.currentS = currentS;
            this.currentB = currentB;
            this.currentZn = currentZn;
            this.currentCu = currentCu;
            this.currentMn = currentMn;
            this.currentFe = currentFe;
            this.currentAl = currentAl;
            this.currentCtc = currentCtc;
            this.currentV = currentV;
            this.currentHal = currentHal;
            this.missingPh = missingPh;
            this.missingMo = missingMo;
            this.missingCo = missingCo;
            this.missingP = missingP;
            this.missingK = missingK;
            this.missingCa = missingCa;
            this.missingMg = missingMg;
            this.missingS = missingS;
            this.missingB = missingB;
            this.missingZn = missingZn;
            this.missingCu = missingCu;
            this.missingMn = missingMn;
            this.missingFe = missingFe;
            this.missingAl = missingAl;
            this.missingCtc = missingCtc;
            this.missingV = missingV;
            this.missingHal = missingHal;
        }

        public Analysis()
        {
        }
    }
}
