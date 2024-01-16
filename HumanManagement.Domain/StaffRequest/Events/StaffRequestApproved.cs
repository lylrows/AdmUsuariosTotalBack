using HumanManagement.Domain.Events;
using HumanManagement.Domain.WindowsService.ServerUs.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.StaffRequest.Events
{
    public class StaffRequestApproved : IDomainEvent
    {
        public SURegisterAsistenciaDto registerAsistenciaDto { get; private set; }
        public StaffRequestApproved(SURegisterAsistenciaDto registerAsistenciaDto)
        {
            this.registerAsistenciaDto = registerAsistenciaDto;
        }
    }
}
