using agroWebSitreAPI.Domain.DTOs;
using agroWebSitreAPI.Domain.Model.Analysis;
using agroWebSitreAPI.Domain.Model.FarmAggregate;

namespace agroWebSitreAPI.Infra.Repositories
{
    public class AnalysisRepository : IAnalysisRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public AnalysisDTO Add(AnalysisDTO analysisDTO)
        {
            var analysis = new Analysis()
            {
                // --- Dados de Identificação ---
                id = analysisDTO.id,
                idFarm = analysisDTO.idFarm,
                name = analysisDTO.name,
                date = analysisDTO.date,

                // --- Teores Atuais da Análise de Solo ---
                currentPh = analysisDTO.currentPh,
                currentMo = analysisDTO.currentMo, // Matéria Orgânica
                currentP = analysisDTO.currentP,   // Fósforo
                currentK = analysisDTO.currentK,   // Potássio
                currentCa = analysisDTO.currentCa, // Cálcio
                currentMg = analysisDTO.currentMg, // Magnésio
                currentS = analysisDTO.currentS,   // Enxofre
                currentB = analysisDTO.currentB,   // Boro
                currentZn = analysisDTO.currentZn, // Zinco
                currentCu = analysisDTO.currentCu, // Cobre
                currentMn = analysisDTO.currentMn, // Manganês
                currentFe = analysisDTO.currentFe, // Ferro
                currentCo = analysisDTO.currentCo,
                currentAl = analysisDTO.currentAl, // Alumínio
                currentCtc = analysisDTO.currentCtc, // CTC Efetiva
                currentV = analysisDTO.currentV,   // V% (Saturação por Bases)
                currentHal = analysisDTO.currentHal, // H + Al (Acidez Potencial)

                // --- Valores Ideais ou Faltantes para Correção ---
                missingPh = analysisDTO.missingPh,
                missingMo = analysisDTO.missingMo,
                missingP = analysisDTO.missingP,
                missingK = analysisDTO.missingK,
                missingCa = analysisDTO.missingCa,
                missingMg = analysisDTO.missingMg,
                missingS = analysisDTO.missingS,
                missingB = analysisDTO.missingB,
                missingZn = analysisDTO.missingZn,
                missingCu = analysisDTO.missingCu,
                missingMn = analysisDTO.missingMn,
                missingFe = analysisDTO.missingFe,
                missingCo = analysisDTO.missingCo,
                missingAl = analysisDTO.missingAl,
                missingCtc = analysisDTO.missingCtc,
                missingV = analysisDTO.missingV,
                missingHal = analysisDTO.missingHal,
            };

            _context.Add(analysis);
            _context.SaveChanges();
            return analysisDTO;
        }

        public List<AnalysisDTO> GetAllAnalysis(int idFarm)
        {
            var analysis = (_context.Analysis.Where(f => f.idFarm == idFarm)).ToList();

            List<AnalysisDTO> analysisDTO = analysis.Select(farm => new AnalysisDTO
            {
                // --- Dados de Identificação ---
                id = farm.id,
                idFarm = farm.idFarm,
                name = farm.name,
                date = farm.date,

                // --- Teores Atuais da Análise de Solo ---
                currentPh = farm.currentPh,
                currentMo = farm.currentMo, // Matéria Orgânica
                currentP = farm.currentP,   // Fósforo
                currentK = farm.currentK,   // Potássio
                currentCa = farm.currentCa, // Cálcio
                currentMg = farm.currentMg, // Magnésio
                currentS = farm.currentS,   // Enxofre
                currentB = farm.currentB,   // Boro
                currentZn = farm.currentZn, // Zinco
                currentCu = farm.currentCu, // Cobre
                currentMn = farm.currentMn, // Manganês
                currentFe = farm.currentFe, // Ferro
                currentCo = farm.currentCo,
                currentAl = farm.currentAl, // Alumínio
                currentCtc = farm.currentCtc, // CTC Efetiva
                currentV = farm.currentV,   // V% (Saturação por Bases)
                currentHal = farm.currentHal, // H + Al (Acidez Potencial)

                // --- Valores Ideais ou Faltantes para Correção ---
                missingPh = farm.missingPh,
                missingMo = farm.missingMo,
                missingP = farm.missingP,
                missingK = farm.missingK,
                missingCa = farm.missingCa,
                missingMg = farm.missingMg,
                missingS = farm.missingS,
                missingB = farm.missingB,
                missingZn = farm.missingZn,
                missingCu = farm.missingCu,
                missingMn = farm.missingMn,
                missingFe = farm.missingFe,
                missingCo = farm.missingCo,
                missingAl = farm.missingAl,
                missingCtc = farm.missingCtc,
                missingV = farm.missingV,
                missingHal = farm.missingHal,
            }).ToList();

            return analysisDTO;
        }

