using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.StaffRequest.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.StaffRequest.ReplaceText
{
    public class ReplaceTextAdvancement
    {
        private GetRequestAdvance staffRequestAdvacementDto;
        public List<ReplaceEntity> ListReplaceEntity { get; private set; }
        public ReplaceTextAdvancement(GetRequestAdvance staffRequestAdvacementDto)
        {
            this.staffRequestAdvacementDto = staffRequestAdvacementDto;
            ListReplaceEntity = new List<ReplaceEntity>();
        }
        public void Replace()
        {
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "EMPLOYEECODE",
                sreplacetext = staffRequestAdvacementDto.scodemployee
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATEADMISSION",
                sreplacetext = staffRequestAdvacementDto.dadmissiondate.ToString("dd/MM/yyyy")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "FULLNAME",
                sreplacetext = staffRequestAdvacementDto.sfullname
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "EMPLOYEEDNI",
                sreplacetext = staffRequestAdvacementDto.sidentification
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "CHARGE",
                sreplacetext = staffRequestAdvacementDto.snamecharge
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "AREA",
                sreplacetext = staffRequestAdvacementDto.snamearea
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "CELLPHONE",
                sreplacetext = staffRequestAdvacementDto.scellphone
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "AMOUNT",
                sreplacetext = staffRequestAdvacementDto.namount.ToString("N2")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "TYPEADVANCEMENT",
                sreplacetext = staffRequestAdvacementDto.sreason
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DETAILREASON",
                sreplacetext = staffRequestAdvacementDto.sdetailreason
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "STATEEVALUATION",
                sreplacetext = staffRequestAdvacementDto.stateevaluation
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATEEVALUATION",
                sreplacetext = staffRequestAdvacementDto.dregister.ToString("dd/MM/yyyy")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "FECHASOLICITUD",
                sreplacetext = staffRequestAdvacementDto.dregister.ToShortDateString()
            });
            
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DNITRABAJADOR",
                sreplacetext = staffRequestAdvacementDto.scodemployee
            });
        }
    }
}
