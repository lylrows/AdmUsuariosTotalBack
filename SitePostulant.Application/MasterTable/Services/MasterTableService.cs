using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.MasterTable.Contracts;
using HumanManagement.Domain.Utils.Constracts;
using SitePostulant.Application.MasterTable.IServices;
using SitePostulant.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SitePostulant.Application.MasterTable.Services
{
    public class MasterTableService: IMasterTableService
    {
        private readonly IMasterTableRepository masterTableRepository;
        private readonly IUtilRepository utilRepository;
        public MasterTableService(IMasterTableRepository masterTableRepository, IUtilRepository utilRepository)
        {
            this.masterTableRepository = masterTableRepository;
            this.utilRepository = utilRepository;
        }

        public async Task<Result> GetByIdFather(int id)
        {
            var dto = await masterTableRepository.GetByIdFather(id);
            return new Result
            {
                Data = dto,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }

        public async Task<Result> GetCategoryEmployment()
        {
            var listdistrict = await utilRepository.GetListCategoryEmployment();
            return new Result
            {
                Data = listdistrict,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}

