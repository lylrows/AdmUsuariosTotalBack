using HumanManagement.Domain.RecruitmentArea.Dto;
using SitePostulant.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitePostulant.Application.RecruitmentArea.IServices
{
    public interface IRecruitmentAreaService
    {
        Task<Result> GetAll(int idEmpresa);
    }
}
