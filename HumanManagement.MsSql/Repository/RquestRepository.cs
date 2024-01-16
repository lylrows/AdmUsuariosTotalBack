using Dapper;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Common;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Employee.Contracts;
using HumanManagement.Domain.Employee.Dto;

using HumanManagement.Domain.Security.QueryFilter;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository
{
    public class RquestRepository : IRquestRepository
    {
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        private readonly AppSettings _appSettings;
        private readonly ILogger<RquestRepository> _logger;

        public RquestRepository(IHumanManagementReadDbConnection humanManagementReadDbConnection, IOptions<AppSettings> appSettings, ILogger<RquestRepository> logger)
        {
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
            this._appSettings = appSettings.Value;
            this._logger = logger;
        }

        public async Task AcceptRequest(AcceptRequest request)
        {
            var queryParameters = new DynamicParameters();
            _logger.LogInformation("nid_request: " + request.nid_request.ToString());
            queryParameters.Add("@nid_request", request.nid_request);


            var management = await humanManagementReadDbConnection.QueryAsync<ListPositionComboDto>(
                 "staff.sp_request_accept",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<GetPersonByRolAdminPersnDto>> GetPersonByAdminPerson()
        {
            var list = await humanManagementReadDbConnection.QueryAsync<GetPersonByRolAdminPersnDto>(
                 "sp_personAdminPersonal_list",
                 commandType: CommandType.StoredProcedure);

            _logger.LogInformation("GetPersonByAdminPerson: " + list);
            return list.ToList();
        }

        public async Task<int> InsertRequestDocument(InsertRequestDocumentDto payload)
        {
            var queryParameters = new DynamicParameters();
            _logger.LogInformation("nid_collaborador: " + payload.nid_collaborador);
            _logger.LogInformation("nyear: " + payload.nyear);
            _logger.LogInformation("nmonth: " + payload.nmonth);
            _logger.LogInformation("ntypeseccion: " + payload.ntypeseccion);

            queryParameters.Add("@nid_collaborador", payload.nid_collaborador);
            queryParameters.Add("@nyear", payload.nyear);
            queryParameters.Add("@nmonth", payload.nmonth);
            queryParameters.Add("@ntypeseccion", payload.ntypeseccion);
            
            var management = await humanManagementReadDbConnection.QueryAsync<ListPositionComboDto>(
                 "staff.sp_request_ins_document",
                 queryParameters, commandType: CommandType.StoredProcedure);

            _logger.LogInformation("management: " + management);
            _logger.LogInformation("nid_request: " + management.ToList().FirstOrDefault().nid_request);

            return management.ToList().FirstOrDefault().nid_request;
        }

        public async Task<int> InsertRequestEmployee(RequestInsDto request, IFormFile file)
        {
            var urlhost = _appSettings.PathSaveFile;
            int result = 0;
            var Folder = "";
            if (file != null)
            {
                var filenamefolder = Path.Combine(urlhost, "File");
                var Name = file.FileName;
                Folder = filenamefolder + file.FileName;

                if (!Directory.Exists(filenamefolder))
                {
                    Directory.CreateDirectory(filenamefolder);
                }

                using (var stream = new FileStream(Folder, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_typerequest", request.nid_typerequest);
            queryParameters.Add("@nid_collaborator", request.nid_collaborator);
            queryParameters.Add("@description", request.description);

            queryParameters.Add("@nid_address", request.nid_address);
            queryParameters.Add("@saddress", request.saddress);
            queryParameters.Add("@nid_district", request.nid_district);
            queryParameters.Add("@nid_phone", request.nid_phone);

            queryParameters.Add("@phone", request.phone);
            queryParameters.Add("@nid_statecivil", request.nid_statecivil);
            queryParameters.Add("@nid_education", request.nid_education);
            queryParameters.Add("@nid_instruction", request.nid_instruction);

            queryParameters.Add("@sstudy_center", request.sstudy_center);
            queryParameters.Add("@scurrent_cycle", request.scurrent_cycle);
            queryParameters.Add("@dateStart", request.dateStart);
            queryParameters.Add("@dateEnd", request.dateEnd);

            queryParameters.Add("@snamewife_partner", request.snamewife_partner);
            queryParameters.Add("@slastname_partnet", request.lastname_partner);
            queryParameters.Add("@smotherlastname_partnet", request.motherlastname_partner);

            queryParameters.Add("@ddateofmarriage", request.ddateofmarriage);
            queryParameters.Add("@nid_son", request.nid_son);
            queryParameters.Add("@sfullname", request.sfullname);


            queryParameters.Add("@ddateofbirth", request.ddateofbirth);
            queryParameters.Add("@nyear", request.nyear);
            queryParameters.Add("@ntypeaction", request.ntypeaction);
            queryParameters.Add("@ntypeseccion", request.ntypeseccion);
            queryParameters.Add("@sheavymachinerylicense", request.sheavymachinerylicense);
            queryParameters.Add("@sddriverlicense", request.sddriverlicense);
            queryParameters.Add("@slastname", request.slastname);
            queryParameters.Add("@smotherslastname", request.smotherslastname);
            queryParameters.Add("@sFile", Folder);
            queryParameters.Add("@scarreer", request.scarreer);

            queryParameters.Add("@nresult", DbType.Int32, direction: ParameterDirection.Output);

            var management = await humanManagementReadDbConnection.QueryAsync<ListPositionComboDto>(
                 "staff.sp_request_ins",
                 queryParameters, commandType: CommandType.StoredProcedure);
            result = Convert.ToInt32(queryParameters.Get<int>("@nresult"));

            return result;
        }

        public async Task<List<ListRequestDto>> ListRequest(RequestFilterDto entity)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_collaborator", entity.id);
            
            queryParameters.Add("@nidcompany", entity.idbussines);
            queryParameters.Add("@nidgerencia", entity.idgerencia);
            queryParameters.Add("@nidarea", entity.idarea);
            queryParameters.Add("@nidsubarea", entity.nidsubarea);
            queryParameters.Add("@nstate", entity.nstate);
            queryParameters.Add("@nid_typerequest", entity.nid_typerequest);
            queryParameters.Add("@ntypeseccion", entity.ntypeseccion);
            queryParameters.Add("@dateStart", entity.dateStart);
            queryParameters.Add("@dateEnd", entity.dateEnd);
            queryParameters.Add("@nid_employee", entity.nid_employee);
            
            var list = await humanManagementReadDbConnection.QueryAsync<ListRequestDto>(
                 "staff.sp_request_list",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return list.ToList();
        }



        public async Task<ResultPaginationListDto<ListRequestDto>> ListRequestPagination(EmployeeQueryFilter employeeQueryFilter)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_collaborator", employeeQueryFilter.id);
            queryParameters.Add("@nidcompany", employeeQueryFilter.idbussines);
            queryParameters.Add("@nidgerencia", employeeQueryFilter.idgerencia);
            queryParameters.Add("@nidarea", employeeQueryFilter.idarea);
            queryParameters.Add("@nidsubarea", employeeQueryFilter.nidsubarea);
            queryParameters.Add("@nstate", employeeQueryFilter.nstate);
            queryParameters.Add("@nid_typerequest", employeeQueryFilter.nid_typerequest);
            queryParameters.Add("@ntypeseccion", employeeQueryFilter.ntypeseccion);
            queryParameters.Add("@dateStart", employeeQueryFilter.dateStart);
            queryParameters.Add("@dateEnd", employeeQueryFilter.dateEnd);
            queryParameters.Add("@nid_employee", employeeQueryFilter.nid_employee);
            queryParameters.Add("@ncurrentpage", employeeQueryFilter.pagination.CurrentPage);
            queryParameters.Add("@nitemsperPage", employeeQueryFilter.pagination.ItemsPerPage);
            queryParameters.Add("@nrecordcount", DbType.Int32, direction: ParameterDirection.Output);

            var listUSer = await humanManagementReadDbConnection.QueryAsync<ListRequestDto>(
                 "staff.sp_request_list_pagination",
                 queryParameters, commandType: CommandType.StoredProcedure);

            int totalItems = Convert.ToInt32(queryParameters.Get<int>("@nrecordcount"));

            return new ResultPaginationListDto<ListRequestDto>
            {
                list = listUSer.ToList(),
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / employeeQueryFilter.pagination.ItemsPerPage)
            };
        }




        public async Task RejectRequest(RejectRequest request)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_request", request.nid_request);
            queryParameters.Add("@nid_collaborator", request.nid_collaborator);
            queryParameters.Add("@scomment", request.scomment);
            

            var management = await humanManagementReadDbConnection.QueryAsync<ListPositionComboDto>(
                 "staff.sp_request_reject",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<RequestDetailDto> RequestDetail(int id)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_request", id);


            var list = await humanManagementReadDbConnection.QueryAsync<RequestDetailDto>(
                 "staff.sp_request_detail_list",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList().FirstOrDefault();
        }

        public async Task<ResultPaginationListDto<ListRequestDto>> ListRequestByUser(EmployeeQueryFilter employeeQueryFilter)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_collaborator", employeeQueryFilter.id);
            queryParameters.Add("@nidbussines", employeeQueryFilter.idbussines);
            queryParameters.Add("@nidarea", employeeQueryFilter.idarea);
            queryParameters.Add("@nstate", employeeQueryFilter.nstate);
            queryParameters.Add("@nid_typerequest", employeeQueryFilter.nid_typerequest);
            queryParameters.Add("@ntypeseccion", employeeQueryFilter.ntypeseccion);
            queryParameters.Add("@dateStart", employeeQueryFilter.dateStart);
            queryParameters.Add("@dateEnd", employeeQueryFilter.dateEnd);
            queryParameters.Add("@nid_employee", employeeQueryFilter.nid_employee);
            queryParameters.Add("@ncurrentpage", employeeQueryFilter.pagination.CurrentPage);
            queryParameters.Add("@nitemsperPage", employeeQueryFilter.pagination.ItemsPerPage);
            queryParameters.Add("@nrecordcount", DbType.Int32, direction: ParameterDirection.Output);

            var listUSer = await humanManagementReadDbConnection.QueryAsync<ListRequestDto>(
                 "staff.sp_request_list_by_user",
                 queryParameters, commandType: CommandType.StoredProcedure);

            int totalItems = Convert.ToInt32(queryParameters.Get<int>("@nrecordcount"));

            return new ResultPaginationListDto<ListRequestDto>
            {
                list = listUSer.ToList(),
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / employeeQueryFilter.pagination.ItemsPerPage)
            };
        }
        public async Task<RequestDto> RequestById(int id)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_request", id);
            var list = await humanManagementReadDbConnection.QueryAsync<RequestDto>(
                 "staff.sp_request_by_id",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList().FirstOrDefault(); 
        }

    }
}
