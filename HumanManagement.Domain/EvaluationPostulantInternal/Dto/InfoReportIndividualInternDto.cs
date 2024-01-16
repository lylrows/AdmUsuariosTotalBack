using HumanManagement.Domain.Person.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulantInternal.Dto
{
    public class InfoReportIndividualInternDto
    {
        public PersonDto InfoPerson { get; set; }
        public List<EvaluationProficiencyInternDto> InfoEvaluationProficiencyActually { get; set; }

        public List<EvaluationProficiencyInternDto> InfoEvaluationProficiencyFuture { get; set; }
        public List<EvaluationFortalezasInternDto> InfoEvaluationRating { get; set; }
        public EvaluationMultitestInternDto InfoEvaluationMultitest { get; set; }
        public string PositionApplicant { get; set; }
    }
}
