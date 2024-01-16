using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.StaffRequest.Dto;
using System.Collections.Generic;

namespace HumanManagement.Domain.StaffRequest.ReplaceText
{
    public class ReplaceTextVacation
    {
        private StaffRequestVacationDto staffRequestVacationDto;
        public List<ReplaceEntity> ListReplaceEntity { get; private set; }
        public ReplaceTextVacation(StaffRequestVacationDto staffRequestVacationDto)
        {
            this.staffRequestVacationDto = staffRequestVacationDto;
            ListReplaceEntity = new List<ReplaceEntity>();
        }

        public void Replace()
        {
            var employee = staffRequestVacationDto.StaffRequest.StaffRequestEmployee;
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "EMPLOYEECODE",
                sreplacetext = employee.Code
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "LASTNAME",
                sreplacetext = employee.LastName
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "MOTHER_LAST_NAME",
                sreplacetext = employee.MotherLastName
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "FULLNAME",
                sreplacetext = employee.Names
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATEADMISSION",
                sreplacetext = employee.DateAdmission
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "CHARGE",
                sreplacetext = employee.Charge
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "XAREA",
                sreplacetext = employee.Area
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "STARTVACATION",
                sreplacetext = staffRequestVacationDto.StartVacation.ToString("dd/MM/yyyy")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "ENDVACATION",
                sreplacetext = staffRequestVacationDto.EndVacation.ToString("dd/MM/yyyy")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "NDC",
                sreplacetext = staffRequestVacationDto.NumberCalendarDays.ToString("N0")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "NDB",
                sreplacetext = staffRequestVacationDto.NumberBusinessDays.ToString("N0")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "VACATIONPERIOD",
                sreplacetext = staffRequestVacationDto.VacationPeriod
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DNITRABAJADOR",
                sreplacetext = employee.Code
            });
            

        }
    }
}
