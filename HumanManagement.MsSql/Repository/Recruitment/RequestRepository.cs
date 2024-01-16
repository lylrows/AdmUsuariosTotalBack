using HumanManagement.Domain.Recruitment.Contracts;
using HumanManagement.Domain.Recruitment.Dto;

using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using System.Linq;

using HumanManagement.Domain.Recruitment.QueryFilter;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Common;
using Dapper;
using System.Data;
using HumanManagement.Domain.Utils.Dto;

namespace HumanManagement.MsSql.Repository.Recruitment
{
    public class RequestRepository : IRequestRepository
    {
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        public RequestRepository(IHumanManagementReadDbConnection humanManagementReadDbConnection)
        {
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
        }
        public async Task<ResultPaginationListDto<ListRequestDto>> GetListRequestPagination(RequestQueryFilter contactQueryFilter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nidbussines", contactQueryFilter.nidbussines);
            queryParameters.Add("@dateStart", contactQueryFilter.dateStart);
            queryParameters.Add("@dateEnd", contactQueryFilter.dateEnd);
            queryParameters.Add("@nidarea", contactQueryFilter.nidarea);
            queryParameters.Add("@scharge", contactQueryFilter.scharge);
            queryParameters.Add("@nstate", contactQueryFilter.State);
            queryParameters.Add("@flat", contactQueryFilter.flat);
            queryParameters.Add("@nid_applicant", contactQueryFilter.nid_applicant);
            queryParameters.Add("@ntype_filter", contactQueryFilter.ntype_filter);
            queryParameters.Add("@type", contactQueryFilter.type);
            queryParameters.Add("@nuserregister", contactQueryFilter.nuserregister);
            queryParameters.Add("@ncurrentpage", contactQueryFilter.CurrentPage);
            queryParameters.Add("@nitemsperPage", contactQueryFilter.ItemsPerPage);
            queryParameters.Add("@nrecordcount", DbType.Int32, direction: ParameterDirection.Output);

            var listContacts = await humanManagementReadDbConnection.QueryAsync<ListRequestDto>(
                 "sps_request_pagination",
                 queryParameters, commandType: CommandType.StoredProcedure);


            ResultPaginationListDto<ListRequestDto> result = new ResultPaginationListDto<ListRequestDto>();
            result.list = listContacts.ToList();

            result.TotalItems = Convert.ToInt32(queryParameters.Get<int>("@nrecordcount"));
            result.TotalPages = (int)Math.Ceiling((double)result.TotalItems / contactQueryFilter.ItemsPerPage);

            return result;
        }
        public async Task<int> AddRequest(RequestDto requestQueryFilter)
        {
            var queryParameters = new DynamicParameters();
            var queryParameters2 = new DynamicParameters();
            var queryParameters3 = new DynamicParameters();
            var queryParameters4 = new DynamicParameters();
            var queryParametersDeleteLanguages = new DynamicParameters();
            var queryParametersDeletePregrados = new DynamicParameters();
            var queryParametersDeletePostGrados = new DynamicParameters();

            queryParameters.Add("@nid_request_edit", requestQueryFilter.IdRequest);
            queryParameters.Add("@nid_employment_edit", requestQueryFilter.IdEmployment);
            queryParameters.Add("@nid_company", requestQueryFilter.IdCompany);
            queryParameters.Add("@nid_applicant", requestQueryFilter.IdApplicant);
            queryParameters.Add("@nid_typerequest", requestQueryFilter.IdTypeRequest);
            queryParameters.Add("@nid_replacement_employee", requestQueryFilter.nid_replacement_employee);
            queryParameters.Add("@nid_category", requestQueryFilter.IdCategory);

            queryParameters.Add("@ntimetyperequest", requestQueryFilter.ntimetyperequest);
            queryParameters.Add("@sjustification", requestQueryFilter.sjustification);
            queryParameters.Add("@nminimumage", requestQueryFilter.nminimumage);
            queryParameters.Add("@nmaximumage", requestQueryFilter.nmaximumage);
            queryParameters.Add("@nid_sex", requestQueryFilter.nid_sex);
            queryParameters.Add("@nid_englishexp", requestQueryFilter.nid_englishexp);
            queryParameters.Add("@banotherlanguage", requestQueryFilter.banotherlanguage);
            queryParameters.Add("@sanotherlanguagename", requestQueryFilter.sanotherlanguagename);
            queryParameters.Add("@nid_academiclevel", requestQueryFilter.nid_academiclevel);
            queryParameters.Add("@sotheracademiclevel", requestQueryFilter.sotheracademiclevel);
            queryParameters.Add("@specialtyrequired", requestQueryFilter.specialtyrequired);
            queryParameters.Add("@sotherspecialty", requestQueryFilter.sotherspecialty);
            queryParameters.Add("@sknowledge", requestQueryFilter.sknowledge);
            queryParameters.Add("@sabilities", requestQueryFilter.sabilities);
            queryParameters.Add("@sfunctions", requestQueryFilter.sfunctions);
            queryParameters.Add("@schedule", requestQueryFilter.schedule);
            queryParameters.Add("@nid_worksystem", requestQueryFilter.nid_worksystem);
            queryParameters.Add("@nid_modalitycontracting", requestQueryFilter.nid_modalitycontracting);
            queryParameters.Add("@ncontracttime", requestQueryFilter.ncontracttime);
            queryParameters.Add("@nsalaryemployment", requestQueryFilter.nsalaryemployment);
            queryParameters.Add("@nvariableremuneration", requestQueryFilter.nvariableremuneration);
            queryParameters.Add("@nextrahours", requestQueryFilter.nextrahours);
            queryParameters.Add("@scomment", requestQueryFilter.scomment);

            queryParameters.Add("@nstate", requestQueryFilter.State); 
            queryParameters.Add("@nvacancy", requestQueryFilter.Vacancy);

            queryParameters.Add("@nuserregister", requestQueryFilter.UserRegister);
            queryParameters.Add("@snameemployment", requestQueryFilter.Employment);
            queryParameters.Add("@nid_originarea", requestQueryFilter.nid_originarea);
            queryParameters.Add("@nid_nivel", requestQueryFilter.nid_nivel);
            queryParameters.Add("@nid_charge", requestQueryFilter.idcharge);
            queryParameters.Add("@bnewposition", requestQueryFilter.newPosition);
            queryParameters.Add("@sname_newcharge", requestQueryFilter.sname_newcharge);
            queryParameters.Add("@type", requestQueryFilter.ntype);
            queryParameters.Add("@isSuitableForDisabled", requestQueryFilter.isSuitableForDisabled);
            queryParameters.Add("@scareer", requestQueryFilter.scareer);
            queryParameters.Add("@nidgrade", requestQueryFilter.idgrade);
            queryParameters.Add("@nidsede", requestQueryFilter.idsede);
            queryParameters.Add("@scareer_post", requestQueryFilter.scareer_post);
            queryParameters.Add("@idgrade_post", requestQueryFilter.idgrade_post);
            queryParameters.Add("@nid_company_position", requestQueryFilter.nid_company_position);
            queryParameters.Add("@nid_area_position", requestQueryFilter.nid_area_position);
            queryParameters.Add("@nid_location", requestQueryFilter.idlocation);
            queryParameters.Add("@scommentfirstmonth", requestQueryFilter.scommentfirstmonth);
            queryParameters.Add("@scommentfirstyear", requestQueryFilter.scommentfirstyear);
            queryParameters.Add("@nid_request", DbType.Int32, direction: ParameterDirection.Output);

            var queryresult = await humanManagementReadDbConnection.QueryAsync<int>(
                 "spi_request",
                 queryParameters, commandType: CommandType.StoredProcedure);

            int _cod_request = Convert.ToInt32(queryParameters.Get<int>("@nid_request"));

            
            queryParametersDeleteLanguages.Add("@nid_request", _cod_request);
            var queryresultDeleteLanguages = await humanManagementReadDbConnection.QueryAsync<int>("spd_request_lang", queryParametersDeleteLanguages, commandType: CommandType.StoredProcedure);

            queryParametersDeletePregrados.Add("@nid_request", _cod_request);
            var queryresultDeletePregrados = await humanManagementReadDbConnection.QueryAsync<int>("spd_request_pregrado", queryParametersDeleteLanguages, commandType: CommandType.StoredProcedure);

            queryParametersDeletePostGrados.Add("@nid_request", _cod_request);
            var queryresultDeletePostGrados = await humanManagementReadDbConnection.QueryAsync<int>("spd_request_postgrado", queryParametersDeleteLanguages, commandType: CommandType.StoredProcedure);
            
            if (requestQueryFilter.lstLanguages != null)
            {
                for (var i = 0; i < requestQueryFilter.lstLanguages.Count(); i++)
                {
                    
                    queryParameters2.Add("@nid_request", _cod_request);
                    queryParameters2.Add("@slanguage", requestQueryFilter.lstLanguages[i].slanguage);
                    queryParameters2.Add("@snivel", requestQueryFilter.lstLanguages[i].snivel);
                    var queryresult2 = await humanManagementReadDbConnection.QueryAsync<int>(
                         "spi_request_lang",
                         queryParameters2, commandType: CommandType.StoredProcedure);
                }
            }

            if (requestQueryFilter.lstPregrado != null)
            {
                for (var i = 0; i < requestQueryFilter.lstPregrado.Count(); i++)
                {
                    
                    queryParameters3.Add("@nid_request", _cod_request);
                    queryParameters3.Add("@scareer", requestQueryFilter.lstPregrado[i].scareer);
                    queryParameters3.Add("@sgrade", requestQueryFilter.lstPregrado[i].sgrade);
                    queryParameters3.Add("@idgrade", requestQueryFilter.lstPregrado[i].idgrade);
                    var queryresult3 = await humanManagementReadDbConnection.QueryAsync<int>(
                         "spi_request_pregrado",
                         queryParameters3, commandType: CommandType.StoredProcedure);
                }
            }

            if (requestQueryFilter.lstPostgrado != null)
            {
                for (var i = 0; i < requestQueryFilter.lstPostgrado.Count(); i++)
                {
                    
                    queryParameters4.Add("@nid_request", _cod_request);
                    queryParameters4.Add("@scareer", requestQueryFilter.lstPostgrado[i].scareer);
                    queryParameters4.Add("@sgrade", requestQueryFilter.lstPostgrado[i].sgrade);
                    queryParameters4.Add("@idgrade", requestQueryFilter.lstPostgrado[i].idgrade);
                    var queryresult4 = await humanManagementReadDbConnection.QueryAsync<int>(
                         "spi_request_postgrado",
                         queryParameters4, commandType: CommandType.StoredProcedure);
                }
            }

            return  Convert.ToInt32(queryParameters.Get<int>("@nid_request"));
        }
        public async Task<EmployeeChargeDto> GetEmployeeChargeByUser(int idUser)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nuser", idUser);

