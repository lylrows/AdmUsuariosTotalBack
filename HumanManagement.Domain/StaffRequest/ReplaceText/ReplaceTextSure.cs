using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.StaffRequest.Dto;
using System.Collections.Generic;

namespace HumanManagement.Domain.StaffRequest.ReplaceText
{
    public class ReplaceTextSure
    {
        private GetStaffSureById getStaffSureById;
        public List<ReplaceEntity> ListReplaceEntity { get; private set; }
        public ReplaceTextSure(GetStaffSureById getStaffSureById)
        {
            this.getStaffSureById = getStaffSureById;
            ListReplaceEntity = new List<ReplaceEntity>();
        }
        public void Replace()
        {
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "EMPLOYEENAME",
                sreplacetext = getStaffSureById.sfullname
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "TYPEACCION",
                sreplacetext = getStaffSureById.Isaffiliate ? "AFILIACION" : "DESAFALIACION"
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "COMPANYNAME",
                sreplacetext = getStaffSureById.snamecompany
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "COMPANYRUC",
                sreplacetext = getStaffSureById.scompanyruc
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "EMPLOYEEDNI",
                sreplacetext = getStaffSureById.sidentification
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "TYPESURENAME",
                sreplacetext = getStaffSureById.snametypesure
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATEISSUE",
                sreplacetext = getStaffSureById.dregister.ToString("dd/MM/yyyy")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "tagtypebeneficiary",
                sreplacetext = getStaffSureById.stypebeneficiary
            });

            

        }
    }
}
