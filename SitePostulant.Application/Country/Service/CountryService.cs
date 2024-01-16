using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using SitePostulant.Application.Country.IService;
using SitePostulant.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CountryModel = HumanManagement.Domain.Country.Models.Country;
using System.Linq;

namespace SitePostulant.Application.Country.Service
{
    public class CountryService: ICountryService
    {
        private readonly IBaseRepository<CountryModel> baseRepository;
        public CountryService(IBaseRepository<CountryModel> baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public async Task<Result> GetCountryes()
        {
            var entity = await baseRepository.GetAll();
            entity = entity.OrderBy(x => x.Description).ToList();

            return new Result
            {
                Data = entity,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
