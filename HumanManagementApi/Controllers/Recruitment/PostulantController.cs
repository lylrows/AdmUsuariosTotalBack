using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

using System.Threading.Tasks;
using HumanManagement.Application.Postulant.Commands;
using HumanManagement.Application.Postulant.Queries;
using HumanManagement.Application.Utils.IService;
using HumanManagement.CrossCutting.Utils;

using HumanManagement.Domain.Postulant.Person.Dto;
using HumanManagement.Domain.Postulant.Person.QueryFilter;
using HumanManagement.Domain.Utils.Dto;
using Microsoft.AspNetCore.Mvc;
using PostulantInternalQueryFilter = HumanManagement.Domain.Person.QueryFilter.PostulantQueryFilter;

namespace HumanManagementApi.Controllers.Recruitment
{
    public class PostulantController : BaseApiController
    {
        private readonly IFileDownloadService fileDownloadService;
        public PostulantController(IFileDownloadService fileDownloadService)
        {
            this.fileDownloadService = fileDownloadService;
        }

        [HttpPost("getlist")]
        public async Task<IActionResult> GetListPagination(PostulantQueryFilter postulantQueryFilter)
        {
            var listPostulants = await mediator.Send(new GetListPostulantsPaginationQuery() { PostulantQueryFilter = postulantQueryFilter });

            return Ok(listPostulants);
        }

        [HttpPost("getlistexport")]
        public async Task<IActionResult> GetListPaginationExport(PostulantQueryFilter postulantQueryFilter)
        {
            string fullPath = string.Empty;
            string randmname = "Postulantes_" + DateTime.Now.ToString("ddMMyyyy") + DateTime.Now.ToString("hhmmss") + ".xlsx";
            fullPath = Path.Combine(Directory.GetCurrentDirectory(), "Files", randmname);

            var result = await mediator.Send(new GetListPostulantsExportQuery() { PostulantQueryFilter = postulantQueryFilter });

            var listPostulants = new List<PostulantDto>();
            listPostulants = (List<PostulantDto>)result.Data;

            DataTable dt = new DataTable("Postulantes");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Documento");
            dt.Columns.Add("Genero");
            dt.Columns.Add("Estado Civil");
            dt.Columns.Add("Nivel Estudio");
            dt.Columns.Add("Experiencia");
            dt.Columns.Add("Preferencia Salarial");
            
            dt.Columns.Add("Direccion");
            dt.Columns.Add("Correo");
            dt.Columns.Add("FechaPostulacion");
            dt.Columns.Add("NroContacto");
            dt.Columns.Add("Cargo");
            dt.Columns.Add("% Asertividad");
            
            dt.Columns.Add("Estado");

            foreach (var item in listPostulants)
            {
                DataRow row = dt.NewRow();
                row[0] = item.FullName;
                row[1] = item.DocumentNumber;
                row[2] = item.Gender;
                row[3] = item.CivilStatus;
                row[4] = item.LevelStudy;
                row[5] = item.WorkExperience;
                
                
                row[6] = item.SalaryPreference;
                row[7] = item.Address;
                row[8] = item.Email;
                row[9] = item.DateRegister;
                row[10] = item.CellPhone;
                row[11] = item.Position;
                
                
                row[12] = Math.Round(item.PorcentajeAsertividad, 2) + "%";
                row[13] = item.State;

                dt.Rows.Add(row);

            }

            Functions.DataTableToExcelWithStyle(dt, fullPath);
            Byte[] bytes5 = System.IO.File.ReadAllBytes(fullPath);
            String file5 = Convert.ToBase64String(bytes5);

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }


            return Ok(file5);


        }



        [HttpPost("getlistpostulantinternal")]
        public async Task<IActionResult> GetListPostulantInternalPagination(PostulantInternalQueryFilter postulantQueryFilter)
        {
            var listPostulants = await mediator.Send(new GetListPostulantsInternalPaginationQuery() { queryFilter = postulantQueryFilter });

            return Ok(listPostulants);
        }

        [HttpPost("getlistpostulantinternalexport")]
        public async Task<IActionResult> GetListPostulantInternalPaginationExport(PostulantInternalQueryFilter postulantQueryFilter)
        {
            string fullPath = string.Empty;
            string randmname = "Postulantes_" + DateTime.Now.ToString("ddMMyyyy") + DateTime.Now.ToString("hhmmss") + ".xlsx";
            fullPath = Path.Combine(Directory.GetCurrentDirectory(), "Files", randmname);

            var result = await mediator.Send(new GetListPostulantsInternalExportQuery() { queryFilter = postulantQueryFilter });

            var listPostulants = new List<HumanManagement.Domain.Person.Dto.PostulantInternalDto>();
            listPostulants = (List<HumanManagement.Domain.Person.Dto.PostulantInternalDto>)result.Data;

            DataTable dt = new DataTable("Postulantes");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Documento");
            dt.Columns.Add("Genero");
            dt.Columns.Add("EstadoCivil");
            dt.Columns.Add("NivelEstudio");
            dt.Columns.Add("Experiencia");
            dt.Columns.Add("SalarioMinimo");
            dt.Columns.Add("SalarioMaximo");
            dt.Columns.Add("Direccion");
            dt.Columns.Add("Correo");
            dt.Columns.Add("FechaPostulacion");
            dt.Columns.Add("NroContacto");
            dt.Columns.Add("Cargo");
            dt.Columns.Add("Estado");

            foreach (var item in listPostulants)
            {
                DataRow row = dt.NewRow();
                row[0] = item.FullName;
                row[1] = item.DocumentNumber;
                row[2] = item.Gender;
                row[3] = item.CivilStatus;
                row[4] = item.LevelStudy;
                row[5] = item.WorkExperience;
                row[6] = item.MinimunSalary;
                row[7] = item.MaximumSalary;
                row[8] = item.Address;
                row[9] = item.Email;
                row[10] = item.DateRegister;
                row[11] = item.CellPhone;
                row[12] = item.Position;
                row[13] = item.State;

                dt.Rows.Add(row);

            }

            Functions.DataTableToExcelWithStyle(dt, fullPath);
            Byte[] bytes5 = System.IO.File.ReadAllBytes(fullPath);
            String file5 = Convert.ToBase64String(bytes5);

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }


            return Ok(file5);

        }

        [HttpPost("getfile")]
        public async Task<IActionResult> GetFile(FileDto dto)
        {
            var file = await fileDownloadService.Download(dto);

            return Ok(file);
        }

        [HttpPost("getfileinternal")]
        public async Task<IActionResult> GetFileInternal(FileDto dto)
        {
            var file = await fileDownloadService.DownloadInternal(dto);

            return Ok(file);
        }

        [HttpGet("getcv/{idperson}/{idjob}/{idpostulant}")]
        public async Task<IActionResult> GetCv(int idPerson, int idjob, int idpostulant)
        {
            var file = await mediator.Send(new GenerateCvCommand() { IdPostulant = idPerson, IdJob = idjob, IdUser = idpostulant });

            return Ok(file);
        }

        [HttpGet("getcvword/{idperson}/{idjob}/{idpostulant}")]
        public async Task<IActionResult> GetCvWord(int idPerson, int idjob, int idpostulant)
        {
            var file = await mediator.Send(new GenerateCvWordCommand() { IdPostulant = idPerson, IdJob = idjob, IdUser = idpostulant });

            return Ok(file);
        }
    }
}