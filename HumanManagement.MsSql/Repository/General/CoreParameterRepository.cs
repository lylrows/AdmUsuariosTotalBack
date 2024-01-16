using HumanManagement.Domain.General.Contracts;
using HumanManagement.Domain.General.Dto;
using HumanManagement.MsSql.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository.General
{
    public class CoreParameterRepository : ICoreParameterRepository
    {
        private readonly DbContextMsSql context;
        public CoreParameterRepository(DbContextMsSql context)
        {
            this.context = context;
        }
        public async Task<ParameterResultDto> GetValue(ParameterFilterDto parameterFilterDto)
        {
            var result = await (from p in context.CoreParameter
                          where p.ApplicationName == parameterFilterDto.ApplicationName
                          && p.Module == parameterFilterDto.Module
                          && p.Key == parameterFilterDto.Key
                          select new ParameterResultDto
                          {
                              ValueNumeric = p.ValueNumeric,
                              ValueString = p.ValueString
                          }).SingleOrDefaultAsync();

            return result;
        }
    }
}
