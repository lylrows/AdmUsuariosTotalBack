using HumanManagement.Domain.BaseDto;
using HumanManagement.Domain.Common;
using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.Employee.Models;
using HumanManagement.Domain.Person.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Employee.Contracts
{
    public interface IEmployeeRepository
    {
        Task<ResultPaginationListDto<EmployeeDto>> GetListEmployee(string sidentification, string sfullname, int nid_company, int nid_position,int nid_state, int currentPage, int itemsPerPage, int totalItems, int totalPages, int totalRows);
        Task<List<ListCompanyComboDto>> GetListCompanyCombo();
        Task<List<ListPositionComboDto>> GetListPositionCombo(int nid_company);

        Task<EmployeeDetailtDto> GetDetailEmployee(int nid_person);
        Task<EmployeFileDto> GetEmployeeFile(int nid_employee);

        Task UpdateEmployee(UpdateEmployeeDto payload);
        Task<ResultPaginationListDto<EmployeeDto>> GetAllEmployee();

        Task PhoneMangement(PhoneManagementDto payload);

        Task AddressMangement(AddressManagementDto payload);

        Task<GetDataToSendDownloadDocumentDto> GetDataToSendDownloadDocument(int nid_request);
        Task<List<ListAddressDto>> GetListAddressDto(int nid_person);
        Task<List<StudientEmployeeDto>> GetListStudenEmplooyee(int nid_employee);
        Task InsertStudenEmployee(EmployeeInsRequestDto request);
        Task UpdateStudenEmployee(EmployeeEditRequestDto request);
        Task DeleteStudenEmployee(int nid_studen);
        Task<List<GetListInstruccionDto>> ListInstruccion();
        Task<List<ListSonDto>> ListSon(int id);
        Task InsertSon(InsertSonDto request);
        Task UpdateSon(UpdateSonDto request);
        Task InsertJob(InsertJobDto request);
        Task UpdateJob(UpdateJobDto request);
        Task DeleteJob(DeleteJobDto request);
        Task<List<ListJobDto>> ListJob(int id);

        Task UploadFIle(IFormFile file);

        Task<List<MasterTableGenericDto>> GenericListMasterTable(int id_father);

        Task UpdateCovidCard(UpdateCovidCardDto payload, IFormFile file);

        Task UpdateFirma(UpdateCovidCardDto payload, IFormFile file);
        Task<List<EmployeeModel>> EmployeeForSendToExactus();
        Task<List<MasterTableGenericDto>> GenericListMasterTableByKey(string key);
        Task<List<DropDownListDto<int>>> GetBossDropDown(int nidPosition);

        Task<EmployeeCVDto> GetEmployeeCVById(int nid_employee);
        Task<List<MonthDto>> GetMonthsByTipoDocumento(int id_tipo_documento,int nyear);
    }
}
