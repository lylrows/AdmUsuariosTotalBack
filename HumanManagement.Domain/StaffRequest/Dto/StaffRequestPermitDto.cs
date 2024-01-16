using System;

namespace HumanManagement.Domain.StaffRequest.Dto
{
    public class StaffRequestPermitDto
    {
        public int IdStaffRequest { get; set; }
        public int IdPermitType { get; set; }
        public string PermitTypeName { get; set; }
        public string Support { get; set; }
        public DateTime PermitDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string PathFileDocument { get; set; }
        public int NumberOutstandingBalance { get; set; }
        public int NumberTruncatedBalance { get; set; }

        public StaffRequestDto StaffRequest { get; set; }
        public int GetIdPerson()
        {
            return StaffRequest.StaffRequestEmployee.IdPerson;
        }
    }
}
