using HumanManagement.Domain.Empresa.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.Empresa.Dto
{
    public class EmpresaDto: Entity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Schema { get; set; }
        public int? IdServerUs { get; set; }
        public string Ruc { get; set; }
    }
}
