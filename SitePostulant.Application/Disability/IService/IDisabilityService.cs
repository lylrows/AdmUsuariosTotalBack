using HumanManagement.Domain.Postulant.Disability.Dto;
using Microsoft.AspNetCore.Http;
using SitePostulant.Application.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SitePostulant.Application.Disability.IService
{
    public interface IDisabilityService
    {
        Task<Result> GetDisability(int IdPerson);
        Task<Result> Add(DisabilityDto dto, IFormFile certificado);
        Task<Result> Update(DisabilityDto dto);
    }
}
