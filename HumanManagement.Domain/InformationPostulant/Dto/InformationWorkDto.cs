using HumanManagement.Domain.Utils.Dto;

namespace HumanManagement.Domain.InformationPostulant.Dto
{
    public class InformationWorkDto
    {
        public int? Id { get; set; }
        public int IdPostulant { get; set; }
        public int IdEvaluation { get; set; }
        public int IdE { get; set; }
        public string Company { get; set; }
        public string Rubro { get; set; }
        public string DateStart { get; set; }
        public string DateFinish { get; set; }
        public string MotivoExit { get; set; }
        public string LastPosition { get; set; }
        public string LastRemuneration { get; set; }
        public string MainFunction { get; set; }
        public string DirectBoss { get; set; }
        public string CellNumber { get; set; }
        public decimal? Salary { get; set; }
        public string Reference { get; set; }

        public InformationFilesDto InformationFile { get; set; }
    }
}
