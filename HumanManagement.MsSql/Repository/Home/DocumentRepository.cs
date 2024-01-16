using HumanManagement.Domain.Home.Contracts;
using HumanManagement.Domain.Home.Dto;
using HumanManagement.MsSql.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HumanManagement.Domain.Home.QueryFilter;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Common;
using Dapper;
using System.Data;

namespace HumanManagement.MsSql.Repository.Home
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly DbContextMsSql context;
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;

        public DocumentRepository(DbContextMsSql context, IHumanManagementReadDbConnection humanManagementReadDbConnection)
        {
            this.context = context;
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
        }
        public async Task<ResultPaginationListDto<DocumentDto>> GetListDocumentPagination(DocumentQueryFilter contactQueryFilter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_company", contactQueryFilter.IdCompany);
            queryParameters.Add("@nid_category", contactQueryFilter.IdCategory);
            queryParameters.Add("@nid_subcategory", contactQueryFilter.IdSubCategory);
            queryParameters.Add("@ncurrentpage", contactQueryFilter.Pagination.CurrentPage);
            queryParameters.Add("@nitemsperPage", contactQueryFilter.Pagination.ItemsPerPage);
            queryParameters.Add("@nrecordcount", DbType.Int32, direction: ParameterDirection.Output);

            var listContacts = await humanManagementReadDbConnection.QueryAsync<DocumentDto>(
                 "sps_home_document_pagination",
                 queryParameters, commandType: CommandType.StoredProcedure);


            ResultPaginationListDto<DocumentDto> result = new ResultPaginationListDto<DocumentDto>();
            result.list = listContacts.ToList();

            result.TotalItems = Convert.ToInt32(queryParameters.Get<int>("@nrecordcount"));
            result.TotalPages = (int)Math.Ceiling((double)result.TotalItems / contactQueryFilter.Pagination.ItemsPerPage);

            return result;
        }
        public async Task<IEnumerable<DocumentDto>> GetAll()
        {
            var dto = await (from p in context.Document
                             join a in context.MasterTable.Where(cat => cat.IdFather == 1) on p.IdCategory equals a.IdType
                             join c in context.tb_company on p.IdCompany equals c.Id
                             join sub in context.MasterTable on new { idsub = p.IdSubCategory, id = (int?)a.Id } equals new { idsub = sub.IdType, id = sub.IdFather } into SubCategoria
                             from pco in SubCategoria.DefaultIfEmpty()
                             where a.Active == true && a.IdFather == 1
                             select new DocumentDto
                             {
                                 Id = p.Id,
                                 IdCategory = p.IdCategory,
                                 IdCompany = c.Id,
                                 IdSubCategory = p.IdSubCategory,
                                 NameCompany = c.Descripcion,
                                 NameCategory = a.DescriptionValue,
                                 NameSubCategory = pco.DescriptionValue ?? String.Empty,
                                 Description = p.Description,
                                 Filename = p.Filename,
                                 Filenamefolder = p.Filenamefolder,
                                 Active = p.Active,
                                 DateRegister = p.DateRegister,
                                 UserRegister = p.UserRegister,
                                 DateUpdate = p.DateUpdate,
                                 UserUpdate = p.UserUpdate
                             }).ToListAsync();
            return dto;
        }
    }
}
