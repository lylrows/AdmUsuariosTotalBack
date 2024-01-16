using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.StaffRequest.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.StaffRequest.ReplaceText
{
    public class ReplaceTextSepelio
    {
        public GetStaffBurialByIdDto staffRequestBurialDto;
        public List<ReplaceEntity> ListReplaceEntity { get; private set; }
        public ReplaceTextSepelio(GetStaffBurialByIdDto staffRequestBurialDto)
        {
            this.staffRequestBurialDto = staffRequestBurialDto;
            ListReplaceEntity = new List<ReplaceEntity>();
        }
        public void Replace()
        {
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "EMPLOYEECODE",
                sreplacetext = staffRequestBurialDto.scodemployee
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATEADMISSION",
                sreplacetext = staffRequestBurialDto.dadmissiondate.ToString("dd/MM/yyyy")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "FULLNAME",
                sreplacetext = staffRequestBurialDto.sfullname
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "EMPLOYEEDNI",
                sreplacetext = staffRequestBurialDto.sidentification
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "CHARGE",
                sreplacetext = staffRequestBurialDto.snamecharge
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "AREA",
                sreplacetext = staffRequestBurialDto.snamearea
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "CELLPHONE",
                sreplacetext = staffRequestBurialDto.scellphone
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "TYPESERVICE",
                sreplacetext = staffRequestBurialDto.stypeservice
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DETAILREASON",
                sreplacetext = staffRequestBurialDto.sobservations
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "STATEEVALUATION",
                sreplacetext = staffRequestBurialDto.smeetrequirements
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATEEVALUATION",
                sreplacetext = staffRequestBurialDto.dregister.ToString("dd/MM/yyyy")
            });






            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "SEPULTURA",
                sreplacetext = staffRequestBurialDto.serviciosepultura? "Sí" : ""
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "SEPULTUR",
                sreplacetext = staffRequestBurialDto.serviciosepulturaporc == 0 ? "" : staffRequestBurialDto.serviciosepulturaporc.ToString() + "%"
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "FUNERARIO",
                sreplacetext = staffRequestBurialDto.serviciofunerario ? "Sí" : ""
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "FUNERARI",
                sreplacetext = staffRequestBurialDto.serviciofunerarioporc == 0 ? "" : staffRequestBurialDto.serviciofunerarioporc.ToString() + "%"
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "INHUMACION",
                sreplacetext = staffRequestBurialDto.ceremoniainhumacion ? "Sí" : ""
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "INHUMACIO",
                sreplacetext = staffRequestBurialDto.ceremoniainhumacionporc == 0 ? "" : staffRequestBurialDto.ceremoniainhumacionporc.ToString() + "%"
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "OTROS",
                sreplacetext = staffRequestBurialDto.otros ? "Sí" : ""
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "OTRO",
                sreplacetext = staffRequestBurialDto.otrosporc == 0 ? "" : staffRequestBurialDto.otrosporc.ToString() + "%"
            });
        }
    }
}
