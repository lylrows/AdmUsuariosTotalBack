using SitePostulant.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SitePostulant.Application.MasterTable.IServices
{
    public interface IMasterTableService
    {
        Task<Result> GetByIdFather(int id);
        Task<Result> GetCategoryEmployment();
    }
}
