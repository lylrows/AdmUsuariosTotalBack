using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.StaffRequest.Dto;
using System.Collections.Generic;

namespace HumanManagement.Domain.StaffRequest.ReplaceText
{
    public class ReplaceTextBurial
    {
        public GetStaffBurialByIdDto staffRequestBurialDto;
        public List<ReplaceEntity> ListReplaceEntity { get; private set; }
        public ReplaceTextBurial(GetStaffBurialByIdDto staffRequestBurialDto)
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
                sreplacetext = staffRequestBurialDto.snametypeservice
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DETAILREASON",
                sreplacetext = staffRequestBurialDto.sobservations
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "STATEEVALUATION",
                sreplacetext = staffRequestBurialDto.stateevaluation
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATEEVALUATION",
                sreplacetext = staffRequestBurialDto.dateevaluation.ToString("dd/MM/yyyy")
            });
        }
    }
}
