namespace HumanManagement.Domain.Utils.Dto
{
    public class InformationFilesDto
    {
        public int nidinformationfile { get; set; }
        public int nidinformationextra { get; set; }
        public int? nidreferences { get; set; }
        public string snamefile { get; set; }
        public string skeyfile { get; set; }
        public int ntypefile { get; set; }
        public bool bactive { get; set; }

        public string stypeFile { get; set; }
        public string base64 { get; set; }
        public string path_complete { get; set; }
    }
}
