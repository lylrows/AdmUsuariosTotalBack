using HumanManagement.Domain.Mail.Dto;
using HumanManagement.Domain.Recruitment.Enum;

namespace HumanManagement.Domain.Recruitment.Dto
{
    public class ResponseMailDto : MailBaseDto
    {
        public int IdRequest { get; set; }
        public string RequestNumber { get; set; }
        public string Comment { get; set; }
        public string UrlRequest { get; set; }
        public string UrlRequestNew { get; set; }
        public int State { get; set; }
        public TypeMailRequest TypeMailRequest { get; set; }

        public void SetTypeMailRequest()
        {
            if (State == 2)
            {
                TypeMailRequest = TypeMailRequest.ResponseAccepted;
            }
            else
            {
                TypeMailRequest = TypeMailRequest.ResponseRejected;
            }
        }

        public void SetUrlRequest(string urlRequest)
        {
            UrlRequest = $"{urlRequest}/{IdRequest}";
        }

        public void SetUrlRequestNew(string url)
        {
            UrlRequestNew = url;
        }
    }
}
