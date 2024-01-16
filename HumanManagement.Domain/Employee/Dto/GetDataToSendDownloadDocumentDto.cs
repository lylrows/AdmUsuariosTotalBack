using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Employee.Dto
{
    public class GetDataToSendDownloadDocumentDto
    {  
        public string empresa { get; set; }
        public string tipo_reporte { get; set; }
        public string empleado { get; set; }
        public string fch_consulta { get; set; }
        public int nid_employee { get; set; }
        public int nid_company { get; set; }
        public int ntypeseccion { get; set; }
        public int nid_person { get; set; }
        public string empresa_nombre { get; set; }
        public string periodo { get; set; }
        public string tipo_solicitud { get; set; }
    }
}
