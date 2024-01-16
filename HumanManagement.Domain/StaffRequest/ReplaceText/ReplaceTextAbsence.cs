using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.StaffRequest.Dto;
using System.Collections.Generic;


namespace HumanManagement.Domain.StaffRequest.ReplaceText
{
    public class ReplaceTextAbsence
    {
        private StaffRequestAbsenceDto staffRequestAbsenceDto;
        public List<ReplaceEntity> ListReplaceEntity { get; private set; }
        public ReplaceTextAbsence(StaffRequestAbsenceDto staffRequestAbsenceDto)
        {
            this.staffRequestAbsenceDto = staffRequestAbsenceDto;
            ListReplaceEntity = new List<ReplaceEntity>();
        }
        public void Replace()
        {
            var employee = staffRequestAbsenceDto.StaffRequest.StaffRequestEmployee;
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "EMPLOYEECODE",
                sreplacetext = employee.Code
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "EMPLOYEEDNI",
                sreplacetext = employee.Dni
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "LASTNAME",
                sreplacetext = employee.LastName
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "MOTHERLASTNAME",
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
                stag = "AREA",
                sreplacetext = employee.Area
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "CELLPHONE",
                sreplacetext = employee.CellPhone
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "TYPEPERMIT",
                sreplacetext = staffRequestAbsenceDto.TypeAbsenceName
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DETAILREASON",
                sreplacetext = staffRequestAbsenceDto.Support
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATEPERMIT",
                sreplacetext = staffRequestAbsenceDto.DateAbsence.ToString("dd/MM/yyyy")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "STARTIME",
                sreplacetext = staffRequestAbsenceDto.StartTime.ToString("hh:mm tt")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "ENDTIME",
                sreplacetext = staffRequestAbsenceDto.EndTime.ToString("hh:mm tt")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATEISSUE",
                sreplacetext = staffRequestAbsenceDto.StaffRequest.DateIssue.ToString("dd/MM/yyyy")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATEEVALUATION",
                sreplacetext = staffRequestAbsenceDto.StaffRequest.DateEvaluationString
            });
        }
    }
}
