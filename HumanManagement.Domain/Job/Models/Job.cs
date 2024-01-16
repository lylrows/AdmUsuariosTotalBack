using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanManagement.Domain.Job.Models
{
    public class Job : BaseModel.BaseModel
    {

        [Column("id_job")]
        public int Id_Job { get; set; }
        [Column("stitle")]
        public string Title { get; set; }
        [Column("snoticedetails")]
        public string NoticeDetails { get; set; }
        [Column("srequirements")]
        public string Requirements { get; set; }
        [Column("sbenefits")]
        public string Benefits { get; set; }
        [Column("nsalary")]
        public decimal? Salary { get; set; }
        [Column("slocation")]
        public string Location { get; set; }
        [Column("stags")]
        public string Tags { get; set; }
        [Column("nid_area")]
        public int Id_Area { get; set; }

        [Column("nid_category")]
        public int Id_category { get; set; }

        [Column("sjob_type")]
        public string JobType { get; set; }
        [Column("nid_joblevel")]
        public int? Id_JobLevel { get; set; }
        [Column("nid_jobtype")]
        public int? Id_JobType { get; set; }
        [Column("nid_worktype")]
        public int? Id_WorkType { get; set; }
        [Column("ncompanyid")]
        public int? Id_Company { get; set; }

        [Column("nid_district")]
        public int? IdDistrict { get; set; }

        [Column("nvacancies")]
        public int Vacancies { get; set; }

        [Column("sincludekeywords")]
        public string IncludeKeywords { get; set; }

        [Column("bissuitablefordisabled")]
        public bool IsSuitableForDisabled { get; set; }

        [Column("nid_sex")]
        public int IdSex { get; set; }

        [Column("nminimumage")]
        public int MinimumAge { get; set; }

        [Column("nmaximumage")]
        public int MaximumAge { get; set; }

        [Column("sworkexperience")]
        public string WorkExperience { get; set; }

        [Column("nminimumsalary")]
        public decimal MinimumSalary { get; set; }

        [Column("nmaximumsalary")]
        public decimal MaximumSalary { get; set; }

        [Column("bshowsalaryinnotice")]
        public bool ShowSalaryInNotice { get; set; }

        [Column("bispostedbumeran")]
        public bool IsPostedBumeran { get; set; }

        [Column("bispostedcomputrabajo")]
        public bool IsPostedComputrabajo { get; set; }

        [Column("nid_educationlevel")]
        public int IdEducationLevel { get; set; }

        [Column("nid_educationlevelsituation")]
        public int IdEducationLevelSituation { get; set; }

        [Column("nid_request")]
        public int IdRequest { get; set; }

        [Column("nid_state")]
        public int IdState { get; set; }
        
        [Column("dfinishdate")]
        public DateTime FinishDate { get; set; }

        [Column("nidcharge")]
        public int IdCharge { get; set; }

        [Column("nidapplicant")]
        public int? IdApplicant { get; set; }
        public void SetStatePending()
        {
            IdState = 1;
        }

    }
}
