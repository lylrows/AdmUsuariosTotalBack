using HumanManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Contact.QueryFilter
{
    public class ContactQueryFilter
    {
        public PaginationEntity Pagination { get; set; }
        public ContactQueryFilter()
        {
            Pagination = new PaginationEntity();
        }
    }
}
