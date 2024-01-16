using HumanManagement.Domain.Common;
using HumanManagement.Domain.MasterTable.Dto;
using HumanManagement.Domain.Person.Dto;
using HumanManagement.Domain.Person.QueryFilter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Person.Contracts
{
    public interface IPersonRepository
    {
        Task<PersonDto> GetPerson(int Id);
        Task<List<ListPhoneDto>> GetListPhone(int Id);

        Task<ResultPaginationListDto<PostulantDto>> GetListPostulant(PostulantQueryFilter postulantQueryFilter);
        Task<List<PostulantInternalDto>> GetListPostulantExport(PostulantQueryFilter postulantQueryFilter);
        Task<int> InsertAddressPerson(string sdepartment, string sprovince, string sdistrict, string saddress, int nidperson);
        Task<int> InsertAcademicPerson(string stipoacademico, string sinstitucion, string sconcluido, DateTime? dfechaobtencion, DateTime? dfechavencimiento
            , string suprofesion, string stitulo, string scodemployee);
        Task<int> InsertAddressPersonByUbigeo(string subigeo, string saddress, int nidperson);
        Task<List<Postulant.Person.Dto.PostulantSkillsDto>> GetListSkillInternal(int nidJob);
        Task<List<Postulant.WorkExperience.Dto.WorkExperienceDto>> GetWorkExperiencePostulantsInternal(int nidJob);
        Task<int> RegisterBackupEmpleado(string scodperson);
        Task<int> RegistrarPersonaCesada(string scodperson);
        Task<int> RegistrarProcesoServicio(ServiceProcessDto request);
        Task<ServiceProcessDto> ConsultarProcesoServicio(ServiceProcessDto request);

    }
}
