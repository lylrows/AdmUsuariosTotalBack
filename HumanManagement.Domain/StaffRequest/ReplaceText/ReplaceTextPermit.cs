﻿using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.StaffRequest.Dto;
using System.Collections.Generic;

namespace HumanManagement.Domain.StaffRequest.ReplaceText
{
    public class ReplaceTextPermit
    {
        private StaffRequestPermitDto staffRequestPermitDto;
        public List<ReplaceEntity> ListReplaceEntity { get; private set; }
        public ReplaceTextPermit(StaffRequestPermitDto staffRequestPermitDto)
        {
            this.staffRequestPermitDto = staffRequestPermitDto;
            ListReplaceEntity = new List<ReplaceEntity>();
        }

        public void Replace()
        {
            var employee = staffRequestPermitDto.StaffRequest.StaffRequestEmployee;
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
                stag = "DATEISSUE",
                sreplacetext = staffRequestPermitDto.StaffRequest.DateIssue.ToString("d/MM/yyyy")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "TYPEPERMIT",
                sreplacetext = staffRequestPermitDto.PermitTypeName
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DETAILREASON",
                sreplacetext = staffRequestPermitDto.Support
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATEPERMIT",
                sreplacetext = staffRequestPermitDto.PermitDate.ToString("d/MM/yyyy")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "STARTTIME",
                sreplacetext = staffRequestPermitDto.StartTime.ToString("hh:mm tt")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "ENDTIME",
                sreplacetext = staffRequestPermitDto.EndTime.ToString("hh:mm tt")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "FECHASOLICITUD",
                sreplacetext = staffRequestPermitDto.StaffRequest.DateIssue.ToShortDateString()
            });
            
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DNITRABAJADOR",
                sreplacetext = employee.Code
            });
        }
    }
}
