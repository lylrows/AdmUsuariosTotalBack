using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.MasterTable.Dto
{
    public class MasterTableDto
    {
        public int Id { get; set; }
        public int? IdType { get; set; }
        public int? IdFather { get; set; }
        public string ShortValue { get; set; }
        public string DescriptionValue { get; set; }
        public string Comment { get; set; }
        public int Order { get; set; }
        public bool Active { get; set; }
        public DateTime DateRegister { get; set; }
        public int UserRegister { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int? UserUpdate { get; set; }
    }
}
