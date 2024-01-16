using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.General.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSHumanManagement.Application.Exactus.Puesto.IServices;
using WSHumanManagement.Application.Extensions;

namespace WSHumanManagement.Application.Exactus.Puesto.Services
{
   
    public class ExactusPuestoService : CustomWindowsService
    {
        private readonly ICoreParameterRepository coreParameterRepository;
        private readonly IExactusPuestoLogic exactusPuestoLogic;
        public ExactusPuestoService(ICoreParameterRepository coreParameterRepository, IExactusPuestoLogic exactusPuestoLogic)
            : base(coreParameterRepository)
        {
            this.exactusPuestoLogic = exactusPuestoLogic;
        }
        public override void Run()
        {
            exactusPuestoLogic.Import();
        }

        public override void SetParameterBase()
        {
            ParameterFilter.ApplicationName = Constants.HumanManagemen.ApplicationName;
            ParameterFilter.Module = Constants.NotifyImportedUser.Module;
        }
    }
}
