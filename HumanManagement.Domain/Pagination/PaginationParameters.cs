using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace HumanManagement.Domain.Organigram.Pagination
{
    public class PaginationParameters<T> where T : class
    {
        public LambdaExpression ColumnOrder { get; set; }
        public int Start { get; set; }
        public int AmountRows { get; set; }
        public Expression<Func<T, bool>> WhereFilter { get; set; }
        public Func<IQueryable<T>, IIncludableQueryable<T, object>> Includes { get; set; }
    }
}