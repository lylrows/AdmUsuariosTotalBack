using HumanManagement.Domain.Cargo.Dto;
using HumanManagement.Domain.Cargo.QueryFilter;
using HumanManagement.Domain.Common;
using HumanManagement.Domain.EvaluationPostulant.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Cargo.Contracts
{
    public interface ICargoRepository
    {
        Task<ResultPaginationListDto<CargoDto>> GetAll(CargoQueryFilter contactQueryFilter);
        Task<List<CargoDto>> GetListCargo();
        Task<List<CargoDto>> GetCargoByEmpresa(FilterCargoDto dto);
        Task<int> GetIdByCode(string codeCharge);
        Task<int> GetJefeByCharge(int IdCharge);
        Task<List<CargoCompetenciaDto>> GetListCompetenciasByCargo(int idRequest, int idCargo, int primeraCarga);
        Task<int> AddCargoConfig(List<CargoCompetenciaDto> competencias);
        Task<int> AddCharge(CargoDto requestQueryFilter);
        Task<List<CargoByCompanyAreaDto>> GetChargesByCompanyArea(ChargesByCompanyAreaFilter chargesByCompanyAreaFilter);
        Task<List<EvaluatorDto>> GetMailsByEvaluation(int idEvaluationPostulant);
        Task<List<EvaluatorDto>> GetMailsByEvaluationInternal(int idEvaluationPostulant);
        Task<List<CargoByCompanyAreaDto>> GetChargesByCompanyAreaMulti(ChargesByCompanyAreaMultiFilter chargesByCompanyAreaFilter);
        Task<List<CargoByCompanyAreaDto>> GetChargesByCompanyAreav2(ChargesByCompanyAreaFilter chargesByCompanyAreaFilter);
    }
}
