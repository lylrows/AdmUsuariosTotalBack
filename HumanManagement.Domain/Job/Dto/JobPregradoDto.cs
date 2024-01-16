using DocumentFormat.OpenXml.Spreadsheet;

namespace HumanManagement.Domain.Job.Dto
{
    public class JobPregradoDto
    {
        public int id { get; set; } 
        public int idjobs { get; set; } 
        public int idrequest { get; set; }
        public int idgrade { get; set; }
        public string scareer { get; set; }
        public string sgrade { get; set; }
    }
}
