using Dapper;
using HumanManagement.Domain.Common;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.MasterTable.Dto;
using HumanManagement.Domain.Person.Contracts;
using HumanManagement.Domain.Person.Dto;
using HumanManagement.Domain.Person.QueryFilter;
using HumanManagement.Domain.Postulant.WorkExperience.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        public PersonRepository(IHumanManagementReadDbConnection humanManagementReadDbConnection)
        {
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
        }
        public async Task<List<ListPhoneDto>> GetListPhone(int Id)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_person", Id);
            var listphone = await humanManagementReadDbConnection.QueryAsync<ListPhoneDto>(
                "sp_phone_byperson",
                queryParameters, commandType: CommandType.StoredProcedure);
            return listphone.ToList();

        }

        public async Task<ResultPaginationListDto<PostulantDto>> GetListPostulant(PostulantQueryFilter postulantQueryFilter)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_job", postulantQueryFilter.IdJob);
            queryParameters.Add("@estudios", postulantQueryFilter.Estudios);
            queryParameters.Add("@universidad", postulantQueryFilter.Universidad);
            queryParameters.Add("@edadmin", postulantQueryFilter.EdadMinima);
            queryParameters.Add("@edadmax", postulantQueryFilter.EdadMaxima);
            queryParameters.Add("@experiencia", postulantQueryFilter.Experiencia);
            queryParameters.Add("@salarymin", postulantQueryFilter.SalarioMinimo);
            queryParameters.Add("@salarymax", postulantQueryFilter.SalarioMaximo);
            queryParameters.Add("@gender", postulantQueryFilter.Genero);
            queryParameters.Add("@isworking", postulantQueryFilter.IsWorking);
            queryParameters.Add("@keywords", postulantQueryFilter.KeyWords);
            queryParameters.Add("@levelstudy", postulantQueryFilter.LevelStudy);

            queryParameters.Add("@ncurrentpage", postulantQueryFilter.pagination.CurrentPage);
            queryParameters.Add("@nitemsperPage", postulantQueryFilter.pagination.ItemsPerPage);
            queryParameters.Add("@nrecordcount", DbType.Int32, direction: ParameterDirection.Output);
            var result = await humanManagementReadDbConnection.QueryAsync<PostulantDto>(
                "sps_tb_get_postulant_list",
                queryParameters, commandType: CommandType.StoredProcedure);

            int totalItems = Convert.ToInt32(queryParameters.Get<int>("@nrecordcount"));

            return new ResultPaginationListDto<PostulantDto>
            {
                list = result.ToList(),
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / postulantQueryFilter.pagination.ItemsPerPage)
            };
        }
        
        public async Task<List<PostulantInternalDto>> GetListPostulantExport(PostulantQueryFilter postulantQueryFilter)
        {
            List<PostulantInternalDto> lista = new List<PostulantInternalDto>();
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_job", postulantQueryFilter.IdJob);
            queryParameters.Add("@estudios", postulantQueryFilter.Estudios);
            queryParameters.Add("@universidad", postulantQueryFilter.Universidad);
            queryParameters.Add("@edadmin", postulantQueryFilter.EdadMinima);
            queryParameters.Add("@edadmax", postulantQueryFilter.EdadMaxima);
            queryParameters.Add("@experiencia", postulantQueryFilter.Experiencia);
            queryParameters.Add("@salarymin", postulantQueryFilter.SalarioMinimo);
            queryParameters.Add("@salarymax", postulantQueryFilter.SalarioMaximo);
            queryParameters.Add("@gender", postulantQueryFilter.Genero);
            queryParameters.Add("@isworking", postulantQueryFilter.IsWorking);
            queryParameters.Add("@keywords", postulantQueryFilter.KeyWords);
            queryParameters.Add("@levelstudy", postulantQueryFilter.LevelStudy);

            queryParameters.Add("@ncurrentpage", postulantQueryFilter.pagination.CurrentPage);
            queryParameters.Add("@nitemsperPage", postulantQueryFilter.pagination.ItemsPerPage);
            queryParameters.Add("@nrecordcount", DbType.Int32, direction: ParameterDirection.Output);
            var result = await humanManagementReadDbConnection.QueryAsync<PostulantInternalDto>(
                "sps_tb_get_postulant_list",
                queryParameters, commandType: CommandType.StoredProcedure);

            int totalItems = Convert.ToInt32(queryParameters.Get<int>("@nrecordcount"));

            lista = result.ToList();

            return lista;
        }

        public async Task<PersonDto> GetPerson(int Id)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_person", Id);
            var person = await humanManagementReadDbConnection.QueryAsync<PersonDto>(
                "sp_person_byid",
                queryParameters, commandType: CommandType.StoredProcedure);
            return (PersonDto)person[0];
        }
        /// <summary>
        /// PROCEDIMIENTO PARA REGISTRAR LA DIRECCION DE UNA PERSONA
        /// </summary>
        /// <param name="sdepartment"></param>
        /// <param name="sprovince"></param>
        /// <param name="sdistrict"></param>
        /// <param name="saddress"></param>
        /// <param name="nidperson"></param>
        /// <returns></returns>
        public async Task<int> InsertAddressPerson(string sdepartment, string sprovince, string sdistrict, string saddress, int nidperson)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@sdepartment", sdepartment);
            queryParameters.Add("@sprovince", sprovince);
            queryParameters.Add("@sdistrict", sdistrict);
            queryParameters.Add("@saddress", saddress);
            queryParameters.Add("@nidperson", nidperson);

            var person = await humanManagementReadDbConnection.QueryAsync<int>(
                "spi_addresspersonbynames",
                queryParameters, commandType: CommandType.StoredProcedure);
            return person.FirstOrDefault();
        }


        public async Task<int> InsertAddressPersonByUbigeo(string subigeo, string saddress, int nidperson)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@subigeo", subigeo);
            queryParameters.Add("@saddress", saddress);
            queryParameters.Add("@nidperson", nidperson);

            var person = await humanManagementReadDbConnection.QueryAsync<int>(
                "spi_addresspersonbyubigeo",
                queryParameters, commandType: CommandType.StoredProcedure);
            return person.FirstOrDefault();
        }

        public async Task<int> RegisterBackupEmpleado(string scodperson)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@scodperson", scodperson);
            

            var person = await humanManagementReadDbConnection.QueryAsync<int>(
                "spi_registerbackupempleado",
                queryParameters, commandType: CommandType.StoredProcedure);
            return person.FirstOrDefault();
        }


        public async Task<int> InsertAcademicPerson(string stipoacademico, string sinstitucion, string sconcluido, DateTime? dfechaobtencion,DateTime? dfechavencimiento
            ,string suprofesion, string stitulo,string  scodemployee)
        {
            var queryParameters = new DynamicParameters();



            queryParameters.Add("@stipoacademico"         ,stipoacademico       );
            queryParameters.Add("@sinstitucion"           ,sinstitucion         );
            queryParameters.Add("@sconcluido"             ,sconcluido           );
            queryParameters.Add("@dfechaobtencion"        ,dfechaobtencion      );
            queryParameters.Add("@dfechavencimiento"      ,dfechavencimiento    );
            queryParameters.Add("@suprofesion"            ,suprofesion          );
            queryParameters.Add("@stitulo"                ,stitulo              );
            queryParameters.Add("@scodemployee"           , scodemployee        );



            var person = await humanManagementReadDbConnection.QueryAsync<int>(
                "spi_academicemployee",
                queryParameters, commandType: CommandType.StoredProcedure);
            return person.FirstOrDefault();
        }

        public async Task<List<Domain.Postulant.Person.Dto.PostulantSkillsDto>> GetListSkillInternal(int nidJob)
        {
            List<Domain.Postulant.Person.Dto.PostulantSkillsDto> lista = new List<Domain.Postulant.Person.Dto.PostulantSkillsDto>();
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_job", nidJob);
            var result = await humanManagementReadDbConnection.QueryAsync<Domain.Postulant.Person.Dto.PostulantSkillsDto>(
                "sps_get_skills_postulants_by_job",
                queryParameters, commandType: CommandType.StoredProcedure);

            lista = result.ToList();

            return lista;
        }

        public async Task<List<WorkExperienceDto>> GetWorkExperiencePostulantsInternal(int nidJob)
        {
            List<WorkExperienceDto> lista = new List<WorkExperienceDto>();
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_job", nidJob);
            var result = await humanManagementReadDbConnection.QueryAsync<WorkExperienceDto>(
                "sps_get_work_experiences_postulants_by_job",
                queryParameters, commandType: CommandType.StoredProcedure);

            lista = result.ToList();

            return lista;
        }

        public async Task<int> RegistrarPersonaCesada(string scodperson)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@scodperson", scodperson);


            var person = await humanManagementReadDbConnection.QueryAsync<int>(
                "spi_registrar_cesado",
                queryParameters, commandType: CommandType.StoredProcedure);
            return person.FirstOrDefault();
        }

        //Información para servicio
        public async Task<int> RegistrarProcesoServicio(ServiceProcessDto request)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@scode_service", request.scode_service);
            queryParameters.Add("@nsate", request.nsate);


            var person = await humanManagementReadDbConnection.QueryAsync<int>(
                "spi_registrar_proceso_servicio",
                queryParameters, commandType: CommandType.StoredProcedure);
            return person.FirstOrDefault();
        }

        public async Task<ServiceProcessDto> ConsultarProcesoServicio(ServiceProcessDto request)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@scode_service", request.scode_service);

            var person = await humanManagementReadDbConnection.QueryAsync<ServiceProcessDto>(
                "spi_consultar_proceso_servicio",
                queryParameters, commandType: CommandType.StoredProcedure);
            return person.FirstOrDefault();
        }
    }
}
