using agroWebSitreAPI.Application.ViewModel;
using agroWebSitreAPI.Domain.DTOs;
using agroWebSitreAPI.Domain.Model.Analysis;
using agroWebSitreAPI.Domain.Model.FarmAggregate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetResult(int idFarm)
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

            if (_farmRepository.GetAllFarms(userId).FirstOrDefault(f => f.Id == idFarm) == null)
            {
                return BadRequest("Não existe essa fazenda para cadastrar análise!");
            }

            var analysis = _analysisRepository.GetAllAnalysis(idFarm);

            if (analysis == null)
            {
                return BadRequest("Não existe essa fazenda para cadastrar análise!");
            }

            return Ok(analysis);
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
        public IActionResult Put(AnalysisViewModel analysisView)
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
                id = analysisView.id,
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
            }; //alterei agora

            _analysisRepository.Update(analysisDTO);

            return Ok("Usuário editado com seucesso!");
        }
    }

}
