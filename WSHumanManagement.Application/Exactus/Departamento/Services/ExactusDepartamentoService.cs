using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.General.Contracts;
using WSHumanManagement.Application.Exactus.Departamento.IServices;
using WSHumanManagement.Application.Extensions;

namespace WSHumanManagement.Application.Exactus.Departamento.Services
{
    public class ExactusDepartamentoService : CustomWindowsService
    {
        private readonly ICoreParameterRepository coreParameterRepository;
        private readonly IExactusDepartamentoLogic exactusDepartamentoLogic;
        public ExactusDepartamentoService(ICoreParameterRepository coreParameterRepository, IExactusDepartamentoLogic exactusDepartamentoLogic)
            : base(coreParameterRepository)
        {
            this.exactusDepartamentoLogic= exactusDepartamentoLogic;
        }
        public override void Run()
        {
            
        }

        public override void SetParameterBase()
        {
            ParameterFilter.ApplicationName = Constants.HumanManagemen.ApplicationName;
            ParameterFilter.Module = Constants.NotifyImportedUser.Module;
        }
    }
}
