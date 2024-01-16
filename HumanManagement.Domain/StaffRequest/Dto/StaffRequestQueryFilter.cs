using HumanManagement.Domain.Common;
using System;

namespace HumanManagement.Domain.StaffRequest.Dto
{
    public class StaffRequestQueryFilter
    {
        public int IdTypeStaffRequest { get; set; }
        public DateTime InitialIssueDate { get; set; }
        public DateTime FinalIssueDate { get; set; }
        public int IdEmployee { get; set; }
        public int IdUser { get; set; }
        public int IdCompany { get; set; }
        public int IdArea { get; set; }
        public int IdStatus { get; set; }
        public int IdStatusApprove { get; set; }
        public PaginationEntity Pagination { get; set; }
        public StaffRequestQueryFilter()
        {
            Pagination = new PaginationEntity();
        }

    }

    public class ApprovedAdvacementDto
    {
        public int nid_request { get; set; }
        public int nid_charger { get; set; }
        public int nid_employee { get; set; }
        public int nlevel { get; set; }
        public int nid_person { get; set; }
        public int nid_area { get; set; }
        public int nid_receptor { get; set; }
        public string names { get; set; }
        public string charge { get; set; }
        public string dni { get; set; }
        public int idTypeStaffRequest { get; set; }
        public string comment { get; set; }
    }

    public class ApprovedSalaryDto
    {
        public int nid_request { get; set; }
        public int nid_charger { get; set; }
        public int nid_employee { get; set; }
        public int nlevel { get; set; }
        public int nid_person { get; set; }
        public int nid_area { get; set; }
        public int nid_receptor { get; set; }
        public string names { get; set; }
        public string charge { get; set; }
        public string dni { get; set; }
        public int idTypeStaffRequest { get; set; }
        public int serviciosepulturaporc { get; set; }
        public int serviciofunerarioporc { get; set; }
        public int ceremoniainhumacionporc { get; set; }
        public int otrosporc { get; set; }
        public string comment { get; set; }
    }

    public class ApprovedSureDto
    {
        public int nid_request { get; set; }
        public int nid_charger { get; set; }
        public int nid_employee { get; set; } 
        public int nlevel { get; set; }
        public int nid_person { get; set; }
        public int nid_area { get; set; }
        public int nid_receptor { get; set; }
        public bool IsAfiliate { get; set; }
        public string names { get; set; }
        public string charge { get; set; }
        public string dni { get; set; }
        public int idTypeStaffRequest { get; set; }
        public string comment { get; set; }
    }

    public class RejectSalaryDto
    {
        public int nid_request { get; set; }
        public int nid_person { get; set; }
        public int nid_area { get; set; }
        public int nid_receptor { get; set; }
        public int idTypeStaffRequest { get; set; }
        public int nid_charger { get; set; }
        public int nid_employee { get; set; }
        public int nlevel { get; set; }
        public string comment { get; set; }
    }

    public class RejectAdvacementDto
    {
        public int nid_request { get; set; }
        public int nid_person { get; set; }
        public int nid_area { get; set; }
        public int nid_receptor { get; set; }
        public int idTypeStaffRequest { get; set; }
        public int nid_charger { get; set; }
        public int nid_employee { get; set; }
        public int nlevel { get; set; }
        public string comment { get; set; }
    }

    public class RegisterRequestMedical
    {
        public int nid_request { get; set; }
        public int nid_person { get; set; }
        public int nid_collaborator { get; set; }
        public DateTime dbroadcastdate { get; set; }
        public DateTime ddateinit { get; set; }
        public DateTime ddateend { get; set; }
        public string sdiagnosis { get; set; }

        public string sclinicruc { get; set; }

        public string tutiondoctor { get; set; }

        public string originmedical { get; set; }

        public string typemedical { get; set; }

        public string sdeliverycommitment { get; set; }

        public string semailsocialwelfare { get; set; }
        public string names { get; set; }
        public string lastName { get; set; }
        public string motherLastName { get; set; }
        public string charge { get; set; }
        public string dni { get; set; }

