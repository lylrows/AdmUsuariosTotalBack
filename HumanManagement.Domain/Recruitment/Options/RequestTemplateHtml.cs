namespace HumanManagement.Domain.Recruitment.Options
{
    public class RequestTemplateHtml
    {
        public string RequestToApplicant { get; set; }
        public string RequestToEvaluator { get; set; }
        public string RequestAccepted { get; set; }
        public string RequestRejected { get; set; }
        public string UrlRequest { get; set; }
        public string UrlRequestNew { get; set; }
    }
}
