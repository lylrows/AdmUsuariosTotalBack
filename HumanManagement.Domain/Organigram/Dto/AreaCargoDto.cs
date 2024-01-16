using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Organigram.Dto
{
    public class AreaCargoDto
    {
        public int Id { get; set; }
        public int IdAreaUpper { get; set; }
        public int IdEmpresa { get; set; }
        public string Area { get; set; }
        public string Cargo { get; set; }
        public string Empleado { get; set; }
        public string Avatar { get; set; }
        public int IdCargo { get; set; }
        public int IdEmpleado { get; set; }
        public int IdBossReal { get; set; }
    }
}
