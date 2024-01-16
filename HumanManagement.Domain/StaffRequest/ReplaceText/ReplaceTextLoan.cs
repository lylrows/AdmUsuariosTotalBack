using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.StaffRequest.Dto;
using System.Collections.Generic;

namespace HumanManagement.Domain.StaffRequest.ReplaceText
{
    public class ReplaceTextLoan
    {
        private StaffRequestLoanDto staffRequestLoanDto;
        public List<ReplaceEntity> ListReplaceEntity { get; private set; }
        public ReplaceTextLoan(StaffRequestLoanDto staffRequestLoanDto)
        {
            this.staffRequestLoanDto = staffRequestLoanDto;
            ListReplaceEntity = new List<ReplaceEntity>();
        }

        public void Replace()
        {
            var employee = staffRequestLoanDto.StaffRequest.StaffRequestEmployee;
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "EMPLOYEECODE",
                sreplacetext = employee.Code
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
                sreplacetext = employee.Names +" "+ employee.LastName+ " "+ employee.MotherLastName
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "NAMECOMPLETE",
                sreplacetext = employee.FullNameComplete
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATEADMISSION",
                sreplacetext = employee.DateAdmission
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "EMPLOYEEDNI",
                sreplacetext = employee.Dni
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
                stag = "CELLPHONE",
                sreplacetext = employee.CellPhone
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "AMOUNT",
                sreplacetext = staffRequestLoanDto.Amount.ToString("N2")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "MONTHLYFEE",
                sreplacetext = staffRequestLoanDto.AmountMonthlyFee.ToString("N2")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "NUMBERFEE",
                sreplacetext = staffRequestLoanDto.NumberFee.ToString("N0")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "TYPELOAN",
                sreplacetext = staffRequestLoanDto.TypeLoanName
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DETAILREASON",
                sreplacetext = staffRequestLoanDto.DetailReasonLoan
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "STATEEVALUATION",
                sreplacetext = staffRequestLoanDto.StaffRequest.StateEvaluation
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATEEVALUATION",
                sreplacetext = staffRequestLoanDto.StaffRequest.DateEvaluationString
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "COLLECT_GRAFI",
                sreplacetext = staffRequestLoanDto.CobroGratificacion.ToString("N2")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "COLLECT_UTI",
                sreplacetext = staffRequestLoanDto.CobroUtilidad.ToString("N2")
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "USERAPPROVED",
                sreplacetext = staffRequestLoanDto.StaffRequestApproverDto==null?"":staffRequestLoanDto.StaffRequestApproverDto.FullNameComplete
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DATEAPPROVED",
                sreplacetext = staffRequestLoanDto.StaffRequestApproverDto == null ? "" : staffRequestLoanDto.StaffRequestApproverDto.ReviewDateString
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "COMMENT_APPROVED",
                sreplacetext = staffRequestLoanDto.Comment == null ? "" : staffRequestLoanDto.Comment
            });
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "FECHASOLICITUD",
                sreplacetext = staffRequestLoanDto.DateLoan.ToShortDateString()
            });
            
            ListReplaceEntity.Add(new ReplaceEntity
            {
                stag = "DNITRABAJADOR",
                sreplacetext = employee.Code
            });

        }
    }
}