            var queryresult = await humanManagementReadDbConnection.QueryAsync<EmployeeChargeDto>(
                 "sps_employee_by_user",
                 queryParameters, commandType: CommandType.StoredProcedure);
            EmployeeChargeDto result = new EmployeeChargeDto();
            result = queryresult.SingleOrDefault();

            return result;
        }
        public async Task<IEnumerable<ListRequestFlowDto>> GetRequestFlow(int idRequest)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_request", idRequest);

            var queryresult = await humanManagementReadDbConnection.QueryAsync<ListRequestFlowDto>(
                 "sps_request_flow",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return queryresult.ToList();
        }
        public async Task<int> AddRequestFlow(RequestFlowDto requestQueryFilter)
        {
           
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@nid_request", requestQueryFilter.Id);
                queryParameters.Add("@nid_originarea", requestQueryFilter.IdOriginArea);
                queryParameters.Add("@nid_destinationarea", requestQueryFilter.IdDestinationArea);
                queryParameters.Add("@nstate", requestQueryFilter.State);
                queryParameters.Add("@scomment", requestQueryFilter.Comment);
                queryParameters.Add("@nuserregister", requestQueryFilter.UserRegister);

                var queryresult = await humanManagementReadDbConnection.QueryAsync<int>(
                     "spi_request_flow",
                     queryParameters, commandType: CommandType.StoredProcedure);

                return queryresult.SingleOrDefault();
          
        }
        public async Task<int> UpdateRequest(RequestUpdatedDto requestQueryFilter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_request", requestQueryFilter.Id);
            queryParameters.Add("@nstate", requestQueryFilter.State);
            queryParameters.Add("@ncontracttime", requestQueryFilter.ContractTime);
            queryParameters.Add("@nvacancy", requestQueryFilter.Vacancy);
            queryParameters.Add("@nuserregister", requestQueryFilter.UserRegister);
            queryParameters.Add("@snameemployment", requestQueryFilter.Employment);
            queryParameters.Add("@sdescriptionemployment", requestQueryFilter.DescriptionEmployment);
            queryParameters.Add("@srequirementsemployment", requestQueryFilter.Requirements);
            queryParameters.Add("@sfunctionsemployment", requestQueryFilter.Functions);
            queryParameters.Add("@nsalaryemployment", requestQueryFilter.Salary);
            queryParameters.Add("@level", requestQueryFilter.Level);
            queryParameters.Add("@nid_group", requestQueryFilter.IdGroup);
            queryParameters.Add("@ngroosssalary", requestQueryFilter.GroossSalary);
            queryParameters.Add("@nid_profile", requestQueryFilter.IdProfile);
            queryParameters.Add("@nid_charge", requestQueryFilter.IdCharge);
            queryParameters.Add("@nid_area_position", requestQueryFilter.IdAreaPosition);
            queryParameters.Add("@nid_company", requestQueryFilter.IdCompany);

            var queryresult = await humanManagementReadDbConnection.QueryAsync<int>(
                 "spu_request",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return queryresult.SingleOrDefault();
        }

        public async Task<RequestById> GetRequestById(int id)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_request", id);
            var queryresult = await humanManagementReadDbConnection.QueryAsync<RequestById>(
                 "sp_request_byId",
                 queryParameters, commandType: CommandType.StoredProcedure);
            RequestById result = new RequestById();
            result = queryresult.SingleOrDefault();


            var lstLanguages = await humanManagementReadDbConnection.QueryAsync<LanguageSolDto>(
                 "sps_request_byId_lang",
                 queryParameters, commandType: CommandType.StoredProcedure);
            List<LanguageSolDto> result2 = new List<LanguageSolDto>();
            result2 = lstLanguages.ToList();

            var lstPostgrado = await humanManagementReadDbConnection.QueryAsync<PostgradoDto>(
                 "sps_request_byId_postgrado",
                 queryParameters, commandType: CommandType.StoredProcedure);
            List<PostgradoDto> result3 = new List<PostgradoDto>();
            result3 = lstPostgrado.ToList();

            var lstPregrado = await humanManagementReadDbConnection.QueryAsync<PostgradoDto>(
                 "sps_request_byId_pregrado",
                 queryParameters, commandType: CommandType.StoredProcedure);
            List<PostgradoDto> result4 = new List<PostgradoDto>();
            result4 = lstPregrado.ToList();


            if (result != null)
            {
                result.lstLanguages = result2;
                result.lstPostgrado = result3;
                result.lstPregrado = result4;
            }

            return result;

        }

