using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Utils.Constracts;
using SitePostulant.Application.Response;
using SitePostulant.Application.Util.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SitePostulant.Application.Util.Services
{
    public class UtilService: IUtilService
    {
        private readonly IUtilRepository utilRepository;
        public UtilService(IUtilRepository utilRepository)
        {
            this.utilRepository = utilRepository;
        }

        public async Task<Result> GetDepartament()
        {
            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = await utilRepository.GetDepartament()
            };
        }

        public async Task<Result> GetDistrict(int id)
        {
            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = await utilRepository.GetDistrict(id)
            };
        }

        public async Task<Result> GetProvince(int id)
        {
            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = await utilRepository.GetProvince(id)
            };
        }
    }
}
