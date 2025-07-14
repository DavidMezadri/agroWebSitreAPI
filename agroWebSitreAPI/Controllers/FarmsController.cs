using agroWebSitreAPI.Application.ViewModel;
using agroWebSitreAPI.Domain.DTOs;
using agroWebSitreAPI.Domain.Model.FarmAggregate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace agroWebSitreAPI.Controllers
{
    [ApiController]
    [Route("api/v1/farms")]
    public class FarmsController : ControllerBase
    {
        private readonly IFarmRepository _farmRepository;

        public FarmsController(IFarmRepository farmRepository)
        {
            _farmRepository = farmRepository ?? throw new ArgumentNullException(nameof(farmRepository));
        }


        [Authorize]
        [HttpPost]
        public IActionResult Add(FarmViewModel farmView)
        {
            //Pegando idUsuario do token
            var userIdClaim = User.FindFirst("userId")?.Value;
            if (string.IsNullOrEmpty(userIdClaim))
            {
                return BadRequest("O ID do usuário não foi encontrado no token.");
            }

            if (!int.TryParse(userIdClaim, out var userId))
            {
                return BadRequest("O ID do usuário no token é inválido.");
            }
            //Tratamentos dos dados
            if (string.IsNullOrEmpty(farmView.Name))
            {
                return BadRequest("O Nome da Fazenda é inválido.");
            }

            if (!DateTime.TryParse(farmView.Date, out var parsedDate))
            {
                return BadRequest("A data de criação da Fazenda é inválida.");
            }

            parsedDate = DateTime.SpecifyKind(parsedDate, DateTimeKind.Utc);

            if (!float.TryParse(farmView.Area, out var area) || area <= 0)
            {
                return BadRequest("A área da Fazenda é inválida.");
            }

            if (string.IsNullOrEmpty(farmView.Localize))
            {
                return BadRequest("A localização da Fazenda é inválida.");
            }
            var farm = new Farm(userId, farmView.Name, farmView.Farmer, parsedDate, area, farmView.Localize);
            _farmRepository.Add(farm);
            return Ok("Fazenda cadastrada!");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            //Pegando idUsuario do token
            var userIdClaim = User.FindFirst("userId")?.Value;
            if (string.IsNullOrEmpty(userIdClaim))
            {
                return BadRequest("O ID do usuário não foi encontrado no token.");
            }

            if (!int.TryParse(userIdClaim, out var userId))
            {
                return BadRequest("O ID do usuário no token é inválido.");
            }

            var farms = _farmRepository.GetAllFarms(userId);

            var result = new
            {
                dataTableHeader = new
                {
                    title = "Fazedas Cadastradas",
                    headLabels = new[]
                    {
                        "ID",
                        "Nome da Fazenda",
                        "Propietario",
                        "Data",
                        "Área",
                        "Localização"
                    }
                },
                dataLabelsInfo = farms.Select(farm => new
                {
                    labelInfo = new
                    {
                        id = farm.Id.ToString(),
                        name = farm.Name,
                        farmer = farm.Farmer,
                        date = farm.Date.ToString("yyyy-MM-dd"),
                        area = farm.Area.ToString(),
                        localize = farm.Localize
                    },
                    dataInfoAnalysis = new List<object>()
                })
            };

            return Ok(result);
        }

        [Authorize]
        [HttpPut]
        public IActionResult EditFarm([FromBody] FarmViewModel farmView)
        {
            //Pegando idUsuario do token
            var userIdClaim = User.FindFirst("userId")?.Value;
            if (string.IsNullOrEmpty(userIdClaim))
            {
                return BadRequest("O ID do usuário não foi encontrado no token.");
            }

            if (!int.TryParse(userIdClaim, out var userId))
            {
                return BadRequest("O ID do usuário no token é inválido.");
            }

            var selectFarm = new FarmDTO();
            // Atualiza apenas os campos preenchidos
            if (string.IsNullOrEmpty(farmView.Name))
            {
                return BadRequest("O Nome da Fazenda é inválido.");
            }

            if (!DateTime.TryParse(farmView.Date, out var parsedDate))
            {
                return BadRequest("A data de criação da Fazenda é inválida.");
            }

            parsedDate = DateTime.SpecifyKind(parsedDate, DateTimeKind.Utc);


            if (!float.TryParse(farmView.Area, out var area) || area <= 0)
            {
                return BadRequest("A área da Fazenda é inválida.");
            }


            if (string.IsNullOrEmpty(farmView.Localize))
            {
                return BadRequest("A localização da Fazenda é inválida.");
            }

            selectFarm.Id = farmView.Id;
            selectFarm.IdFarm = userId;
            selectFarm.Name = farmView.Name;
            selectFarm.Farmer = farmView.Farmer;
            selectFarm.Date = parsedDate;
            selectFarm.Area = area;
            selectFarm.Localize = farmView.Localize;

            if (_farmRepository.Update(selectFarm) == null)
            {
                return BadRequest("Fazenda não encotrada.");
            }


            return Ok("Fazenda atualizada com sucesso.");

        }

        [Authorize]
        [HttpDelete]
        public IActionResult DeleteFarm([FromHeader]int id)
        {
            Console.WriteLine(id);
            //Pegando idUsuario do token
            var userIdClaim = User.FindFirst("userId")?.Value;
            if (string.IsNullOrEmpty(userIdClaim))
            {
                return BadRequest("O ID do usuário não foi encontrado no token.");
            }

            if (!int.TryParse(userIdClaim, out var userId))
            {
                return BadRequest("O ID do usuário no token é inválido.");
            }


            if (_farmRepository.DeleteFarm(id, userId) == null)
            {
                return BadRequest("Fazenda não encotrada.");
            }

            return Ok("Fazenda deletada com sucesso.");
        }
    }
}
