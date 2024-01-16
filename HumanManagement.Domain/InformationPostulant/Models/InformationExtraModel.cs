using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace HumanManagement.Domain.InformationPostulant.Models
{
    public class InformationExtraModel: BaseModel.BaseModel
    {
        [Column("nidinformationextra")]
        public int Id { get; set; }

        [Column("nidpostulant")]
        public int IdPostulant { get; set; }

        [Column("nidevaluation")]
        public int IdEvaluation { get; set; }

        [Column("splaceofbirth")]
        public string PlaceOfBirth { get; set; }

        [Column("bcreatebcp")]
        public bool? CreateBcp { get; set; }

        [Column("srucnumber")]
        public string RucNumber { get; set; }

        [Column("sbankopen")]
        public string BankOpen { get; set; }

        [Column("safp")]
        public string Afp { get; set; }

        [Column("sage")]
        public string Age { get; set; }

        [Column("sbankafp")]
        public string BankAfp { get; set; }

        [Column("scompany")]
        public string Company { get; set; }

        [Column("bmoto")]
        public bool? Moto { get; set; }

        [Column("bauto")]
        public bool? Auto { get; set; }

        [Column("scategorybrevete")]
        public string CategoryBrevete { get; set; }

        [Column("snroreferencia")]
        public string NroReferencia { get; set; }

        [Column("stypesangre")]
        public string TypeSangre { get; set; }

        [Column("idtype_document")]
        public int? IdDocumentType { get; set; }
        [Column("dicome_country_date")]
        public DateTime? IncomeCountryDate { get; set; }
        [Column("sbank_haberes")]
        public string BankHaberes { get; set; }
        [Column("scontact_name")]
        public string NombreContacto { get; set; }
        [Column("scontact_nro_reference")]
        public string NroReferenciaContacto { get; set; }
        [Column("scontact_parentesco")]
        public string ParentescoContacto { get; set; }
        [Column("bdisclaimer")]
        public bool? disclaimer { get; set; }
        [Column("bhas_movility")]
        public bool? hasMobility { get; set; }
        [Column("bhas_disability")]
        public bool? hasDisability { get; set; }
        [Column("bsent")]
        public bool? Sent { get; set; }
    }
}
