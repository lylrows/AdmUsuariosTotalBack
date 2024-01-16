using HumanManagement.Application.ImportEmployeeService;
using WSHumanManagement.Application.Extensions;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.General.Contracts;

namespace WSHumanManagement.Application.ImportUser
{
    public class ImportUserService : CustomWindowsService
    {
        private readonly ICoreParameterRepository coreParameterRepository;
        private readonly IImportEmployeeService importEmployeeService;
        public ImportUserService(ICoreParameterRepository coreParameterRepository, IImportEmployeeService importEmployeeService) 
            : base(coreParameterRepository)
        {
            this.importEmployeeService = importEmployeeService;
        }
        public override void Run()
        {
            importEmployeeService.Import();
        }

        public override void SetParameterBase()
        {
            ParameterFilter.ApplicationName = Constants.HumanManagemen.ApplicationName;
            ParameterFilter.Module = Constants.NotifyImportedUser.Module;
        }
    }
}
