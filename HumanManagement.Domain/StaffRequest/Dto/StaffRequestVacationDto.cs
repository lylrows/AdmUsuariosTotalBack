using System;

namespace HumanManagement.Domain.StaffRequest.Dto
{
    public class StaffRequestVacationDto
    {
        public int IdStaffRequest { get; set; }
        public DateTime StartVacation { get; set; }
        public DateTime EndVacation { get; set; }
        public int NumberCalendarDays { get; set; }
        public int NumberBusinessDays { get; set; }
        public string VacationPeriod { get; set; }
        public int nid_person { get; set; }
        public string names { get; set; }
        public string lastName { get; set; }
        public string motherLastName { get; set; }
        public string charge { get; set; }
        public string dni { get; set; }
        public int NumberOutstandingBalance { get; set; }
        public int NumberTruncatedBalance { get; set; }


        public StaffRequestDto StaffRequest { get; set; }
        public StaffRequestVacationDto()
        {
            StaffRequest = new StaffRequestDto();
        }

        public int GetIdPerson()
        {
            return StaffRequest.StaffRequestEmployee.IdPerson;
        }
    }
}
