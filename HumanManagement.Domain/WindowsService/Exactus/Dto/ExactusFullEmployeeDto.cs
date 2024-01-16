using HumanManagement.Domain.WindowsService.Exactus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.WindowsService.Exactus.Dto
{
    public class ExactusFullEmployeeDto
    {
        public List<ExactusEmpleado> Empleados { get; set; }
        public List<ExactusEmpleadoAcademico> Academicos { get; set; }
        public List<ExactusEmpleadoExperiencia> Experiencias { get; set; }
        public List<ExactusEmpleadoFamilia> Familia { get; set; }
    }
}
