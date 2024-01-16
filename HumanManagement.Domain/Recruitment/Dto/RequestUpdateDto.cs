using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Recruitment.Dto
{
    public class RequestUpdatedDto
    {
        public int Id { get; set; }
        public int State { get; set; }
        public int ContractTime { get; set; }
        public int Vacancy { get; set; }
        public int UserRegister { get; set; }
        public string Employment { get; set; }
        public string DescriptionEmployment { get; set; }
        public string Requirements { get; set; }
        public string Functions { get; set; }
        public decimal Salary { get; set; }
        public int Level { get; set; }
        public int IdGroup { get; set; }
        public decimal GroossSalary { get; set; }
        public int IdProfile { get; set; }
        public int IdCharge { get; set; }
        public int IdAreaPosition { get; set; }
        public int IdCompany { get; set; }


    }
}
