using HumanManagement.Domain.Common;

namespace HumanManagement.Domain.Postulant.Person.QueryFilter
{
    public class PostulantQueryFilter
    {
        public int IdJob { get; set; }
        public string Universidad { get; set; }
        public string EdadMinima { get; set; }
        public string EdadMaxima { get; set; }
        public string Estudios { get; set; }
        public string Experiencia { get; set; }

        public string SalarioMinimo { get; set; }
        public string SalarioMaximo { get; set; }
        public string Genero { get; set; }
        public string IsWorking { get; set; }
        public string KeyWords { get; set; }
        public string LevelStudy { get; set; }
        public int IncludeFilterQuery { get; set; }

        public PaginationEntity pagination { get; set; }
        public PostulantQueryFilter()
        {
            pagination = new PaginationEntity();
        }
    }
}
