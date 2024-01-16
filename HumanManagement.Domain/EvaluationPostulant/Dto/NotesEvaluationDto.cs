using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulant.Dto
{
    public class NotesEvaluationDto
    {
        public int? Id { get; set; }
        public int IdEvaluationPostulant { get; set; }
        public string Descripcion { get; set; }
        public string Autor { get; set; }
        public string DateRegister { get; set; }
    }
}
