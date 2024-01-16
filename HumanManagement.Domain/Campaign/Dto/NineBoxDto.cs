using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Campaign.Dto
{
    public class NineBoxDto
    {
        public int? IdEvaluation { get; set; }
        public double? ObjetivoPorc { get; set; }
        public double? CompetenciaPorc { get; set; }

        public string DNI { get; set; }
        public string NombreCompleto { get; set; }
        public string Cargo { get; set; }
        public string Area { get; set; }
        public string Compania { get; set; }
        public string FotoUrl { get; set; }
    }
    public class NineBoxFilterDto
    {
        public int nidcompany { get; set; }
        public int nidgerencia { get; set; }
        public int nidarea{ get; set; }
        public int nidsubarea { get; set; }
        public int nidcargo { get; set; }
        //public int nidcampana { get; set; }
        public string nidcampana { get; set; }
    }
    public class NineBoxSPDto
    {
        public int? IdEvaluation { get; set; }
        public int? IdGroup { get; set; }
        public double? Expectativa { get; set; }
        public double? Realidad { get; set; }
        public double? Peso { get; set; }
        public string DNI { get; set; }
        public string NombreCompleto { get; set; }
        public string Cargo { get; set; }
        public string Area { get; set; }
        public string Compania { get; set; }
        public string FotoUrl { get; set; }

    }

    public class ResumenEvaluationDto
    {
        public int? IdEvaluation { get; set; }
        public int? IdGroup { get; set; }
        public double? Expectativa { get; set; }
        public double? Realidad { get; set; }
        public double? Peso { get; set; }
        public string DNI { get; set; }
        public string NombreCompleto { get; set; }
        public string Cargo { get; set; }
        public string Area { get; set; }
        public string Compania { get; set; }
        public string FotoUrl { get; set; }

        public int IdCampaign { get; set; }
        public string Campaign { get; set; }

    }

    public class EvaluationDto
    {
        public int? IdEvaluation { get; set; }
        public double? ObjetivoPorc { get; set; }
        public double? CompetenciaPorc { get; set; }

        public string DNI { get; set; }
        public string NombreCompleto { get; set; }
        public string Cargo { get; set; }
        public string Area { get; set; }
        public string Compania { get; set; }
        public string FotoUrl { get; set; }

        public int IdCampania { get; set; }
        public string Campania { get; set; }
    }

    public class MyTeamNineBoxFilterDto
    {
        public int nidcompany { get; set; }
        public int nidgerencia { get; set; }
        public string nidarea { get; set; }
        public string nidsubarea { get; set; }
        public string nidcargo { get; set; }
        public string nidcampana { get; set; }
    }
    public class MyTeamResultadoFilterDto
    {
        public int nidcompany { get; set; }
        public int nidgerencia { get; set; }
        public string nidarea { get; set; }
        public string nidsubarea { get; set; }
        public string nidcargo { get; set; }
        public string nidcampana { get; set; }
        public int nid_employee { get; set; }
    }
}
