using Dapper;
using HumanManagement.Domain.Applicants.Dto;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.Recognition.Contracts;
using HumanManagement.Domain.Recognition.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository.RecognitionRepository
{
    public class RecognitionRepository: IRecognitionRepository
    {
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        public RecognitionRepository(IHumanManagementReadDbConnection humanManagementReadDbConnection)
        {
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
        }

        public async Task ChangeStateRecognition(int Id)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_recognition", Id);

            var management = await humanManagementReadDbConnection.QueryAsync<ListPositionComboDto>(
                 "sp_inactive_recognition",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteStateRecognition(int Id)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_recognition", Id);

            var management = await humanManagementReadDbConnection.QueryAsync<ListPositionComboDto>(
                 "sp_delete_recognition",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<FlowConfiguration> GetFlowConfiguration(int IdOrigin, int IdNivel)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_originposition", IdOrigin);
            queryParameters.Add("@nid_nivel", IdNivel);
            var list = await humanManagementReadDbConnection.QueryAsync<FlowConfiguration>(
                "sp_request_flow_configuration_permiss",
                queryParameters, commandType: CommandType.StoredProcedure);

            FlowConfiguration result = new FlowConfiguration();
            result = list.SingleOrDefault();
            return result;
        }

        public async Task<List<ListRecognitionDto>> GetListRecognition(int Id, int IdUser)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_state", Id);
            queryParameters.Add("@nid_user", IdUser);
            var list = await humanManagementReadDbConnection.QueryAsync<ListRecognitionDto>(
                "sp_recognition_list",
                queryParameters, commandType: CommandType.StoredProcedure);
            return list.ToList();
        }
    }
}
