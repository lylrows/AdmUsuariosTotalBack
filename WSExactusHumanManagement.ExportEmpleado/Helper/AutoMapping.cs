using AutoMapper;
using HumanManagement.Domain.Employee.Models;
using HumanManagement.Domain.Person.Models;
using HumanManagement.Domain.WindowsService.Exactus.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WSExactusHumanManagement.ExportEmpleado.Helper
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
