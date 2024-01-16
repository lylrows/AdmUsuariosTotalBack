﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.EvaluationPostulant.Dto
{
    public class EvaluationPostulantDto
    {
        public int? Id { get; set; }
        public int? IdEvaluation { get; set; }
        public int? IdCompany { get; set; }
        public int IdPostulant { get; set; }
        public string FullNamePostulant { get; set; }
        public string EmailPostulant { get; set; }
        public string PhoneNumberPostulant { get; set; }
        public string DescripcionState { get; set; }
        public int State { get; set; }
        public string Position { get; set; }
        public int IdJob { get; set; }
        public bool? Approved { get; set; }
        public byte[] FolderFileCompetencias { get; set; }
        public string NameFileCompetencias { get; set; }
        public string ContentTypeCompetencias { get; set; }
        public byte[] FolderFileMultitest { get; set; }
        public string NameFileMultitest { get; set; }
        public string ContentTypeMultitest { get; set; }
        public bool OnlySave { get; set; }
        public bool? bisonexactus { get; set; }
    }
}
