using AutoMapper;

using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Home.Dto;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using HumanManagement.Application.Home.IServices;
using System.Linq;

namespace HumanManagement.Application.Home.Services
{
    public class SliderService:ISliderService
    {
        private readonly IBaseRepository<Domain.Home.Models.Slider> baseRepository;
        private IMapper mapper;
        public SliderService(IBaseRepository<Domain.Home.Models.Slider> baseRepository,
                            IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task Add(SliderDto dto)
        {
            dto.DateRegister = DateTime.Now;
            var slider = mapper.Map<Domain.Home.Models.Slider>(dto);
            await baseRepository.Add(slider);
        }
        public Task<SliderDto> GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(SliderDto dto)
        {
            dto.DateUpdate = DateTime.Now;
            var slider = mapper.Map<Domain.Home.Models.Slider>(dto);
            await baseRepository.Update(slider);
        }
        public async Task Delete(int id)
        {
            var entity = await baseRepository.Find(id);
            if (entity != null)
            {
                await baseRepository.Delete(entity);
            }
        }
        public async Task<IEnumerable<SliderDto>> GetAll()
        {
            var result = await baseRepository.GetAll();
            var authorDTOs = mapper.Map<List<SliderDto>>(result);
            authorDTOs = authorDTOs.OrderBy(x => x.Order).ToList();
            return authorDTOs;
        }
        public async Task<SliderDto> GetById(int id)
        {
            var result = await baseRepository.Find(id);
            var authorDTO = mapper.Map<SliderDto>(result);
            return authorDTO;
        }

    }
}
