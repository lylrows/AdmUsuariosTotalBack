using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.StaffRequest.Models
{
    public class StaffRequestLoan
    {
        [Column("nid_staff_request")]
        public int IdStaffRequest { get; set; }

        [Column("nid_type_loan")]
        public int IdTypeLoan { get; set; }

        [Column("sdetailreasonloan")]
        public string DetailReasonLoan { get; set; }

        [Column("namount")]
        public decimal Amount { get; set; }

        [Column("namountmonthlyfee")]
        public decimal AmountMonthlyFee { get; set; }

        [Column("nnumberfee")]
        public int NumberFee { get; set; }

        [Column("spathfiledocument")]
        public string PathFileDocument { get; set; }
        [Column("ntypecase")]
        public int? ntypecase { get; set; }
        [Column("ncoutaselect")]
        public int? ncoutaselect { get; set; }  
        public void SetIdStaffRequest(int id)
        {
            IdStaffRequest = id;
        }
        [Column("namount_grati")]
        public decimal CobroGratificacion { get; set; }
        [Column("namount_uti")]
        public decimal CobroUtilidad { get; set; }
        [Column("nbalance")]
        public decimal Balance { get; set; }
        [Column("ddate_loan")]
        public DateTime DateLoan { get; set; }

        [Column("bGrati")]
        public bool? bGrati { get; set; }
        [Column("nAddGrati")]
        public decimal? nAddGrati { get; set; }
        [Column("bUtil")]
        public bool? bUtil { get; set; }
        [Column("nAddUtilidad")]
        public decimal?  nAddUtilidad { get; set; }


    }
}
