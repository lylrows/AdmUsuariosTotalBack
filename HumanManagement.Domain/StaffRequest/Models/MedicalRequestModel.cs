using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.StaffRequest.Models
{
    public class MedicalRequestModel 
    {
        
        public int nid_medical { get; set; }
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
        public string scommitment { get; set; }
        public int nstatedocument { get; set; }
        public bool? bregisterviva { get; set; }
        public bool? bhaveCIT { get; set; }
        public string snumberCIT { get; set; }
        public bool? bhaveamount { get; set; }
        public decimal? namount { get; set; }
        public int nstate { get; set; }
        public DateTime dregister { get; set; }
        public int nuserregister { get; set; }
        public DateTime? dupdate { get; set; }
        public int? nuserupdate { get; set; }
        public DateTime? ddatedocument { get; set; }
        public DateTime? ddateCIT { get; set; }
        public DateTime? ddateamount { get; set; }
        public string soperationnumber { get; set; }
        public string sfileregisterviva { get; set; }
        public string snitt { get; set; }
        public string sobervationscitt { get; set; }
        public string sfilecitt { get; set; }
        public bool? bexistexatus { get; set; }
        public string scodtypeaction { get; set; }
        public string scodtypeabsence { get; set; }
        public int? nactionexactus { get; set; }

    }
}
