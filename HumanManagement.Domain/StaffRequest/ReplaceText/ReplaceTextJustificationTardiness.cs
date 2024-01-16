using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.StaffRequest.Dto;
using System.Collections.Generic;

namespace HumanManagement.Domain.StaffRequest.ReplaceText
{
    public class ReplaceTextJustificationTardiness
    {
        private StaffRequestJustificationTardinessDto staffRequestJustificationTardinessDto;
        public List<ReplaceEntity> ListReplaceEntity { get; private set; }
        public ReplaceTextJustificationTardiness(StaffRequestJustificationTardinessDto staffRequestJustificationTardinessDto)
        {
            this.staffRequestJustificationTardinessDto = staffRequestJustificationTardinessDto;
            ListReplaceEntity = new List<ReplaceEntity>();
        }
        public void Replace()
        {
            var employee = staffRequestJustificationTardinessDto.StaffRequest.StaffRequestEmployee;
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
                stag = "DETAILREASON",
                sreplacetext = staffRequestJustificationTardinessDto.Support
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATETARDINESS",
                sreplacetext = staffRequestJustificationTardinessDto.tardinessDate .ToString("dd/MM/yyyy")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATEPERMIT",
                sreplacetext = staffRequestJustificationTardinessDto.tardinessDate.ToString("dd/MM/yyyy")
            });
            

            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "STARTIME",
                sreplacetext = staffRequestJustificationTardinessDto.StartTime.ToString("hh:mm tt")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "ENDTIME",
                sreplacetext = staffRequestJustificationTardinessDto.EndTime.ToString("hh:mm tt")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATEISSUE",
                sreplacetext = staffRequestJustificationTardinessDto.StaffRequest.DateIssue.ToString("dd/MM/yyyy")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATEEVALUATION",
                sreplacetext = staffRequestJustificationTardinessDto.StaffRequest.DateEvaluationString
            });

            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "FECHASOLICITUD",
                sreplacetext = staffRequestJustificationTardinessDto.StaffRequest.DateIssue.ToShortDateString()
            });
            
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DNITRABAJADOR",
                sreplacetext = employee.Code
            });



        }
    }
}
