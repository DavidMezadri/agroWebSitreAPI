
using agroWebSitreAPI.Domain.DTOs;

namespace agroWebSitreAPI.Domain.Model.FarmAggregate
{
    public interface IFarmRepository
    {
        void Add(Farm farm);

        List<FarmDTO> GetAllFarms(int id_farm);

        FarmDTO FindByName(string nameFarm);

        FarmDTO Update(FarmDTO farm);

        FarmDTO DeleteFarm(FarmDTO farm);
    }
}