        public StaffRequestDto StaffRequest { get; set; }
        public RegisterRequestMedical()
        {
            StaffRequest = new StaffRequestDto();
        }
    }

    public class RegisterRequestBurial
    {
        public int nid_request { get; set; }
        public int nid_collaborator { get; set; }
        public int nid_person { get; set; }
        public int ntypeservice { get; set; }
        public string observations { get; set; }
        public bool bmeetrequirements { get; set; }
        public string names { get; set; }
        public string lastName { get; set; }
        public string motherLastName { get; set; }
        public string charge { get; set; }
        public string dni { get; set; }
        public bool serviciosepultura { get; set; }
        public bool serviciofunerario { get; set; }
        public bool ceremoniainhumacion { get; set; }
        public bool otros { get; set; }
        public StaffRequestDto StaffRequest { get; set; }
        public RegisterRequestBurial()
        {
            StaffRequest = new StaffRequestDto();
        }
    }

    public class RegisterChangeSureDto
    {
        public int nid_request { get; set; }
        public int nid_collaborator { get; set; }
        public int nid_person { get; set; }
        public int ntypesure { get; set; }
        public int? ntypeeps { get; set; }
        public string names { get; set; }
        public string lastName { get; set; }
        public string motherLastName { get; set; }
        public string charge { get; set; }
        public string dni { get; set; }
        public int nbeneficiary { get; set; }
        public StaffRequestDto StaffRequest { get; set; }
        public RegisterChangeSureDto()
        {
            StaffRequest = new StaffRequestDto();
        }
    }

    public class RegisterHourExtraDto
    {
        public int nid_request { get; set; }
        public int nid_collaborator { get; set; }
        public int nid_person { get; set; }
        public string support { get; set; }
        public DateTime dday { get; set; }
        public string shourinit { get; set; }
        public string shourfinish { get; set; }
        public string names { get; set; }
        public string lastName { get; set; }
        public string motherLastName { get; set; }
        public string charge { get; set; }
        public string dni { get; set; }
        public StaffRequestDto StaffRequest { get; set; }
        public RegisterHourExtraDto()
        {
            StaffRequest = new StaffRequestDto();
        }
    }

    public class RegisterCapacitacionDto
    {
        public int nid_request { get; set; }
        public int nid_collaborator { get; set; }
        public int nid_person { get; set; }
        public int ntypetraining { get; set; }

        public int ntypemodality { get; set; }

        public string sname { get; set; }
        public DateTime ddateinit { get; set; }
        public DateTime ddateend { get; set; }

        public string splace { get; set; }

        public string starget { get; set; }

        public decimal ncost { get; set; }
        public string spercentage { get; set; }

        public string sagreement { get; set; }

        public int nperiod { get; set; }
        public string names { get; set; }
        public string lastName { get; set; }
        public string motherLastName { get; set; }
        public string charge { get; set; }
        public string dni { get; set; }
        public int ntype { get;set; }
        public StaffRequestDto StaffRequest { get; set; }
        public RegisterCapacitacionDto()
        {
            StaffRequest = new StaffRequestDto();
        }
    }

    public class RegisterCapacitacionExtraDto
    {
        public int nid_request { get; set; }
        public int nid_collaborator { get; set; }
        public int nid_person { get; set; }
        public int ntypetraining { get; set; }

        public int ntypemodality { get; set; }

        public string sname { get; set; }
        public string sorganizer { get; set; }
        public DateTime ddateinit { get; set; }
        public DateTime ddateend { get; set; }

        public string splace { get; set; }
        public string schedule { get; set; }
        public string starget { get; set; }

        public decimal ncostevent { get; set; }
        public decimal ncostpassage { get; set; }
        public decimal ncostaccommodation { get; set; }
        public decimal ncostfeeding { get; set; }
        public string sothercost { get; set; }
        public decimal? nothercost { get; set; }

        public string sbenefits { get; set; }
        public decimal nannualbudget { get; set; }
        public decimal nbudget { get; set; }
        public decimal nsteppedout { get; set; }
        public decimal ninvestment { get; set; }
        public decimal nnewbalance { get; set; }

