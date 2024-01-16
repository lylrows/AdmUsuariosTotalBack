using HumanManagement.Domain.Person.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Recruitment.Person.Contracts
{
    public interface IPersonRepository
    {
        Task<PersonDto> GetPerson(int Id);
        Task<List<ListPhoneDto>> GetListPhone(int Id);
    }
}
