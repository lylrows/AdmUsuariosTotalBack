using HumanManagement.Domain.Events;
using HumanManagement.Domain.Recruitment.Dto;

namespace HumanManagement.Domain.Recruitment.Events
{
    public class RequestUpdated : IDomainEvent
    {
        public int IdRequestFlow { get; set; }
        public ResponseMailDto RequestUpdate { get; set; }
    }
}
