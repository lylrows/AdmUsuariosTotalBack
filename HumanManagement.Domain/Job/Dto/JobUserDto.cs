using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Job.Dto
{
    public class JobUserDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string State { get; set; }
        public string Datefinish { get; set; }
        public string FullName { get; set; }
        public int Visits { get; set; }
        public int CvEntry { get; set; }
        public int CvNotRead { get; set; }
        public string Type { get; set; }
        public int IdRequest { get; set; }
        public int IdEvaluation { get; set; }
    }
}