        public string names { get; set; }
        public string lastName { get; set; }
        public string motherLastName { get; set; }
        public string charge { get; set; }
        public string dni { get; set; }
        public StaffRequestDto StaffRequest { get; set; }
        public RegisterCapacitacionExtraDto()
        {
            StaffRequest = new StaffRequestDto();
        }
    }

    public class RegisterRequestSure
    {
        public int nid_request { get; set; }
        public int nid_collaborator { get; set; }
        public int nid_person { get; set; }
        public bool Isaffiliate { get; set; }
        public int ntypesure { get; set; }
        public string names { get; set; }
        public string lastName { get; set; }
        public string motherLastName { get; set; }
        public string charge { get; set; }
        public string dni { get; set; }
        public StaffRequestDto StaffRequest { get; set; }
        public int nbeneficiary { get; set; }
        public RegisterRequestSure()
        {
            StaffRequest = new StaffRequestDto();
        }
    }

    public class RegisterRequestSalary
    {
        public int nid_request { get; set; }
        public int nid_collaborator { get; set; }
        public int nid_person { get; set; }
        public DateTime ddatechange { get; set; }
        public string sbank { get; set; }
        public string saccountnumber { get; set; }
        public string names { get; set; }
        public string lastName { get; set; }
        public string motherLastName { get; set; }
        public string charge { get; set; }
        public string dni { get; set; }
        public StaffRequestDto StaffRequest { get; set; }
        public RegisterRequestSalary()
        {
            StaffRequest = new StaffRequestDto();
        }
        public string saccountccinumber { get; set; }
        public string scurrency { get; set; }

        public string sdestincurrency { get; set; }
        public string sbankdestin { get; set; }
    }

    public class ListBank
    {
        public int nid_bank { get; set; }
        public string sname { get; set; }
    }

    public class EmployeeChildren
    {
        public int nid_employee { get; set; }
        public string sfullname { get; set; }
    }

    public class CategoryRequest
    {
        public int nid_category_request { get; set; }
        public string sname { get; set; }
        public string simage { get; set; }
        public bool bactive { get; set; }
    }

    public class ListRequestByCategory
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class GetRequestMedicalById
    {
        public int nid_medical { get; set; }

        public int nid_request { get; set; }

        public int nid_collaborator { get; set; }
        public DateTime ddateregister { get; set; }

        public DateTime dbroadcastdate { get; set; }

        public DateTime ddateinit { get; set; }

        public DateTime ddateend { get; set; }

        public string sdiagnosis { get; set; }

        public string sclinicruc { get; set; }

        public string tuitiondoctor { get; set; }

        public string originmedical { get; set; }

        public string typemedical { get; set; }

        public string listmedical { get; set; }

        public string sdeliverycommitment { get; set; }

        public string semaisocialwelfare { get; set; }
        public int nstate { get; set; }

        public int nid_person { get; set; }

        public string sfullname { get; set; }

        public string snamecharge { get; set; }

        public int nid_area { get; set; }

        public string snamearea { get; set; }

        public DateTime dadmissiondate { get; set; }

        public string sidentification { get; set; }
        public string scodemployee { get; set; }
        public string PathSignature { get; set; }
    }

    public class GetRequestTypeSureById
    {
        public int nid_request_typesure { get; set; }
        public int nid_request { get; set; }

        public int nid_collaborator { get; set; }
        public int nid_typesure { get; set; }
        public int? nid_typeeps { get; set; }
        public int nstate { get; set; }

        public int nid_person { get; set; }

        public string sfullname { get; set; }

        public string snamecharge { get; set; }

        public int nid_area { get; set; }

        public string snamearea { get; set; }

        public DateTime dadmissiondate { get; set; }

        public string sidentification { get; set; }
        public string scodemployee { get; set; }
        public string scompany { get; set; }
        public string snameeps { get; set; }
        public DateTime dregister { get; set; }
        public string sfile { get; set; }
        public int nbeneficiary { get; set; }
        public string scomment { get; set; }
        public string sdescriptionplan { get; set; }
    }

