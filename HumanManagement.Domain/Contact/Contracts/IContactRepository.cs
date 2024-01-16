using HumanManagement.Domain.Common;
using HumanManagement.Domain.Contact.Dto;
using HumanManagement.Domain.Contact.QueryFilter;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Contact.Contracts
{
    public interface IContactRepository
    {
        Task<ResultPaginationListDto<ContactListDto>> GetListUsersPagination(ContactQueryFilter contactQueryFilter);
    }
}
