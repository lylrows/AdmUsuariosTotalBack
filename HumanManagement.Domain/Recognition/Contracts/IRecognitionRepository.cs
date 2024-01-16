using HumanManagement.Domain.Applicants.Dto;
using HumanManagement.Domain.Recognition.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Recognition.Contracts
{
    public interface IRecognitionRepository
    {
        Task<List<ListRecognitionDto>> GetListRecognition(int Id, int IdUser);
        Task ChangeStateRecognition(int Id);
        Task DeleteStateRecognition(int Id);
        Task<FlowConfiguration> GetFlowConfiguration(int IdOrigin, int IdNivel);
    }
}
