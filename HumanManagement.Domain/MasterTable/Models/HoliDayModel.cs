using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.MasterTable.Models
{
    public class HoliDayModel : BaseModel.BaseModel
    {
        [Column("nid_holiday")]
        public int Id { get; set; }

        [Column("sname")]
        public string Name { get; set; }

        [Column("ddateholiday")]
        public DateTime DateHoliday { get; set; }

        [Column("nday")]
        public int Day { get; set; }

        [Column("nmonth")]
        public int Month { get; set; }
    }
}
