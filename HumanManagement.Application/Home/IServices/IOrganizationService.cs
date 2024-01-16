using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HumanManagement.Domain.Models;
using HumanManagement.Domain.Home.Dto;

namespace HumanManagement.Application.Home.IServices
{
    public interface IOrganizationService
    {
        Task Add(OrganizationDto userDto);
        Task Update(OrganizationDto userDto);
        Task<OrganizationDto> GetOne(int id);
        Task<IEnumerable<OrganizationDto>> GetAll();
        Task<OrganizationDto> GetById(int id);
        Task Delete(int id);
    }
}
