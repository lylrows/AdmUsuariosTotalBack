using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Mail.Dto
{
    public class MailRequestDto
    {
        public string FromName { get; set; }
        public string From { get; set; }
        public List<string> To { get; set; }
        public List<string> Cc { get; set; }
        public List<string> Bcc { get; set; }
        public MessageDto Message { get; set; }
        public OptionsDto Options { get; set; }
        public MailRequestDto()
        {
            To = new List<string>();
            Cc = new List<string>();
            Bcc = new List<string>();
        }

    }
}
