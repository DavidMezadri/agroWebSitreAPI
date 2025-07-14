namespace agroWebSitreAPI.Domain.DTOs
{
    public class FarmDTO
    {
        public int Id { get; set; }
        public int IdFarm { get; set; }
        public string Name { get; set; }
        public string Farmer { get; set; }
        public DateTime Date { get; set; }
        public float Area { get; set; }
        public string Localize { get; set; }
    }
}
