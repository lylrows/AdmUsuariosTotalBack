using AutoMapper;

using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Home.Dto;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using HumanManagement.Application.Home.IServices;

namespace HumanManagement.Application.Home.Services
{
    public class OrganizationService: IOrganizationService
    {
        private readonly IBaseRepository<Domain.Home.Models.Organization> baseRepository;
        private IMapper mapper;
        public OrganizationService(IBaseRepository<Domain.Home.Models.Organization> baseRepository,
                            IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task Add(OrganizationDto dto)
        {
            dto.DateRegister = DateTime.Now;
            var organization = mapper.Map<Domain.Home.Models.Organization>(dto);
            await baseRepository.Add(organization);
        }
        public Task<OrganizationDto> GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(OrganizationDto dto)
        {
            dto.DateUpdate = DateTime.Now;
            var organization = mapper.Map<Domain.Home.Models.Organization>(dto);
            await baseRepository.Update(organization);
        }
        public async Task Delete(int id)
        {
            var entity = await baseRepository.Find(id);
            if (entity != null)
            {
                await baseRepository.Delete(entity);
            }
        }
        public async Task<IEnumerable<OrganizationDto>> GetAll()
        {
            var result = await baseRepository.GetAll();
            var authorDTOs = mapper.Map<List<OrganizationDto>>(result);
            return authorDTOs;
        }
        public async Task<OrganizationDto> GetById(int id)
        {
            var result = await baseRepository.Find(id);
            var authorDTO = mapper.Map<OrganizationDto>(result);
            return authorDTO;
        }
    }
}
