using agroWebSitreAPI.Application.ViewModel;
using agroWebSitreAPI.Domain.DTOs;
using agroWebSitreAPI.Domain.Model.Analysis;
using agroWebSitreAPI.Domain.Model.FarmAggregate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace agroWebSitreAPI.Controllers
{
    [ApiController]
    [Route("api/v1/analysis")]
    public class AnalysisController : ControllerBase
    {
        private readonly IAnalysisRepository _analysisRepository;
        private readonly IFarmRepository _farmRepository;

        public AnalysisController(IAnalysisRepository analysisRepository, IFarmRepository farmRepository)
        {
            _farmRepository = farmRepository ?? throw new ArgumentNullException(nameof(farmRepository));
            _analysisRepository = analysisRepository ?? throw new ArgumentNullException(nameof(analysisRepository));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(AnalysisViewModel analysisView)
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

            if (_farmRepository.GetAllFarms(userId).FirstOrDefault(f => f.Id == analysisView.idFarm) == null)
            {
                return BadRequest("Não existe essa fazenda para cadastrar análise!");
            }

            if (!DateTime.TryParse(analysisView.date, out var parsedDate))
            {
                return BadRequest("A data de criação da Fazenda é inválida.");
            }

            parsedDate = DateTime.SpecifyKind(parsedDate, DateTimeKind.Utc);

            var analysisDTO = new AnalysisDTO()
            {
                idFarm = analysisView.idFarm,
                date = parsedDate,
                name = analysisView.name,
                currentPh = float.Parse(analysisView.currentPh),
                currentMo = float.Parse(analysisView.currentMo),
                currentCo = float.Parse(analysisView.currentCo),
                currentP = float.Parse(analysisView.currentP),
                currentK = float.Parse(analysisView.currentK),
                currentCa = float.Parse(analysisView.currentCa),
                currentMg = float.Parse(analysisView.currentMg),
                currentS = float.Parse(analysisView.currentS),
                currentB = float.Parse(analysisView.currentB),
                currentZn = float.Parse(analysisView.currentZn),
                currentCu = float.Parse(analysisView.currentCu),
                currentMn = float.Parse(analysisView.currentMn),
                currentFe = float.Parse(analysisView.currentFe),
                currentAl = float.Parse(analysisView.currentAl),
                currentCtc = float.Parse(analysisView.currentCtc),
                currentV = float.Parse(analysisView.currentV),
                currentHal = float.Parse(analysisView.currentHal),

                missingPh = float.Parse(analysisView.currentPh) + 5.0f,
                missingMo = float.Parse(analysisView.currentMo) + 5.0f,
                missingCo = float.Parse(analysisView.currentCo) + 5.0f,
                missingP = float.Parse(analysisView.currentP) + 5.0f,
                missingK = float.Parse(analysisView.currentK) + 5.0f,
                missingCa = float.Parse(analysisView.currentCa) + 5.0f,
                missingMg = float.Parse(analysisView.currentMg) + 5.0f,
                missingS = float.Parse(analysisView.currentS) + 5.0f,
                missingB = float.Parse(analysisView.currentB) + 5.0f,
                missingZn = float.Parse(analysisView.currentZn) + 5.0f,
                missingCu = float.Parse(analysisView.currentCu) + 5.0f,
                missingMn = float.Parse(analysisView.currentMn) + 5.0f,
                missingFe = float.Parse(analysisView.currentFe) + 5.0f,
                missingAl = float.Parse(analysisView.currentAl) + 5.0f,
                missingCtc = float.Parse(analysisView.currentCtc) + 5.0f,
                missingV = float.Parse(analysisView.currentV) + 5.0f,
                missingHal = float.Parse(analysisView.currentHal) + 5.0f,
            };

            if (_analysisRepository.Add(analysisDTO) == null)
            {
                return BadRequest("Análise não adicionada!");
            }

            return Ok("Análise adicionada!");
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetResult([FromQuery] string idFarm)
        {
            int idFarmInt = int.Parse(idFarm);
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

            if (_farmRepository.GetAllFarms(userId).FirstOrDefault(f => f.Id == idFarmInt) == null)
            {
                return BadRequest("Não existe essa fazenda para cadastrar análise!");
            }

            var analysis = _analysisRepository.GetAllAnalysis(idFarmInt);

            if (analysis == null)
            {
                return BadRequest("Não existe essa fazenda para cadastrar análise!");
            }


            var dataLabelsInfo = analysis.Select(analyse => new
            {
                labelInfo = new
                {
                    id = analyse.id.ToString(),
                    name = analyse.name,
                    date = analyse.date.ToString("yyyy-MM-dd")
                },
                dataInfoAnalysis = new[]
                {
                    new { element = "pH", current = analyse.currentPh, missing = analyse.missingPh },
                    new { element = "MO", current = analyse.currentMo, missing = analyse.missingMo },
                    new { element = "CO", current = analyse.currentCo, missing = analyse.missingCo },
                    new { element = "P", current = analyse.currentP, missing = analyse.missingP },
                    new { element = "K", current = analyse.currentK, missing = analyse.missingK },
                    new { element = "Ca", current = analyse.currentCa, missing = analyse.missingCa},
                    new { element = "Mg", current = analyse.currentMg, missing = analyse.missingMg},
                    new { element = "S", current = analyse.currentS, missing = analyse.missingS},
                    new { element = "B", current = analyse.currentB, missing = analyse.missingB},
                    new { element = "Zn", current = analyse.currentZn, missing = analyse.missingZn},
                    new { element = "Cu", current = analyse.currentCu, missing = analyse.missingCu},
                    new { element = "Mn", current = analyse.currentMn, missing = analyse.missingMn},
                    new { element = "Fe", current = analyse.currentFe, missing = analyse.missingFe},
                    new { element = "Al", current = analyse.currentAl, missing = analyse.missingAl},
                    new { element = "CTC", current = analyse.currentCtc, missing = analyse.missingCtc},
                    new { element = "V%", current = analyse.currentV, missing = analyse.missingV},
                    new { element = "H+Al", current = analyse.currentHal, missing = analyse.missingHal}
                }}).ToList();

            var result = new
            {
                dataTableHeader = new
                {
                    title = "Lista de Análises",
                    headLabels = new[] { "Número ID", "Name da Amostra", "Data" }
                },
                dataLabelsInfo = dataLabelsInfo
            };

            return Ok(result);
        }

        [Authorize]
        [HttpDelete]
        public IActionResult Delete(int idAnalysis, int idFarm)
        {
            var userIdClaim = User.FindFirst("userId")?.Value;
            if (string.IsNullOrEmpty(userIdClaim))
            {
                return BadRequest("O ID do usuário não foi encontrado no token.");
            }

            if (!int.TryParse(userIdClaim, out var userId))
            {
                return BadRequest("O ID do usuário no token é inválido.");
            }

            if (_farmRepository.GetAllFarms(userId).FirstOrDefault(f => f.IdFarm == idFarm) == null)
            {
                return BadRequest("Não existe essa fazenda para excluir análise!");
            }
            var analysis = _analysisRepository.DeleteAnalysis(idAnalysis, idFarm);
            if (analysis == null)
            {
                return BadRequest("Análise náo encontrada para exclusão!");
            }

            return Ok("Análise excluida!");
        }


        [Authorize]
        [HttpPut]
        public IActionResult Put(AnalysisViewModelPut analysisView)
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

            if (!DateTime.TryParse(analysisView.Data, out var parsedDate))
            {
                return BadRequest("A data de criação da Fazenda é inválida.");
            }

            parsedDate = DateTime.SpecifyKind(parsedDate, DateTimeKind.Utc);



            var analysisDTO = new AnalysisDTO()
            {
                id = int.Parse(analysisView.ID),
                date = parsedDate,
                name = analysisView.Nome,
                currentPh = float.Parse(analysisView.pH),
                currentMo = float.Parse(analysisView.MO),
                currentCo = float.Parse(analysisView.CO),
                currentP = float.Parse(analysisView.P),
                currentK = float.Parse(analysisView.K),
                currentCa = float.Parse(analysisView.Ca),
                currentMg = float.Parse(analysisView.Mg),
                currentS = float.Parse(analysisView.S),
                currentB = float.Parse(analysisView.B),
                currentZn = float.Parse(analysisView.Zn),
                currentCu = float.Parse(analysisView.Cu),
                currentMn = float.Parse(analysisView.Mn),
                currentFe = float.Parse(analysisView.Fe),
                currentAl = float.Parse(analysisView.Al),
                currentCtc = float.Parse(analysisView.CTC),
                currentV = float.Parse(analysisView.V_),
                currentHal = float.Parse(analysisView.H_Al),

                missingPh = float.Parse(analysisView.pH) + 5.0f,
                missingMo = float.Parse(analysisView.MO) + 5.0f,
                missingCo = float.Parse(analysisView.CO) + 5.0f,
                missingP = float.Parse(analysisView.P) + 5.0f,
                missingK = float.Parse(analysisView.K) + 5.0f,
                missingCa = float.Parse(analysisView.Ca) + 5.0f,
                missingMg = float.Parse(analysisView.Mg) + 5.0f,
                missingS = float.Parse(analysisView.S) + 5.0f,
                missingB = float.Parse(analysisView.B) + 5.0f,
                missingZn = float.Parse(analysisView.Zn) + 5.0f,
                missingCu = float.Parse(analysisView.Cu) + 5.0f,
                missingMn = float.Parse(analysisView.Mn) + 5.0f,
                missingFe = float.Parse(analysisView.Fe) + 5.0f,
                missingAl = float.Parse(analysisView.Al) + 5.0f,
                missingCtc = float.Parse(analysisView.CTC) + 5.0f,
                missingV = float.Parse(analysisView.V_) + 5.0f,
                missingHal = float.Parse(analysisView.H_Al) + 5.0f,
            }; //alterei agora

            _analysisRepository.Update(analysisDTO);

            return Ok("Usuário editado com seucesso!");
        }
    }

}
