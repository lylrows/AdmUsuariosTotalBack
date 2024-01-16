

namespace HumanManagement.Domain.Notification.Dto
{
    public class NotificationFilterFichaDto
    {
        public int IdEvaluation { get; set; }
        public int IdPostulant { get; set; }
        public string PostulantType { get; set; }
        public int Level { get; set; }
        public string CompleteName { get; set; }
    }

    public class NotificationFichaDto
    {
        public int IdPerson { get; set; }
        public int IdArea { get; set; }
    }
}
