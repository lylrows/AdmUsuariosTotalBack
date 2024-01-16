using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Campaign.Dto
{
    public class EvaluationQueryFilterDto
    {
        public int nidCampana { get; set; }
        public int numberAction { get; set; }
        public int statusEtapa { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int TotalRows { get; set; }
        public int CompanyId { get; set; }
        public int AreaId { get; set; }
        public int SubAreaId { get; set; }
        public int GerenciaId { get; set; }
    }

    public class MyEvaluationFilter
    {
        public int nyear { get; set; }
        public int nidCampana { get; set; }
        public int nidEmployee { get; set; }
        public bool flat { get; set; }
        public int nid_position { get; set; }
        public int nid_profile { get; set; }
        public int companyid { get; set; }
        public int gerenciaid { get; set; }
        public int areaid { get; set; }
        public int subareaid { get; set; }
        public string list_employee { get; set; }
        public int etapa { get; set; }
        public int statusetapa { get; set; }

        public int currentPage { get; set; }
        public int itemsPerPage { get; set; }
        public int totalItems { get; set; }
        public int totalPages { get; set; }
        public int totalRows { get; set; }

    }

    public class DeleteEmployee
    {
        public int IdEvaluation { get; set; }
        public int EmpleadoId { get; set; }
        public string comment { get; set; }
        public int AreaId { get; set; }
        public int PositionId { get; set; }
        public int EmisorId { get; set; }
        public int ReceptorId { get; set; }
        public string Name { get; set; }
        public string Campaign { get; set; }
    }

    
}
