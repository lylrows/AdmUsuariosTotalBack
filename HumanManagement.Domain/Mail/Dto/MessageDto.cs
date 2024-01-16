using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HumanManagement.Domain.Mail.Dto
{
    public class MessageDto
    {
        public string Subject { get; set; }
        public string Classification { get; set; }
        public  BodyDto Body { get; set; }
        public List<AttachmentDto> Attachment { get; set; }
    }
}
