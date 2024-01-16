using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.InformationPostulant.Dto
{
    public class InformationExactusInternalDto
    {
        public int IdEvaluation { get; set; }
        public int IdPostulant { get; set; }
        public string IdNomina { get; set; } 
        public string IdUbicacion { get; set; }
        public bool DescontarQuinta { get; set; }
        public bool RemuneracionIntegral { get; set; }
        public decimal Salary { get; set; }
        public string Schedule { get; set; }
        public bool AfpMixta { get; set; }
        public string IdAfp { get; set; }
        public string Cuspp { get; set; }
        public string FechaInicioCambio { get; set; }
        public string FechaFinCambio { get; set; }
        public bool Confirmed { get; set; }
        public int User { get; set; }
    }
    
    public class FilterInformationExactusInternalDto
    {
        public int IdEvaluation { get; set; }
        public int IdPostulant { get; set; }
    }
}