    public class GetRequestHourExtraById
    {
        public int nid_hours_extra { get; set; }
        public int nid_request { get; set; }

        public int nid_collaborator { get; set; }
        public string support { get; set; }
        public DateTime dday { get; set; }
        public string shourinit { get; set; }
        public string shourfinish { get; set; }
        public string sfileUrl { get; set; }
        public int nstate { get; set; }

        public int nid_person { get; set; }

        public string sfullname { get; set; }

        public string snamecharge { get; set; }

        public int nid_area { get; set; }

        public string snamearea { get; set; }

        public DateTime dadmissiondate { get; set; }

        public string sidentification { get; set; }
        public string scodemployee { get; set; }
        public DateTime dregister { get; set; }
    }

    public class GetStaffCapacitationNuevByIdDto
    {
        public int nid_training { get; set; }

        public int nid_collaborator { get; set; }

        public int nid_request { get; set; }

        public int ntypetraining { get; set; }

        public string stypetraining { get; set; }
        public int ntypemodality { get; set; }

        public string stypemodality { get; set; }

        public string sname { get; set; }

        public DateTime ddateinit { get; set; }

        public DateTime ddateend { get; set; }

        public string splace { get; set; }

        public string starget { get; set; }

        public decimal ncost { get; set; }
        public string spercentage { get; set; }

        public string sagreement { get; set; }
        public int nperiod { get; set; }

        public int nstate { get; set; }

        public DateTime dregister { get; set; }
        public string scodemployee { get; set; }

        public int nid_person { get; set; }

        public string sfullname { get; set; }

        public string snamecharge { get; set; }

        public int nid_area { get; set; }

        public string snamearea { get; set; }

        public DateTime dadmissiondate { get; set; }
        public string sidentification { get; set; }
        public int nid_company { get; set; }

        public string snamecompany { get; set; }

        public string sruc { get; set; }

        public string snametypesure { get; set; }
        public int ntype { get;set; }
        public string sntype { get; set; }
        public string PathSignature { get; set; }
        public string scomment { get; set; }
    }

    public class GetStaffCapacitationExtraByIdDto
    {
        public int nid_extemporaneous { get; set; }

        public int nid_collaborator { get; set; }

        public int nid_request { get; set; }

        public int ntypetraining { get; set; }

        public string stypetraining { get; set; }
        public int ntypemodality { get; set; }

        public string stypemodality { get; set; }

        public string sname { get; set; }
        public string sorganizer { get; set; }

        public DateTime ddateinit { get; set; }

        public DateTime ddateend { get; set; }

        public string splace { get; set; }
        public string schedule { get; set; }
        public string starget { get; set; }

        public decimal ncostevent { get; set; }

        public decimal ncostpassage { get; set; }

        public decimal ncostaccommodation { get; set; }

        public decimal ncostfeeding { get; set; }

        public string sothercost { get; set; }

        public decimal? nothercost { get; set; }

        public string sbenefits { get; set; }
        public decimal nannualbudget { get; set; }

        public decimal nbudget { get; set; }

        public decimal nsteppedout { get; set; }

        public decimal ninvestment { get; set; }

        public decimal nnewbalance { get; set; }

        public decimal ntotal { get; set; }
        public string PathSignature { get; set; }


        public int nstate { get; set; }

        public DateTime dregister { get; set; }
        public string scodemployee { get; set; }

        public int nid_person { get; set; }

        public string sfullname { get; set; }

        public string snamecharge { get; set; }

        public int nid_area { get; set; }

        public string snamearea { get; set; }

        public DateTime dadmissiondate { get; set; }
        public string sidentification { get; set; }
        public int nid_company { get; set; }

        public string snamecompany { get; set; }

        public string sruc { get; set; }

        public string snametypesure { get; set; }
        public string scomment { get; set; }
    }

