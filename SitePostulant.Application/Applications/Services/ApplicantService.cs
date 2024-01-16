using AutoMapper;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Applicants.Contracts;
using HumanManagement.Domain.Applicants.Dto;
using HumanManagement.Domain.BaseRepository;
using SitePostulant.Application.Applications.IServices;
using SitePostulant.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitePostulant.Application.Applications.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IMapper mapper;

        public ApplicantService(IApplicantRepository applicantRepository,
                                        IMapper mapper)
        {
            this._applicantRepository = applicantRepository;
            this.mapper = mapper;
        }

        public async Task<Result> GetListJob(int IdUser)
        {
            var dto = await _applicantRepository.GetListJob(IdUser);

            return new Result
            {
                Data = dto,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }

        public async Task<Result> GetListMyApplicants(FilterApplicants filters)
        {
            var dto = await _applicantRepository.GetListMyApplicants(filters);
            int ntotalrecord = dto.Count();
            dto = dto.Skip((filters.CurrentPage - 1) * 5).Take(5).ToList();
            return new Result
            {
                Data = new {
                    lista = dto,
                    totalrecords = ntotalrecord
                },
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }

        public async Task<Result> GetStateApplicants(int IdUser)
        {
            var dto = await _applicantRepository.GetStateApplicants(IdUser);

            return new Result
            {
                Data = dto,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
