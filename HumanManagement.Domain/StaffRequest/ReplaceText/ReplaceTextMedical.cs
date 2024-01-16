using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.StaffRequest.Dto;
using System.Collections.Generic;

namespace HumanManagement.Domain.StaffRequest.ReplaceText
{
    public class ReplaceTextMedical
    {
        private GetRequestMedicalById staffRequestMedicalDto;
        public List<ReplaceEntity> ListReplaceEntity { get; private set; }
        public ReplaceTextMedical(GetRequestMedicalById staffRequestMedicalDto)
        {
            this.staffRequestMedicalDto = staffRequestMedicalDto;
            ListReplaceEntity = new List<ReplaceEntity>();
        }
        public void Replace()
        {
            
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "COMPANY",
                sreplacetext =string.Empty 
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "COMPANY",
                sreplacetext = string.Empty 
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DNI",
                sreplacetext = staffRequestMedicalDto.sidentification
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "EMPLOYEENAME",
                sreplacetext = staffRequestMedicalDto.sfullname
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "CHARGE",
                sreplacetext = staffRequestMedicalDto.snamecharge
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "AREA",
                sreplacetext = staffRequestMedicalDto.snamearea
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "GERENCIA",
                sreplacetext = string.Empty 
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATEADMISSION",
                sreplacetext = staffRequestMedicalDto.dadmissiondate.ToString("dd/MM/yyyy")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATEREGISTER",
                sreplacetext = staffRequestMedicalDto.ddateregister.ToString("dd/MM/yyyy")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATEISSUE",
                sreplacetext = staffRequestMedicalDto.dbroadcastdate.ToString("dd/MM/yyyy")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATESTART",
                sreplacetext = staffRequestMedicalDto.ddateinit.ToString("dd/MM/yyyy")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATEEND",
                sreplacetext = staffRequestMedicalDto.ddateend.ToString("dd/MM/yyyy")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "MEDICALDIAGNOSTIC",
                sreplacetext = staffRequestMedicalDto.sdiagnosis
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "RUCCLINIC",
                sreplacetext = staffRequestMedicalDto.sclinicruc
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DOCTORTUITION",
                sreplacetext = staffRequestMedicalDto.tuitiondoctor
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "ORIGINMEDICALREST",
                sreplacetext = staffRequestMedicalDto.originmedical
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "TYPEMEDICALREST",
                sreplacetext = staffRequestMedicalDto.typemedical
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DELIVERYCOMMITMENT",
                sreplacetext = staffRequestMedicalDto.sdeliverycommitment
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "EMAILSOCIALWELFARE",
                sreplacetext = staffRequestMedicalDto.semaisocialwelfare
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "MANAGMENT",
                sreplacetext = string.Empty 
            });
        }
    }
}
