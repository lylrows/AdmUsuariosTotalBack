using Dapper;
using HumanManagement.Domain.Common;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Job.Dto;
using HumanManagement.Domain.Postulant.Person.Contracts;
using HumanManagement.Domain.Postulant.Person.Dto;
using HumanManagement.Domain.Postulant.Person.QueryFilter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository.Postulant.Person
{
    public class PersonRepository: IPersonRepository
    {
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        private readonly IHumanManagementDbContext connetion;
        public PersonRepository(IHumanManagementReadDbConnection humanManagementReadDbConnection, IHumanManagementDbContext connetion)
        {
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
            this.connetion = connetion;
        }

        public async Task<int> DeleteCv(int IdPerson)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_person", IdPerson);
            var result = await connetion.Connection.ExecuteAsync(
                 "recruitment.spu_delete_cv_postulant",
                 queryParameters, null, null, CommandType.StoredProcedure);

            return result;
        }

        public async Task<PersonDto> GetPerson(int Id)
        {
            try
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@nid_person", Id);
                var person = await humanManagementReadDbConnection.QueryAsync<PersonDto>(
                    "recruitment.sp_person_byid",
                    queryParameters, commandType: CommandType.StoredProcedure);
                return (PersonDto)person[0];
            }
            catch (Exception ex)
            {

                return new PersonDto();
            }
        }


        public async Task<PersonExactusDto> GetPersonDataExactus(int Id)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_person", Id);
            var person = await humanManagementReadDbConnection.QueryAsync<PersonExactusDto>(
                "recruitment.sp_personexactus_byid",
                queryParameters, commandType: CommandType.StoredProcedure);
            return (PersonExactusDto)person[0];
        }

        public async Task<int> SaveCv(PersonCvDto dto)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nidperson", dto.IdPerson);
            queryParameters.Add("@namefile", dto.Name);
            queryParameters.Add("@namefolder", dto.Folder);
            var result = await connetion.Connection.ExecuteAsync(
                 "recruitment.spu_savecv_person",
                 queryParameters, null, null, CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> SaveImg(PersonCvDto dto)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nidperson", dto.IdPerson);
            queryParameters.Add("@namefolder", dto.Folder);
            var result = await connetion.Connection.ExecuteAsync(
                 "recruitment.spu_saveimg_person",
                 queryParameters, null, null, CommandType.StoredProcedure);

            return result;
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
            queryParameters.Add("@ninclude_param", postulantQueryFilter.IncludeFilterQuery);
            queryParameters.Add("@nrecordcount", DbType.Int32, direction: ParameterDirection.Output);
            var result = await humanManagementReadDbConnection.QueryAsync<PostulantDto>(
                "recruitment.sps_tb_person_get_postulant_list",
                queryParameters, commandType: CommandType.StoredProcedure);

            int totalItems = Convert.ToInt32(queryParameters.Get<int>("@nrecordcount"));

            return new ResultPaginationListDto<PostulantDto>
            {
                list = result.ToList(),
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / postulantQueryFilter.pagination.ItemsPerPage)
            };
        }

        public async Task<List<PostulantDto>> GetListPostulantExport(PostulantQueryFilter postulantQueryFilter)
        {
            List<PostulantDto> lista = new List<PostulantDto>();
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
                "recruitment.sps_tb_person_get_postulant_list",
                queryParameters, commandType: CommandType.StoredProcedure);

            int totalItems = Convert.ToInt32(queryParameters.Get<int>("@nrecordcount"));

            lista = result.ToList();

            return lista;
        }


    }
}
