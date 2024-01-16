using Dapper;
using HumanManagement.Application.Response;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.InformationPostulant.Contracts;
using HumanManagement.Domain.InformationPostulant.Dto;
using HumanManagement.MsSql.Context;
using System;

using System.Data;
using System.Linq;

using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository.InformationPostulant
{
    public class InformationPostulantRepository : IInformationPostulantRepository
    {
        private readonly DbContextMsSql context;
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        public InformationPostulantRepository(DbContextMsSql context, IHumanManagementReadDbConnection humanManagementReadDbConnection)
        {
            this.context = context;
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
        }


        public async Task<InformationPostulantRequest> GetInformationPostulantRequest(FilterInformationPostulantRequest filter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_evaluation", filter.IdEvaluation);
            queryParameters.Add("@nid_postulant", filter.IdPostulant);
            queryParameters.Add("@stype", filter.Type);

            var result = await humanManagementReadDbConnection.QueryAsync<InformationPostulantRequest>(
                 "sps_information_postulant_request",
                 queryParameters, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<int> SaveInformationPostulantRequest(InformationPostulantRequest request)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_postulant_request", request.IdPostulantRequest);
            queryParameters.Add("@nid_evaluation", request.IdEvaluation);
            queryParameters.Add("@nid_postulant", request.IdPostulant);
            queryParameters.Add("@stype", request.Type);
            queryParameters.Add("@sfirstname", request.FirstName);
            queryParameters.Add("@ssecondname", request.SecondName);
            queryParameters.Add("@slastname", request.LastName);
            queryParameters.Add("@smotherlastname", request.MotherLastName);
            queryParameters.Add("@ndocument_type", request.DocumentType);
            queryParameters.Add("@sdocument_number", request.DocumentNumber);
            queryParameters.Add("@sbirthdate", Convert.ToDateTime(request.BirthDate));
            queryParameters.Add("@nid_company", request.IdCompany);
            queryParameters.Add("@nid_management", request.IdManagement);
            queryParameters.Add("@nid_area", request.IdArea);
            queryParameters.Add("@nid_subarea", request.IdSubArea);
            queryParameters.Add("@nid_costcenter", request.IdCostCenter);
            queryParameters.Add("@sposition", request.Position);
            
            if (!String.IsNullOrEmpty(request.IncomeDate)) queryParameters.Add("@sincome_date", Convert.ToDateTime(request.IncomeDate));
            if (!String.IsNullOrEmpty(request.EndDate)) queryParameters.Add("@send_date", Convert.ToDateTime(request.EndDate));
            queryParameters.Add("@ncontract_type", request.ContractType);
            queryParameters.Add("@nvacant_type", request.VacantType);
            queryParameters.Add("@sschedule", request.Schedule);
            queryParameters.Add("@sboss", request.Boss);
            queryParameters.Add("@nid_boss", request.IdBoss);
            queryParameters.Add("@nid_category_salary", request.IdSalaryCategory);
            queryParameters.Add("@nid_campus", request.IdCampus);
            queryParameters.Add("@bconfirmed", request.Confirmed);
            queryParameters.Add("@nid_user", request.User);
            var result = await humanManagementReadDbConnection.QueryAsync<Result>(
                "spi_information_postulant_request",
                queryParameters, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault().LastId;
        }

        public async Task<InformationExactusInternalDto> GetInformationInternalExactus(FilterInformationExactusInternalDto filter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_evaluation", filter.IdEvaluation);
            queryParameters.Add("@nid_postulant", filter.IdPostulant);

            var result = await humanManagementReadDbConnection.QueryAsync<InformationExactusInternalDto>(
                 "sps_information_internal_exactus",
                 queryParameters, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<int> SaveInformationInternalExactus(InformationExactusInternalDto request)
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@nid_evaluation", request.IdEvaluation);
                queryParameters.Add("@nid_postulant", request.IdPostulant);
                queryParameters.Add("@sid_nomina", request.IdNomina);
                queryParameters.Add("@sid_ubicacion", request.IdUbicacion);
                queryParameters.Add("@bdescontar_quinta", request.DescontarQuinta);
                queryParameters.Add("@bremuneracion_integral", request.RemuneracionIntegral);
                queryParameters.Add("@nsalary", request.Salary);
                queryParameters.Add("@sschedule", request.Schedule);
                queryParameters.Add("@bafp_mixta", request.AfpMixta);
                queryParameters.Add("@sid_afp", request.IdAfp);
                queryParameters.Add("@scuspp", request.Cuspp);
                if (!String.IsNullOrEmpty(request.FechaInicioCambio)) queryParameters.Add("@dincome_date", Convert.ToDateTime(request.FechaInicioCambio));
                if (!String.IsNullOrEmpty(request.FechaFinCambio)) queryParameters.Add("@dend_date", Convert.ToDateTime(request.FechaFinCambio));
                queryParameters.Add("@bconfirmed", request.Confirmed);
                queryParameters.Add("@nuser", request.User);
                var result = await humanManagementReadDbConnection.QueryAsync<Result>(
                    "spi_information_internal_exactus",
                    queryParameters, commandType: CommandType.StoredProcedure);

                return result.FirstOrDefault().LastId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
