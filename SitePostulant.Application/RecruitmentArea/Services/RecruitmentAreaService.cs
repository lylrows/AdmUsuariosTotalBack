using AutoMapper;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Areas.Contracts;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Contracts;

using SitePostulant.Application.RecruitmentArea.IServices;
using SitePostulant.Application.Response;

using System.Threading.Tasks;

namespace SitePostulant.Application.RecruitmentArea.Services
{
    public class RecruitmentAreaService : IRecruitmentAreaService
    {
        private readonly IBaseRepository<HumanManagement.Domain.RecruitmentArea.Models.RecruitmentArea> _baseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private readonly IAreaRepository areaRepository;

        public RecruitmentAreaService(IBaseRepository<HumanManagement.Domain.RecruitmentArea.Models.RecruitmentArea> baseRepository, IUnitOfWork unitOfWork, IMapper mapper, IAreaRepository areaRepository)
        {            
            this._baseRepository = baseRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this.areaRepository = areaRepository;
        }

        public async Task<Result> GetAll(int idEmpresa)
        {
            var result = await areaRepository.GetByEmpresa(idEmpresa);

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = result
            };


        }

    }
}
