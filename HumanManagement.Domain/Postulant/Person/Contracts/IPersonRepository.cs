using HumanManagement.Domain.Common;
using HumanManagement.Domain.Postulant.Person.Dto;
using HumanManagement.Domain.Postulant.Person.QueryFilter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Postulant.Person.Contracts
{
    public interface IPersonRepository
    {
        Task<PersonDto> GetPerson(int Id);
        Task<PersonExactusDto> GetPersonDataExactus(int Id);
        Task<int> SaveCv(PersonCvDto dto);
        Task<int> SaveImg(PersonCvDto dto);
        Task<int> DeleteCv(int IdPerson);
        Task<ResultPaginationListDto<PostulantDto>> GetListPostulant(PostulantQueryFilter postulantQueryFilter);
        Task<List<PostulantDto>> GetListPostulantExport(PostulantQueryFilter postulantQueryFilter);
       
    }
}
