using HumanManagement.Domain.Postulant.Security.Dto;
using SitePostulant.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SitePostulant.Application.Security.IServices
{
    public interface ILoginService
    {
        Task<Result> GetLoginUserQuery(LoginDto loginDto);
    }
}