        public async Task<int> UpdateRequestPre(RequestDto requestQueryFilter)
        {
            var queryParameters = new DynamicParameters();
            var queryParametersDeletePregrados = new DynamicParameters();
            var queryParameters1 = new DynamicParameters();
            var queryParametersDeletePostGrados = new DynamicParameters();


            if (requestQueryFilter.lstPregrado != null)
            {

                
                queryParametersDeletePregrados.Add("@nid_request", requestQueryFilter.IdRequest);
                queryParametersDeletePregrados.Add("@optionJob ", requestQueryFilter.optionalJobs);
                queryParametersDeletePregrados.Add("@nid_Job ", requestQueryFilter.nid_job);
                var queryresultDeletePregrados = await humanManagementReadDbConnection.QueryAsync<int>("spd_request_pregrado", queryParametersDeletePregrados, commandType: CommandType.StoredProcedure);
                

                for (var i = 0; i < requestQueryFilter.lstPregrado.Count(); i++)
                {
                    queryParameters.Add("@nid_request", requestQueryFilter.IdRequest);
                    queryParameters.Add("@scareer", requestQueryFilter.lstPregrado[i].scareer);
                    queryParameters.Add("@sgrade", requestQueryFilter.lstPregrado[i].sgrade);
                    queryParameters.Add("@idgrade", requestQueryFilter.lstPregrado[i].idgrade);
                    queryParameters.Add("@optionJob ", requestQueryFilter.optionalJobs);
                    queryParameters.Add("@nid_Job ", requestQueryFilter.nid_job);
                    var queryresult3 = await humanManagementReadDbConnection.QueryAsync<int>(
                         "spi_request_pregrado",
                         queryParameters, commandType: CommandType.StoredProcedure);
                }
            }


            if (requestQueryFilter.lstPostgrado != null)
            {
                
                queryParametersDeletePostGrados.Add("@nid_request", requestQueryFilter.IdRequest);
                queryParametersDeletePostGrados.Add("@optionJob ", requestQueryFilter.optionalJobs);
                queryParametersDeletePostGrados.Add("@nid_Job ", requestQueryFilter.nid_job);
                var queryresultDeletePostGrados = await humanManagementReadDbConnection.QueryAsync<int>("spd_request_postgrado", queryParametersDeletePostGrados, commandType: CommandType.StoredProcedure);
                

                for (var i = 0; i < requestQueryFilter.lstPostgrado.Count(); i++)
                {
                    queryParameters1.Add("@nid_request", requestQueryFilter.IdRequest);
                    queryParameters1.Add("@scareer", requestQueryFilter.lstPostgrado[i].scareer);
                    queryParameters1.Add("@sgrade", requestQueryFilter.lstPostgrado[i].sgrade);
                    queryParameters1.Add("@idgrade", requestQueryFilter.lstPostgrado[i].idgrade);
                    queryParameters1.Add("@optionJob ", requestQueryFilter.optionalJobs);
                    queryParameters1.Add("@nid_Job ", requestQueryFilter.nid_job);
                    var queryresult = await humanManagementReadDbConnection.QueryAsync<int>(
                         "spi_request_postgrado",
                         queryParameters1, commandType: CommandType.StoredProcedure);
                }
            }

            return Convert.ToInt32(queryParameters.Get<int>("@nid_request"));
        }
    }
}
