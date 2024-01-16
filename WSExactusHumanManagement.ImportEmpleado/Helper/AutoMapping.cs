using AutoMapper;
using HumanManagement.Domain.Employee.Models;
using HumanManagement.Domain.Person.Models;
using HumanManagement.Domain.WindowsService.Exactus.Dto;

namespace WSExactusHumanManagement.ImportEmpleado.Helper
{
 
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            
            CreateMap<ExactusEmpleadoDto, PersonModel>();
            CreateMap<ExactusEmpleadoDto, EmployeeModel>();
            CreateMap<ExactusEmpleadoDto, EmployeeFile>();
            
        }
    }
}
