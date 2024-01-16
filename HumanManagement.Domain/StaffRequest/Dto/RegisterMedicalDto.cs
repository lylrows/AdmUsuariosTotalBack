using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.StaffRequest.Dto
{
    public class RegisterMedicalDto
    {
		public int ntype { get; set; }
		public int nid_collaborator { get; set; }
		public DateTime dregisterdm { get; set; }
		public DateTime dissuedm { get; set; }
		public DateTime ddateinitdm { get; set; }
		public DateTime ddateenddm { get; set; }
		public string smedicaldiagnostic { get; set; }
		public string srucclinic { get; set; }
		public string tuitiondoctor { get; set; }
		public int noriginmedical { get; set; }
		public int ntypedm { get; set; }
        public string scodtypeaction { get; set; }
        public string scodtypeabsence { get; set; }
        public string scommitment { get; set; }
		public int nid_person { get; set; }
		public string names { get; set; }
		public string lastName { get; set; }
		public string motherLastName { get; set; }
		public string charge { get; set; }
		public string dni { get; set; }
		public bool bisDraft { get; set; }

	}

	public class RegisterDocumentMedicalDto
    {
		public int nid_medical { get; set; }
		public int ntype_doc { get; set; }
		public int ndocument { get; set; }
	}

	public class RegisterDocumentMedicalMasiveDto
	{
		public int nid_medical { get; set; }
        public int ntype_doc { get; set; }
        public List<DocumentMedicalDto> lstdocument { get; set; }

    }

	public class ValidDocumentMedicalDto
    {
		public int nid { get; set; }
		public int nstate { get; set; }

	}

	public class ValidChangeStateMedical
    {
		public int nid_medical { get; set; }
		public int nstate { get; set; }
		public int ntype { get; set; }

        public int nid_originmdical { get; set; }
    }

	public class UpdateFilesDto
    {
		public int nid { get; set; }

	}

	public class ValidDocumentControllDto
    {
		public int nid_medical { get; set; }
		public string sfullname { get; set; }
		public int idArea { get; set; }
		public int receptorId { get; set; }
		public int emisorId { get; set; }
		public int ntype { get; set; }
        public int nid_originmdical { get; set; }
        public List<ValidDocumentMedicalDto> list { get; set; }
	}
	public class ObserveMasiveDocumentDto
	{
        public int nid_medical { get; set; }
        public List<ObserveDocumentDto> listdocument { get; set; }
    }
	public class ObserveDocumentDto {
        public int nid_document_medical { get; set; }
        public string scomment { get; set; }
    }

	public class FilterListDocumentDto
    {
		public int nid_employee { get; set; }
		public int ntype { get; set; }
		public DateTime ddateinit { get; set; }
		public DateTime ddateend { get; set; }

	}

	public class MedicalDto
    {
		public int nid_medical { get; set; }
		public int ntype { get; set; }
		public string stype { get; set; }
		public int nid_collaborator { get; set; }
		public string sfullname { get; set; }
		public DateTime dregisterdm { get; set; }
		public DateTime dissuedm { get; set; }
		public DateTime ddateinitdm { get; set; }
		public DateTime ddateenddm { get; set; }
		public string smedicaldiagnostic { get; set; }
		public string srucclinic { get; set; }
		public string tuitiondoctor { get; set; }
		public int noriginmedical { get; set; }
		public string soriginmedical { get; set; }
		public int ntypedm { get; set; }
		public string stypedm { get; set; }
		public string scommitment { get; set; }
		public int nstatedocument { get; set; }
		public string sstatedocument { get; set; }
		public int ndaysdocument { get; set; }
		public string scolordocument { get; set; }
		public bool? bregisterviva { get; set; }
		public int? ndaysregisterviva { get; set; }
		public string scolorregisterviva { get; set; }
		public bool? bhaveCIT { get; set; }
		public string snitt { get; set; }
		public string sobervationscitt { get; set; }
		public string sfilecitt { get; set; }
		public string snumberCIT { get; set; }
		public int? ndaysCIT { get; set; }
		public string scolorCIT { get; set; }
		public bool? bhaveamount { get; set; }
		public decimal? namount { get; set; }
		public int? ndaysAmount { get; set; }
		public string scolorAmount { get; set; }
		public int nstate { get; set; }
		public string sstate { get; set; }
		public string soperationnumber { get; set;}	
		public string sfileregisterviva { get; set; }
		public string scodtypeaction	{ get; set; }
		public string scodtypeabsence { get; set; }
        public bool? bexistexatus { get; set; }
        public int? nactionexactus { get; set; }
        public string sareaname { get; set; }
        public string sdni { get; set; }
        public string sdatedocument { get; set; }

		public string ssede { get; set; }
		public int nyear { get; set; }
		public int ndays { get; set; }
        public DateTime? ddateCIT { get; set; }
        public decimal? nunreturnamount { get; set; }
        public string sobservationamount { get; set; }
        public decimal? ngeneratedamount { get; set; }
        public decimal? amountnoreturned { get; set; }

    }

	public class ApprovalDateDto
	{
		public int nid_collaborator { get; set; }
		public Nullable<DateTime> approvalcurrentperiod { get; set; }
		public Nullable<DateTime> approvalpreviousperiod { get; set; }


	}

	public class DocumentMedicalDto
    {
		public int nid_document_medical { get; set; }
		public int nid_medical { get; set; }
		public int ntype_doc { get; set; }
		public int ndocument { get; set; }
		public string sdocument { get; set; }
		public string sfile { get; set; }
		public int nstate { get; set; }
        public bool bbreak_requiredfile { get; set; }
        public string scommentobserve { get; set; }

    }
	
	public class GetDaysDto
    {
		public int ndays { get; set; }

	}

	public class BossDto
	{
		public int nid_employee { get; set; }
		public string sfullname { get; set; }

	}

	public class ReportAmountDto
	{
		public int amount_generated { get; set; }
		public int amount_charged { get; set; }
		public int amount_loading { get; set; }
		public int amount_perdido { get; set; }
	}

	public class ReportGraficStatus
	{
        
        public decimal Value { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }

	public class ReportGraficEtapa
	{
		public int etapa1 { get; set; }
		public int etapa2 { get; set; }
		public int etapa3 { get; set; }
		public int etapa4 { get; set; }
	}

	public class ListMedicalNotification
    {
		public int nid_person { get; set; }
		public string sfullname { get; set; }
		public int nid_area { get; set; }
		public int nid_charge { get; set; }
		public string snamecharge { get; set; }
		public int nid_profile { get; set; }
	}

	public class UpdateVIVAMedical
    {
		public int nid_medical { get; set; }
		public string soperationnumber { get; set; }
		
		public string snitt { get; set; }
	}

	public class UpdateCITTMedicalDto
	{
		public int nid_medical { get; set; }
		public string snumberCITT { get; set; }
        
        public string snitt { get; set; }
        public string sobervationscitt { get; set; }
        public DateTime ddateCIT { get; set; }

    }

	public class UpdateAmountMedicalDto
	{
		public int nid_medical { get; set; }
		public decimal namount { get; set; }
		public decimal nunreturnamount { get; set; }
        public string sobservationamount { get; set; }

    }

	public class RejectMedicalDto
	{
		public int nid_medical { get; set; }
		public string sfullname { get; set; }
		public string scomment { get; set; }
		public int idArea { get; set; }
		public int receptorId { get; set; }
		public int emisorId { get; set; }

	}

	public class ReportGraficFilter
	{
		public DateTime ddateinit { get; set; }
		public DateTime ddateend { get; set; }

	}

    public class RequestDocumentApprovedDto
    {
        public int nid_document_medical { get; set; }

    }

}
