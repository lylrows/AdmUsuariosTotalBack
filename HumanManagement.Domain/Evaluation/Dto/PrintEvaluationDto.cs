using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Evaluation.Dto
{
    public class PrintEvaluationDto
    {
        public PrintEvaluationHeaderDto header { get; set; }
        public List<EvaluationDetailObjetivosDto> objetives { get; set; }
        public List<EvaluationDetailCompentenciasDto> competencies { get; set; }
        public List<EvaluationDetailComentariosDto> comments { get; set; }
        
    }
}
