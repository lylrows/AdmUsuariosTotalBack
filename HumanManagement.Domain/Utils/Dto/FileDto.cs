using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Utils.Dto
{
    public class FileDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string ContentType { get; set; }
        public byte[] File { get; set; }
    }
}
