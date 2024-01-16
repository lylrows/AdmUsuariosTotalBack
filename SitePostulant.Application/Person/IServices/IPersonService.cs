using HumanManagement.Domain.Postulant.Person.Dto;
using Microsoft.AspNetCore.Http;
using SitePostulant.Application.Response;
using System.Threading.Tasks;

namespace SitePostulant.Application.Person.IServices
{
    public interface IPersonService
    {
        Task<Result> GetById(int id);
        Task<Result> UpdatePersonalInformation(PersonDto personDto);
        Task<Result> UpdateContactInformation(PersonDto personDto);
        Task<Result> SaveImg(PersonCvDto dto, IFormFile formFile);
        Task<Result> SaveCv(PersonCvDto dto, IFormFile formFile);
        Task<Result> DeleteCv(int IdPerson);
    }
}
