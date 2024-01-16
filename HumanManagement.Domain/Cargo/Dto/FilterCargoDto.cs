using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Cargo.Dto
{
    public class FilterCargoDto
    {
        public int? IdEmpresa { get; set; }
        public int? IdArea { get; set; }
        public string NombreCargo { get; set; }
    }
}
