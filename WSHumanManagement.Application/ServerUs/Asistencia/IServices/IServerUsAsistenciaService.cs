using HumanManagement.Domain.WindowsService.ServerUs.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSHumanManagement.Application.ServerUs.Asistencia.IServices
{
    public interface IServerUsAsistenciaService
    {
        void Register(SURegisterAsistenciaDto dtoInsertAsistencia);
    }
}
