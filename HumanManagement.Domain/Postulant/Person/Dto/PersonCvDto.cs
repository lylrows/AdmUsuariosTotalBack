using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Postulant.Person.Dto
{
    public class PersonCvDto
    {
        public int IdPerson { get; set; }

        public string Name { get; set; }
        public string Folder { get; set; }
        public byte[] Archivo { get; set; }
        public string ContentType { get; set; }
        public string Img { get; set; }
    }
}
