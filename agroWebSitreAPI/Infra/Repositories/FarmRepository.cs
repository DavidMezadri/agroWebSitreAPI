using agroWebSitreAPI.Domain.DTOs;
using agroWebSitreAPI.Domain.Model.FarmAggregate;

namespace agroWebSitreAPI.Infra.Repositories
{
    public class FarmRepository : IFarmRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public void Add(Farm farm)
        {
            _context.Add(farm);
            _context.SaveChanges();
        }

        public FarmDTO Update(FarmDTO farm)
        {
            var farmUpdate = _context.Farm
                .FirstOrDefault(f => f.id == farm.Id && f.id_farm == farm.IdFarm);
            if (farmUpdate == null)
                return null;
            farmUpdate.nameFarm = farm.NameFarm;
            farmUpdate.date = farm.Date;
            farmUpdate.area = farm.Area;
            farmUpdate.localize = farm.Localize;

            _context.Farm.Update(farmUpdate);
            _context.SaveChanges();
            return farm;
        }

        public FarmDTO FindByName(string nameFarm)
        {
            var farm = _context.Farm.FirstOrDefault(u => u.nameFarm == nameFarm);
            return new FarmDTO
            {
                Id = farm.id,
                IdFarm = farm.id_farm,
                NameFarm = farm.nameFarm,
                Date = farm.date,
                Area = farm.area,
                Localize = farm.localize,
            };

        }

        public List<FarmDTO> GetAllFarms(int userId)
        {
            return _context.Farm.Where(f => f.id_farm == userId)
            .Select(b => new FarmDTO()
            {
                    Id = b.id,
                    IdFarm = b.id_farm,
                    NameFarm = b.nameFarm,
                    Date = b.date,
                    Area = b.area,
                    Localize = b.localize,
            }).ToList();
        }

        public FarmDTO DeleteFarm(FarmDTO farm)
        {
            var farmUpdate = _context.Farm
                .FirstOrDefault(f => f.id == farm.Id && f.id_farm == farm.IdFarm);
            if (farmUpdate == null)
            {
                throw new ArgumentNullException(nameof(farmUpdate));
            }
            _context.Farm.Remove(farmUpdate);
            _context.SaveChanges();
            return farm;
        }
    }
}
