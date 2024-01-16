using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.StaffRequest.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.StaffRequest.ReplaceText
{
    public class ReplaceTextCambioEPS
    {
        private GetRequestTypeSureById getRequestHourExtraById;
        public List<ReplaceEntity> ListReplaceEntity { get; private set; }
        public ReplaceTextCambioEPS(GetRequestTypeSureById getStaffSureById)
        {
            this.getRequestHourExtraById = getStaffSureById;
            ListReplaceEntity = new List<ReplaceEntity>();
        }

        public void Replace()
        {
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "FULLNAME",
                sreplacetext = getRequestHourExtraById.sfullname
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "NUMBERDNI",
                sreplacetext = getRequestHourExtraById.sidentification
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "NAMECOMPANY",
                sreplacetext = getRequestHourExtraById.scompany
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "NAMEEPS",
                sreplacetext = getRequestHourExtraById.sdescriptionplan
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "FECHASOLICITUD",
                sreplacetext = getRequestHourExtraById.dregister.ToString("dd/MM/yyyy")
            });
            


        }
    }
}
