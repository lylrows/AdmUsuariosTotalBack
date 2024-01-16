using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HumanManagement.Domain.Models;
using HumanManagement.Domain.Home.Dto;

namespace HumanManagement.Application.Home.IServices
{
    public interface ISliderService
    {
        Task Add(SliderDto userDto);
        Task Update(SliderDto userDto);
        Task<SliderDto> GetOne(int id);
        Task<IEnumerable<SliderDto>> GetAll();
        Task<SliderDto> GetById(int id);
        Task Delete(int id);
    }
}
