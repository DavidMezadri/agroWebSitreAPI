using agroWebSitreAPI.Domain.DTOs;
using agroWebSitreAPI.Domain.Model.FarmAggregate;

namespace agroWebSitreAPI.Domain.Model.Analysis
{
    public interface IAnalysisRepository
    {
        AnalysisDTO Add(AnalysisDTO analysis);

        List<AnalysisDTO> GetAllAnalysis(int idFarm);


        AnalysisDTO Update(AnalysisDTO analysisDTO);

        AnalysisDTO DeleteAnalysis(int idAnalysis, int idFarm) ;
    }
}

