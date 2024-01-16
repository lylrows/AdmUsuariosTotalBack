using HumanManagement.Domain.Postulant.Person.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulant.Dto
{
    public class InfoReportIndividualDto
    {
        public PersonDto InfoPerson { get; set; }
        public List<EvaluationProficiencyDto> InfoEvaluationProficiency { get; set; }
        public List<EvaluationRatingPostulantDto> InfoEvaluationRating { get; set; }
        public EvaluationMultitestExternDto InfoEvaluationMultitest { get; set; }
        public string PositionApplicant { get; set; }
    }
}
