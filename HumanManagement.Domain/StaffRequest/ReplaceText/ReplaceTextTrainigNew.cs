using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.StaffRequest.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.StaffRequest.ReplaceText
{
    public class ReplaceTextTrainigNew
    {
        private GetStaffCapacitationNuevByIdDto getRequestHourExtraById;
        public List<ReplaceEntity> ListReplaceEntity { get; private set; }
        public ReplaceTextTrainigNew(GetStaffCapacitationNuevByIdDto getStaffSureById)
        {
            this.getRequestHourExtraById = getStaffSureById;
            ListReplaceEntity = new List<ReplaceEntity>();
        }

        public void Replace()
        {
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "CHARGER",
                sreplacetext = getRequestHourExtraById.snamecharge
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "FULLNAME",
                sreplacetext = getRequestHourExtraById.sfullname
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "NAMEAREA",
                sreplacetext = getRequestHourExtraById.snamearea
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATEINGRESO",
                sreplacetext = getRequestHourExtraById.dadmissiondate.ToString("dd/MM/yyyy")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATEINIT",
                sreplacetext = getRequestHourExtraById.ddateinit.ToString("dd/MM/yyyy")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATEEND",
                sreplacetext = getRequestHourExtraById.ddateend.ToString("dd/MM/yyyy")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "NAMECAP",
                sreplacetext = getRequestHourExtraById.sname
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "PLACE",
                sreplacetext = getRequestHourExtraById.splace
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "OBJETIVODESC",
                sreplacetext = getRequestHourExtraById.starget
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "COSTODB",
                sreplacetext = getRequestHourExtraById.ncost.ToString()
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "INTDB",
                sreplacetext = getRequestHourExtraById.ntypemodality == 981 ? "X" : " "
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "EXTDB",
                sreplacetext = getRequestHourExtraById.ntypemodality == 982 ? "X" : " "
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "10DB",
                sreplacetext = getRequestHourExtraById.spercentage == "100" ? "X" : " "
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "50DB",
                sreplacetext = getRequestHourExtraById.spercentage == "50" ? "X" : " "
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "SIDB",
                sreplacetext = getRequestHourExtraById.sagreement == "SI" ? "X" : " "
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "NODB",
                sreplacetext = getRequestHourExtraById.spercentage == "NO" ? "X" : " "
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "MESESDB",
                sreplacetext = getRequestHourExtraById.nperiod.ToString()
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "ORGBD",
                sreplacetext = getRequestHourExtraById.ntype == 988 ? "X" : " "
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "ESPBD",
                sreplacetext = getRequestHourExtraById.ntype == 989 ? "X" : " "
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DNITRABAJADOR",
                sreplacetext = getRequestHourExtraById.scodemployee
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "FECHASOLICITUD",
                sreplacetext = getRequestHourExtraById.dregister.ToShortDateString()
            });
        }
    }
}
