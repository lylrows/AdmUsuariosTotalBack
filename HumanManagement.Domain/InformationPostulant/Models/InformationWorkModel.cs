using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.InformationPostulant.Models
{
    public class InformationWorkModel : BaseModel.BaseModel
    {
        [Column("nidinformationwork")]
        public int Id { get; set; }

        [Column("nidpostulant")]
        public int IdPostulant { get; set; }

        [Column("nidevaluation")]
        public int IdEvaluation { get; set; }

        [Column("scompany")]
        public string Company { get; set; }

        [Column("srubro")]
        public string Rubro { get; set; }

        [Column("ddatestart")]
        public DateTime? DateStart { get; set; }

        [Column("ddatefinish")]
        public DateTime? DateFinish { get; set; }

        [Column("smotivoexit")]
        public string MotivoExit { get; set; }

        [Column("slastposition")]
        public string LastPosition { get; set; }

        [Column("slastremuneration")]
        public string LastRemuneration { get; set; }

        [Column("smainfunction")]
        public string MainFunction { get; set; }

        [Column("sdirectboss")]
        public string DirectBoss { get; set; }

        [Column("scellnumber")]
        public string CellNumber { get; set; }

        [Column("nsalary")]
        public decimal? Salary { get; set; }

        [Column("sreference")]
        public string Reference { get; set; }

    }
}
