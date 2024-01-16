using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.WindowsService.Exactus.Dto
{
    public class ExactusEmpleadoTablaDto
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
    }

    public class ExactusDiasVacacionesDto
    {
        public decimal saldo_vacaciones { get; set; }
        public int tipo { get; set; }
        public decimal vencido { get; set; }
        public decimal trunco { get; set; }
    }

    public class RequestExactusDiasVacacionesDto
    {
        public string scode_employee { get; set; }
        public int idcompany { get; set; }
    }
}
