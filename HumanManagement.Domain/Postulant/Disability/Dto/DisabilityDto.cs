using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Postulant.Disability.Dto
{
    public class DisabilityDto
    {
        public int? Id { get; set; }
        public int IdPerson { get; set; }
        public string CertificateFileName { get; set; }
        public string CertificateFolder{ get; set; }
        public string FileType { get; set; }
        public byte[] CertificateFileBuffer { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