    public class GetStaffSureById
    {
        public int nid_sure { get; set; }
        public int nid_request { get; set; }
        public string sfile { get; set; }
        public int nid_collaborator { get; set; }
        public bool Isaffiliate { get; set; }
        public int ntypesure { get; set; }
        public int nstate { get; set; }
        public DateTime dregister { get; set; }
        public string scodemployee { get; set; }
        public int nid_person { get; set; }
        public string sfullname { get; set; }
        public string snamecharge { get; set; }
        public int nid_area { get; set; }
        public string snamearea { get; set; }
        public string snamecompany { get; set; }
        public string scompanyruc { get; set; }
        public string snametypesure { get; set; }
        public DateTime ddateissue { get; set; }
        public DateTime dadmissiondate { get; set; }
        public string sidentification { get; set; }
        public string PathSignature { get; set; }
        public int nbeneficiary { get; set; }
        public string scomment { get; set; }
        public string stypebeneficiary { get; set; }

    }

    public class GetStaffSalaryById
    {
        public int nid_salaryaccount { get; set; }

        public int nid_request { get; set; }

        public int nid_collaborator { get; set; }

        public DateTime ddatechange { get; set; }
        public string sbank { get; set; }

        public string saccountnumber { get; set; }

        public string scodemployee { get; set; }

        public int nid_person { get; set; }

        public string sfullname { get; set; }

        public string snamecharge { get; set; }

        public int nid_area { get; set; }

        public string snamearea { get; set; }

        public DateTime dadmissiondate { get; set; }
        public string sidentification { get; set; }
        public int nstate { get; set; }
        public string BankingEntityCurrent { get; set; }
        public string BankingEntityChange { get; set; }
        public string sdniurl { get; set; }

        public string snamemonth { get; private set; }
        public string sdateissuetext { get; private set; }
        public string spathsignature { get; set; }
        public string sfile { get; set; }
        public string saccountccinumber { get; set; }
        public string scurrency { get; set; }
        public string scomment { get; set; }
        public string sdestincurrency { get; set; }
        public string sbankdestin { get; set; }
        public string code_bank_origen { get; set; }
        public string bank_origen { get; set; }
        public string code_bank_destino { get; set; }
        public string bank_destino { get; set; }
        public int period_cta_mm { get; set; }
        public int period_cta_yyyy { get; set; }
        public DateTime date_request_cta { get; set; }
        public void SetNameMonth()
        {

        }
        public void SetDateIssueInText()
        {
            sdateissuetext = $"{ddatechange.Day} de {snamemonth} del {ddatechange.Year}";
        }
    }

    public class GetStaffBurialByIdDto
    {
        public int nid_request { get; set; }
        public string stypeservice { get; set; }
        public string smeetrequirements { get; set; }
        public int nid_collaborator { get; set; }
        public int ntypeservice { get; set; }
        public string sobservations { get; set; }
        public bool bmeetrequirements { get; set; }
        public string scodemployee { get; set; }

        public int nid_person { get; set; }

        public string sfullname { get; set; }

        public string snamecharge { get; set; }

        public int nid_area { get; set; }

        public string snamearea { get; set; }

        public DateTime dadmissiondate { get; set; }
        public string sidentification { get; set; }
        public int nstate { get; set; }
        public string snametypeservice { get; set; }
        public string scellphone { get; set; }
        public string stateevaluation { get; set; }
        public DateTime dateevaluation { get; set; }
        public string spathsignature { get; set; }
        public DateTime dregister { get; set; }
        public bool serviciosepultura { get; set; }
        public bool serviciofunerario { get; set; }
        public bool ceremoniainhumacion { get; set; }
        public bool otros { get; set; }
        public int serviciosepulturaporc { get; set; }
        public int serviciofunerarioporc { get; set; }
        public int ceremoniainhumacionporc { get; set; }
        public int otrosporc { get; set; }
        public string scomment { get; set; }
    }

    public class DeleteStaffRequestDto
    {
        public int nid_request { get; set; }
    }

    public class StaffRequestFromNotificacionFilter
    {
        public int nid_staff_request { get; set; }
        public int nid_user { get; set; }

    }


    public class StaffRequestValidateDaysRequest
    {
        public int nidemployee { get; set; }

    }

}
