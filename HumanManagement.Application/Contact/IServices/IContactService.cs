using HumanManagement.Domain.Contact.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Application.Contact.IServices
{
    public interface IContactService
    {
        Task Add(ContactDto dto);
        Task Update(ContactDto dto);
        Task<IEnumerable<ContactDto>> GetAll();
        Task<ContactDto> GetById(int id);
        Task Delete(int id);
    }
}
