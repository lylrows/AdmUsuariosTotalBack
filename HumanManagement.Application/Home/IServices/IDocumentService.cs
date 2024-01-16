using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HumanManagement.Domain.Models;
using HumanManagement.Domain.Home.Dto;

namespace HumanManagement.Application.Home.IServices
{
    public interface IDocumentService
    {
        Task Add(DocumentDto userDto);
        Task Update(DocumentDto userDto);
        Task<DocumentDto> GetOne(int id);
        Task<DocumentDto> GetById(int id);
        Task Delete(int id);
    }
}
