using HumanManagement.Domain.Mail.Dto;
using HumanManagement.Domain.Recruitment.Enum;
using System;

namespace HumanManagement.Domain.Recruitment.Dto
{
    public class RequestMailDto : MailBaseDto
    {
        public int IdRequest { get; set; }
        public string RequestNumber { get; set; }
        public string Company { get; set; }
        public string Area { get; set; }
        public string Charge { get; set; }
        public DateTime DateRegister { get; set; }
        public string UrlRequest { get; private set; }
        public TypeMailRequest TypeMailRequest { get; set; }

        public void SetTypeMailRequest(TypeMailRequest typeMailRequest)
        {
            TypeMailRequest = typeMailRequest;
        }
        public void SetUrlRequest(string urlRequest)
        {
            UrlRequest = $"{urlRequest}/{IdRequest}";
        }
    }
}
