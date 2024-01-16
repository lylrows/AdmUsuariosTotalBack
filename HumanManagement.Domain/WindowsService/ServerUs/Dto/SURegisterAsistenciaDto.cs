using HumanManagement.Domain.StaffRequest.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.WindowsService.ServerUs.Dto
{
    public class SURegisterAsistenciaDto
    {
        public int IdCompany { get; set; }
        public string CodTipoSolicitud { get; set; }
        public string CodSubTipoSolicitud { get; set; }


        /* CABECERA */
        public string CentroResponsabilidad { get; set; }
        public int IdTrabajador { get; set; }
        public string CodEmpleado { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string DescripcionSolcitud { get; set; }

        /* DETALLE */

        public DateTime fecha_hora_inicio { get; set; }
        public DateTime fecha_hora_final { get; set; }
        public DateTime fecha_hora_inicio_real { get; set; }
        public DateTime fecha_hora_final_real { get; set; }

        public void SetCodRequestServerus(int IdTypeStaffRequest)
        {
            switch (IdTypeStaffRequest)
            {
                case (int)StaffRequestType.VACATION_WITHOUT_EXCEPTION:
                case (int)StaffRequestType.VACATION_WITH_EXCEPTION:
                    CodTipoSolicitud = "VAC";
                    CodSubTipoSolicitud = "VAC";
                    break;
                case (int)StaffRequestType.PERMIT:
                    CodTipoSolicitud = "PXD";
                    CodSubTipoSolicitud = "PTR";
                    break;
                case (int)StaffRequestType.JUSTIFICATION_FOR_ABSENCE:
                    CodTipoSolicitud = "PXD";
                    CodSubTipoSolicitud = "MTL";
                    break;
                case (int)StaffRequestType.JUSTIFICATION_FOR_DELAY:
                    CodTipoSolicitud = "PXD";
                    CodSubTipoSolicitud = "TAJ";
                    break;
                case (int)StaffRequestType.JUSTIFICATION_FOR_EXTRA_HOURS:
                    CodTipoSolicitud = "HOE";
                    CodSubTipoSolicitud = "HCO";
                    break;
                default:
                    CodTipoSolicitud = string.Empty;
                    CodSubTipoSolicitud = string.Empty;
                    break;
            }

        }
    }

    
}
