using HumanManagement.Domain.Cargo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Cargo.Dto
{
    public class CargoDto: Entity
    {
        public int Id { get; set; }
        public int IdArea { get; set; }
        public int IdEmpresa { get; set; }
        public string Empresa { get; set; }
        public string NameArea { get; set; }
        public string NameSubArea { get; set; }
        public string NameCargo { get; set; }
        public bool Active { get; set; }
        public int State { get; set; }
        public int IdUpperCargo { get; set; }


        public int IdGerenciaCombo { get; set; }
        public int IdAreaCombo { get; set; }
        public int IdSubAreaCombo { get; set; }
    }

    public class CargoByCompanyAreaDto
    {
        public int nid_charge { get; set; }
        public string snamecharge { get; set; }
    }
}
