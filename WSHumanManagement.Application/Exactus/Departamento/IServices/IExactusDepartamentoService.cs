using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSHumanManagement.Application.Response;

namespace WSHumanManagement.Application.Exactus.Departamento.IServices
{
    public interface IExactusDepartamentoService
    {
        Task<Result> SyncExactusToHumanManagement();
    }
}