        public AnalysisDTO DeleteAnalysis(int idAnalysis, int idFarm)
        {

            var removeFarm = _context.Analysis.FirstOrDefault(a => a.id == idAnalysis && a.idFarm == idFarm);
            if (removeFarm != null)
            {
                _context.Analysis.Remove(removeFarm);
                _context.SaveChanges();
                var analysis = new AnalysisDTO()
            {
                // --- Dados de Identificação ---
                id = removeFarm.id,
                idFarm = removeFarm.idFarm,
                name = removeFarm.name,
                date = removeFarm.date,

                // --- Teores Atuais da Análise de Solo ---
                currentPh = removeFarm.currentPh,
                currentMo = removeFarm.currentMo, // Matéria Orgânica
                currentP = removeFarm.currentP,   // Fósforo
                currentK = removeFarm.currentK,   // Potássio
                currentCa = removeFarm.currentCa, // Cálcio
                currentMg = removeFarm.currentMg, // Magnésio
                currentS = removeFarm.currentS,   // Enxofre
                currentB = removeFarm.currentB,   // Boro
                currentZn = removeFarm.currentZn, // Zinco
                currentCu = removeFarm.currentCu, // Cobre
                currentMn = removeFarm.currentMn, // Manganês
                currentFe = removeFarm.currentFe, // Ferro
                currentCo = removeFarm.currentCo,
                currentAl = removeFarm.currentAl, // Alumínio
                currentCtc = removeFarm.currentCtc, // CTC Efetiva
                currentV = removeFarm.currentV,   // V% (Saturação por Bases)
                currentHal = removeFarm.currentHal, // H + Al (Acidez Potencial)

                // --- Valores Ideais ou Faltantes para Correção ---
                missingPh = removeFarm.missingPh,
                missingMo = removeFarm.missingMo,
                missingP = removeFarm.missingP,
                missingK = removeFarm.missingK,
                missingCa = removeFarm.missingCa,
                missingMg = removeFarm.missingMg,
                missingS = removeFarm.missingS,
                missingB = removeFarm.missingB,
                missingZn = removeFarm.missingZn,
                missingCu = removeFarm.missingCu,
                missingMn = removeFarm.missingMn,
                missingFe = removeFarm.missingFe,
                missingCo = removeFarm.missingCo,
                missingAl = removeFarm.missingAl,
                missingCtc = removeFarm.missingCtc,
                missingV = removeFarm.missingV,
                missingHal = removeFarm.missingHal,
            };
                return analysis;
            }
            return null;
        }

        public AnalysisDTO Update(AnalysisDTO analysisDTO)
        {
            var analysis = _context.Analysis.FirstOrDefault(a => a.id == analysisDTO.id && a.idFarm == analysisDTO.idFarm);
            if(analysis == null)
            {
                return null;
            }

            // --- Dados de Identificação ---
            analysis.name = analysisDTO.name;
            analysis.date = analysisDTO.date;

            // --- Teores Atuais da Análise de Solo ---
            analysis.currentPh = analysisDTO.currentPh;
            analysis.currentMo = analysisDTO.currentMo; // Matéria Orgânica
            analysis.currentP = analysisDTO.currentP;   // Fósforo
            analysis.currentK = analysisDTO.currentK;   // Potássio
            analysis.currentCa = analysisDTO.currentCa; // Cálcio
            analysis.currentMg = analysisDTO.currentMg; // Magnésio
            analysis.currentS = analysisDTO.currentS;   // Enxofre
            analysis.currentB = analysisDTO.currentB;   // Boro
            analysis.currentZn = analysisDTO.currentZn; // Zinco
            analysis.currentCu = analysisDTO.currentCu; // Cobre
            analysis.currentMn = analysisDTO.currentMn; // Manganês
            analysis.currentFe = analysisDTO.currentFe; // Ferro
            analysis.currentCo = analysisDTO.currentCo;
            analysis.currentAl = analysisDTO.currentAl; // Alumínio
            analysis.currentCtc = analysisDTO.currentCtc; // CTC Efetiva
            analysis.currentV = analysisDTO.currentV;   // V% (Saturação por Bases)
            analysis.currentHal = analysisDTO.currentHal; // H + Al (Acidez Potencial)

            // --- Valores Ideais ou Faltantes para Correção ---
            analysis.missingPh = analysisDTO.missingPh;
            analysis.missingMo = analysisDTO.missingMo;
            analysis.missingP = analysisDTO.missingP;
            analysis.missingK = analysisDTO.missingK;
            analysis.missingCa = analysisDTO.missingCa;
            analysis.missingMg = analysisDTO.missingMg;
            analysis.missingS = analysisDTO.missingS;
            analysis.missingB = analysisDTO.missingB;
            analysis.missingZn = analysisDTO.missingZn;
            analysis.missingCu = analysisDTO.missingCu;
            analysis.missingMn = analysisDTO.missingMn;
            analysis.missingFe = analysisDTO.missingFe;
            analysis.missingCo = analysisDTO.missingCo;
            analysis.missingAl = analysisDTO.missingAl;
            analysis.missingCtc = analysisDTO.missingCtc;
            analysis.missingV = analysisDTO.missingV;
            analysis.missingHal = analysisDTO.missingHal;

           

            _context.Analysis.Update(analysis);
            _context.SaveChanges();

            return analysisDTO;
        }
    }
}
