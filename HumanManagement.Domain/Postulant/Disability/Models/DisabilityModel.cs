using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.Postulant.Disability.Models
{
    public class DisabilityModel: BaseModel.BaseModel
    {
        [Column("niddisability")]
        public int Id { get; set; }

        [Column("nidperson")]
        public int IdPerson { get; set; }

        [Column("scertificate_filename")]
        public string CertificateFileName { get; set; }

        [Column("scertificate_folder")]
        public string CertificateFolder { get; set; }

        [Column("sdescription")]
        public string Description { get; set; }
    }
}
