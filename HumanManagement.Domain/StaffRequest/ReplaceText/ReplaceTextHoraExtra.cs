using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.StaffRequest.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.StaffRequest.ReplaceText
{
    public class ReplaceTextHoraExtra
    {
        private GetRequestHourExtraById getRequestHourExtraById;
        public List<ReplaceEntity> ListReplaceEntity { get; private set; }
        public ReplaceTextHoraExtra(GetRequestHourExtraById getStaffSureById)
        {
            this.getRequestHourExtraById = getStaffSureById;
            ListReplaceEntity = new List<ReplaceEntity>();
        }

        public void Replace()
        {
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "CODEMPLOYEE",
                sreplacetext = getRequestHourExtraById.scodemployee
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "FULLNAME",
                sreplacetext = getRequestHourExtraById.sfullname
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "GERENCE",
                sreplacetext = ""
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "AREAEMPLOYEE",
                sreplacetext = getRequestHourExtraById.snamearea
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "FECHAINGRESOEMPLOYEE",
                sreplacetext = getRequestHourExtraById.dadmissiondate.ToString("dd/MM/yyyy")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "SUSTENTOEMPLOYEE",
                sreplacetext = getRequestHourExtraById.support
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "FECHAEMPLOYEE",
                sreplacetext = getRequestHourExtraById.dday.ToString("dd/MM/yyyy")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "HORAINIT",
                sreplacetext = getRequestHourExtraById.shourinit
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "HORAFINISH",
                sreplacetext = getRequestHourExtraById.shourfinish
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "FECHASOLICITUD",
                sreplacetext = getRequestHourExtraById.dregister.ToString("dd/MM/yyyy")
            });
        }
    }
}
