using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.StaffRequest.Dto;
using System.Collections.Generic;

namespace HumanManagement.Domain.StaffRequest.ReplaceText
{
    public class ReplaceTextAccountChangeCts
    {
        public StaffRequestAccountChangeDto staffRequestAccountChangeDto;
        public List<ReplaceEntity> ListReplaceEntity { get; private set; }
        public ReplaceTextAccountChangeCts(StaffRequestAccountChangeDto staffRequestAccountChangeDto)
        {
            this.staffRequestAccountChangeDto = staffRequestAccountChangeDto;
            ListReplaceEntity = new List<ReplaceEntity>();
        }
        public void Replace()
        {
            var employee = staffRequestAccountChangeDto.StaffRequest.StaffRequestEmployee;
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "EMPLOYEECODE",
                sreplacetext = employee.Code
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATEADMISSION",
                sreplacetext = employee.DateAdmission
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "EMPLOYEENAME",
                sreplacetext = $"{employee.Names} {employee.LastName} {employee.MotherLastName}"
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "EMPLOYEEDNI",
                sreplacetext = employee.Dni
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "EMPLOYEEDATEBIRTH",
                sreplacetext = employee.DateAdmission
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "EMPLOYEEADDRES",
                sreplacetext = employee.Address
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "EMPLOYEEPHONE",
                sreplacetext = employee.CellPhone
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "EMPLOYEEEMAIL",
                sreplacetext = employee.Email
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "CHARGE",
                sreplacetext = employee.Charge
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "AREA",
                sreplacetext = employee.Area
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "BANKINGENTITYCURRENT",
                sreplacetext = staffRequestAccountChangeDto.BankingEntityCurrent
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "BANKINGENTITYCHANGE",
                sreplacetext = staffRequestAccountChangeDto.BankingEntityChange
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "ACCOUNTNUMBER",
                sreplacetext = staffRequestAccountChangeDto.AccountNewNumberCts
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "CURRENCYCURRENT",
                sreplacetext = staffRequestAccountChangeDto.CurrencyAccountCurrent
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "CURRENCYCHANGE",
                sreplacetext = staffRequestAccountChangeDto.CurrencyAccountChange ?? string.Empty
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "ORIGENCURRENCYCTS",
                sreplacetext = staffRequestAccountChangeDto.OrigenCurrencyCts ?? string.Empty
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "BANK_ORI_CTS",
                sreplacetext = staffRequestAccountChangeDto.BankingOrigenCts ?? string.Empty
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DESTINCURRENCY_CTS",
                sreplacetext = staffRequestAccountChangeDto.DestinCurrencyCts ?? string.Empty
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "BANK_DESTIN_CTS",
                sreplacetext = staffRequestAccountChangeDto.BankingDestinCts ?? string.Empty
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "FECHASOLICITUD",
                sreplacetext = staffRequestAccountChangeDto.StaffRequest.DateIssue.ToShortDateString()
            });

            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DNITRABAJADOR",
                sreplacetext = employee.Code
            });

        }
    }
}
