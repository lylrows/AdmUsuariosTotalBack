using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.StaffRequest.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.StaffRequest.ReplaceText
{
    public class ReplaceTextTrainingExtrGeneratePdf
    {
        private GetStaffCapacitationExtraByIdDto getRequestHourExtraById;
        public List<ReplaceEntity> ListReplaceEntity { get; private set; }
        public ReplaceTextTrainingExtrGeneratePdf(GetStaffCapacitationExtraByIdDto getStaffSureById)
        {
            this.getRequestHourExtraById = getStaffSureById;
            ListReplaceEntity = new List<ReplaceEntity>();
        }

        public void Replace()
        {
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "SNAMECHARGER",
                sreplacetext = getRequestHourExtraById.snamecharge
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "FULLNAME",
                sreplacetext = getRequestHourExtraById.sfullname
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DNINUMBER",
                sreplacetext = getRequestHourExtraById.sidentification
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
                stag = "SNAME",
                sreplacetext = getRequestHourExtraById.sname
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "SORGANIZADORNAME",
                sreplacetext = getRequestHourExtraById.sorganizer
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "HORARIOBD",
                sreplacetext = getRequestHourExtraById.schedule
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "LUGARDB",
                sreplacetext = getRequestHourExtraById.splace
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "EVENTOCOSTOBD",
                sreplacetext = getRequestHourExtraById.ncostevent.ToString()
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "ALOJAMIENTODB",
                sreplacetext = getRequestHourExtraById.ncostaccommodation.ToString()
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "ALIMENTACIONDB",
                sreplacetext = getRequestHourExtraById.ncostfeeding.ToString()
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "PASAJEDB",
                sreplacetext = getRequestHourExtraById.ncostpassage.ToString()
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "OTROSBD",
                sreplacetext = getRequestHourExtraById.nothercost.ToString()
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "TOTALBD",
                sreplacetext = getRequestHourExtraById.ntotal.ToString()
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "OBJETIVOBD",
                sreplacetext = getRequestHourExtraById.starget.ToString()
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "BENEFIICIOBD",
                sreplacetext = getRequestHourExtraById.sbenefits.ToString()
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "PRESUPUESTOBD",
                sreplacetext = getRequestHourExtraById.nannualbudget.ToString()
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "PRESUPUESTOCONSUMIDOBD",
                sreplacetext = getRequestHourExtraById.nbudget.ToString()
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "SALDOBD",
                sreplacetext = getRequestHourExtraById.nsteppedout.ToString()
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "INVERSIONDB",
                sreplacetext = getRequestHourExtraById.ninvestment.ToString()
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "SALDONEWBD",
                sreplacetext = getRequestHourExtraById.nnewbalance.ToString()
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag= "AREANAME",
                sreplacetext = getRequestHourExtraById.snamearea.ToString()
            });

            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "FECHASOLICITUD",
                sreplacetext = getRequestHourExtraById.dregister.ToShortDateString()
            });

            
        }
    }
}
