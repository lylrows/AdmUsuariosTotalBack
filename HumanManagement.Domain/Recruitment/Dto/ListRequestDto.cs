using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Recruitment.Dto
{
    public class ListRequestDto
    {
        public int Id { get; set; }
        public int IdCompany { get; set; }
        public int IdApplicant { get; set; }
        public int IdEmployment { get; set; }
        public int IdTypeRequest { get; set; }
        public int State { get; set; }
        public string NameCompany { get; set; }
        public string NameApplicant { get; set; }
        public string PositionApplicant { get; set; }
        public string Employment { get; set; }
        public string TypeRequest { get; set; }
        public string StateDescription { get; set; }
        public int ContractTime { get; set; }
        public int Vacancy { get; set; }
        public string DescriptionEmployment { get; set; }
        public string Requirements { get; set; }
        public string Functions { get; set; }
        public decimal Salary { get; set; }
        public int PendingDays { get; set; }
        public bool Active { get; set; }
        public DateTime DateRegister { get; set; }
        public int UserRegister { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int? UserUpdate { get; set; }
        public int JobCounter { get; set; }
    }
}
