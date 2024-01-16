using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.InformationPostulant.Models
{
    public class InformationEducationModel: BaseModel.BaseModel
    {
        [Column("nidinformationeducation")]
        public int Id { get; set; }

        [Column("instruction")]
        public string Instruction { get; set; }
        
        [Column("nidpostulant")]
        public int IdPostulant { get; set; }

        [Column("nidevaluation")]
        public int IdEvaluation { get; set; }

        [Column("scity")]
        public string City { get; set; }

        [Column("sstudycenter")]
        public string StudyCenter { get; set; }

        [Column("sspeciality")]
        public string Speciality { get; set; }

        [Column("ddatestart")]
        public DateTime? DateStart { get; set; }

        [Column("ddatefinish")]
        public DateTime? DateFinish { get; set; }
        [Column("scarrer")]
        public string Carrer { get; set; }

        [Column("nid_instruction")]
        public int? IdInstruction { get; set; }

        [Column("ncurrent_cicle")]
        public int? CurrentCycle { get; set; }


    }
}
