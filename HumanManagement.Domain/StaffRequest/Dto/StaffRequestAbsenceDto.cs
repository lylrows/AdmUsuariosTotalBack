using System;

namespace HumanManagement.Domain.StaffRequest.Dto
{
    public class StaffRequestAbsenceDto
    {
        public int IdStaffRequest { get; set; }
        public int IdTypeAbsence { get; set; }
        public string TypeAbsenceName { get; set; }
        public string Support { get; set; }
        public DateTime DateAbsence { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string PathFileDocument { get; set; }
        public StaffRequestDto StaffRequest { get; set; }
        public StaffRequestAbsenceDto()
        {
            StaffRequest = new StaffRequestDto();
        }
        public int GetIdPerson()
        {
            return StaffRequest.StaffRequestEmployee.IdPerson;
        }
    }
}
