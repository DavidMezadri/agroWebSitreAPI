using agroWebSitreAPI.Domain.DTOs;
using agroWebSitreAPI.Domain.Model.FarmAggregate;
using System.Xml.Linq;

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
            farmUpdate.nameFarm = farm.Name;
            farmUpdate.farmer = farm.Farmer;
            farmUpdate.date = farm.Date;
            farmUpdate.area = farm.Area;
            farmUpdate.localize = farm.Localize;

            _context.Farm.Update(farmUpdate);
            _context.SaveChanges();
            return farm;
        }

        public FarmDTO FindByName(string name)
        {
            var farm = _context.Farm.FirstOrDefault(u => u.nameFarm == name);
            return new FarmDTO
            {
                Id = farm.id,
                IdFarm = farm.id_farm,
                Name = farm.nameFarm,
                Farmer = farm.farmer,
                Date = farm.date,
                Area = farm.area,
                Localize = farm.localize,
            };

        }

        public List<FarmDTO> GetAllFarms(int userId)
        {
        var returnFarmList = _context.Farm.Where(f => f.id_farm == userId)
            .Select(b => new FarmDTO()
            {
                    Id = b.id,
                    IdFarm = b.id_farm,
                    Name = b.nameFarm,
                    Farmer = b.farmer,
                    Date = b.date,
                    Area = b.area,
                    Localize = b.localize,
            }).ToList();

        if(returnFarmList == null)
        {
            return null;
        }


        return returnFarmList;
        }

        public FarmDTO DeleteFarm(int id, int IdFarm)
        {
            var farmUpdate = _context.Farm
                .FirstOrDefault(f => f.id == id && f.id_farm == IdFarm);
            if (farmUpdate == null)
            {
                throw new ArgumentNullException(nameof(farmUpdate));
            }

            _context.Farm.Remove(farmUpdate);
            _context.SaveChanges();
            return new FarmDTO
            {
                Id = farmUpdate.id,
                IdFarm = farmUpdate.id_farm,
                Name = farmUpdate.nameFarm,
                Farmer = farmUpdate.farmer,
                Date = farmUpdate.date,
                Area = farmUpdate.area,
                Localize = farmUpdate.localize,
            };
        }
    }
}
