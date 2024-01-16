using HumanManagement.Domain.Events;
using HumanManagement.Domain.Recruitment.Dto;

namespace HumanManagement.Domain.Recruitment.Events
{
    public class RequestRegistered : IDomainEvent
    {
        public int IdReuqest { get; set; }
        public RequestMailDto RequestMail { get; set; }
    }
}
