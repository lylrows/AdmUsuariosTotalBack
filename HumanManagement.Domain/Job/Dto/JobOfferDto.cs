using HumanManagement.Domain.Utils.Dto;
using System;
using System.Collections.Generic;

namespace HumanManagement.Domain.Job.Dto
{
    public class JobOfferDto : BaseModel.BaseModel
    {
        public int Id_Job { get; set; }
        public string Title { get; set; }
        public string NoticeDetails { get; set; }
        public string Requirements { get; set; }
        public string Benefits { get; set; }
        public decimal? Salary { get; set; }
        public string Location { get; set; }
        public string Tags { get; set; }
        public int Id_Area { get; set; }
        public int? Id_JobLevel { get; set; }
        public int? Id_JobType { get; set; }
        public int? Id_WorkType { get; set; }
        public int? Id_Company { get; set; }
        public int? IdDistrict { get; set; }
        public int? IdDepartment { get; set; }
        public int? IdProvince { get; set; }
        public int Vacancies { get; set; }
        public string IncludeKeywords { get; set; }
        public bool IsSuitableForDisabled { get; set; }
        public int IdSex { get; set; }
        public int MinimumAge { get; set; }
        public int MaximumAge { get; set; }
        public string WorkExperience { get; set; }
        public decimal MinimumSalary { get; set; }
        public decimal MaximumSalary { get; set; }
        public bool ShowSalaryInNotice { get; set; }
        public bool IsPostedBumeran { get; set; }
        public bool IsPostedComputrabajo { get; set; }
        public int IdEducationLevel { get; set; }
        public int IdEducationLevelSituation { get; set; }
        public List<JobIdiomDto> JobIdiomList { get; set; }
        public List<JobKeyWordDto> JobKeyWordList { get; set; }
        public int IdRequest { get; set; }
        public int IdState { get; set; }
        public DateTime FinishDate { get; set; }
        public int? IdCharge { get; set; }
        public int? IdApplicant { get; set; }
        public string Funtions { get; set; }
        public List<JobPregradoDto> JobPregradoList { get; set; }
        public List<JobPostgradoDto> JobPostgradoList { get; set; }
        public JobOfferDto()
        {
            JobIdiomList = new List<JobIdiomDto>();
            JobKeyWordList = new List<JobKeyWordDto>();
            JobPregradoList = new List<JobPregradoDto>();
            JobPostgradoList = new List<JobPostgradoDto>();
        }
    }
}
