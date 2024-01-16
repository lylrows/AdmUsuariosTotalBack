using System.Collections.Generic;
using System.Linq;

namespace HumanManagement.Domain.Organigram.Pagination
{
    public class PaginationResult<T> where T : class
    {
        public int Count { get; set; }

        public IQueryable<T> Entities { get; set; }

        public IEnumerable<T> List { get; set; }
    }
}
