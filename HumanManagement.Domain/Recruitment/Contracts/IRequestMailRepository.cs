using HumanManagement.Domain.Recruitment.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Recruitment.Contracts
{
    public interface IRequestMailRepository
    {
        Task<ResponseMailDto> GetResponseMailById(int id);
        Task<RequestMailDto> GetRequestToSendMailToEvaluatorById(int id);
        Task<RequestMailDto> GetRequestToSendMailToApplicantById(int id);
    }
}
