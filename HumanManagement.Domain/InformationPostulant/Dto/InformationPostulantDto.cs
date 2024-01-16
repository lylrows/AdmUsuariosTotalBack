namespace HumanManagement.Domain.InformationPostulant.Dto
{
    public class InformationPostulantDto
    {
        public int nid_postulant { get; set; }
        public int nid_evaluation { get; set; }
        public int ndocument_type { get; set; }
        public string typedocument { get; set; }
        public string sdocument_number { get; set; }
        public string fullname { get; set; }
        public string semail { get; set; }
        public string scellphone { get; set; }
        public string stype { get; set; }
    }
}
