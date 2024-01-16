using HumanManagement.Domain.NineBox.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanManagement.Domain.NineBox.Dto
{
    public class NineBoxDto : Entity
    {
        public int Id { get; set; }
        public int IdGroup { get; set; }
        public string Description { get; set; }
        public int MinLevel { get; set; }
        public int MaxLevel { get; set; }
        public bool Active { get; set; }
        public string NameGroup { get; set; }
        public string CodeConfig { get; set; }

    }
}
