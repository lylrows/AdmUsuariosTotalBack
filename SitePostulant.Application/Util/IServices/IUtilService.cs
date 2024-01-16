using SitePostulant.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SitePostulant.Application.Util.IServices
{
    public interface IUtilService
    {
        Task<Result> GetDepartament();
        Task<Result> GetProvince(int id);
        Task<Result> GetDistrict(int id);
    }
}
