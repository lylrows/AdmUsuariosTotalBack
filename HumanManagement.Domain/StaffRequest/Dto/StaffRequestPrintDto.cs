using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.StaffRequest.Dto
{
    public class StaffRequestPrintDto
    {
        public int Id { get; set; }
        public int IdTypeStaffRequest { get; set; }
        public string TypeStaffRequest { get; set; }
        public string FullNameEmployee { get; set; }
        public DateTime DateIssue { get; set; }
        public string Charge { get; set; }
        public string Area { get; set; }
        public string AreaCentroCosto { get; set; }
        public string Company { get; set; }
        public int State { get; set; }
        public string StateName { get; set; }
        public bool Evaluate { get; set; }
        public string FechaSolicitud { get; set; }
        public string DNI { get; set; }
        public string FechaAprobPenultimoNivel { get; set; }
        public string FechaAprobUltimoNivel { get; set; }
        public string TipoSolicitud { get; set; }
    }

    public class StaffRequestTimeDto : StaffRequestPrintDto
    {
        public string FechaInicio { get; set; }
        public string HoraInicio { get; set; }
        public string FechaFin { get; set; }
        public string HoraFin { get; set; }
        public int DiasCalendario { get; set; }
        public int DiasHabiles { get; set; }

    }

    public class StaffRequestMoneyLoanDto : StaffRequestPrintDto
    {
        public decimal Capital { get; set; }
        public int NroCuotas { get; set; }
        public decimal MontoGrati { get; set; }
        public decimal MontoUti { get; set; }
        public decimal CuotraBrutaMensual { get; set; }
        public string PeriodoPrimeraCuota { get; set; }
        public string PeriodoUltimaCuota { get; set; }
        public decimal TotalintPlusIGV { get; set; }
    }

    public class StaffRequestMoneyChange : StaffRequestPrintDto
    {
        public string Banco { get; set; }
        public string Moneda { get; set; }
        public string CuentaBancaria { get; set; }
        public string CuentaCCI { get; set; }

    }

    public class StaffRequestSure : StaffRequestPrintDto
    {
        public string Acion { get; set; }
        public string TipoSeguro { get; set; }
        public string TipoEPS { get; set; }
        public string Beneficiario { get; set; }
    }
    public class StaffRequestBurial : StaffRequestPrintDto
    {
        public string ServicioSepultura { get; set; }
        public string ServicioFunerario { get; set; }
        public string CeremoniInhumacion { get; set; }
        public string Otros { get; set; }
        public string Observaciones { get; set; }
    }
    public class StaffRequestCapacitation : StaffRequestPrintDto
    {
        public string Evento { get; set; }
        public string Organizador { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string CentroFormacion { get; set; }
        public string Objetivo { get; set; }
        public string Horario { get; set; }
        public string Lugar { get; set; }
    }
}
