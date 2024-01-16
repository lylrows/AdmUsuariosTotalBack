using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Contact.Dto
{
    public class ContactListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Reason { get; set; }
        public string Photo_url { get; set; }
        public int Id_Employee { get; set; }
        public bool Active { get; set; }
        public string Extension { get; set; }
        public string Email { get; set; }
    }
}
