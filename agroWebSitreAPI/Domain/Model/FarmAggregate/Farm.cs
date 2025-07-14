using agroWebSitreAPI.Domain.Model.UserAggregate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace agroWebSitreAPI.Domain.Model.FarmAggregate
{
    [Table("farm")]
    public class Farm
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("User")]
        public int id_farm { get; set; } //cahve estrageira do id do usuário
        public User User{ get; set; }
        public string nameFarm { get; set; }
        public DateTime date { get; set; }
        public float area { get; set; }
        public string localize { get; set; }
        public string farmer { get; set; }



        public Farm(int id_farm, string nameFarm, string farmer, DateTime date, float area, string localize)
        {
            this.id_farm = id_farm;
            this.nameFarm = nameFarm;
            this.date = date;
            this.area = area;
            this.localize = localize;
            this.farmer = farmer;
        }
        public Farm() { }
    }


}
