using System;

namespace HumanManagement.Domain.StaffRequest.Dto
{
    public class StaffRequestJustificationTardinessDto
    {
        public int IdStaffRequest { get; set; }
        public string Support { get; set; }
        public DateTime DateAbsence { get; set; }
        public DateTime tardinessDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public StaffRequestDto StaffRequest { get; set; }
        public string PathFileDocument { get; set; }
        public void SetIdStaffRequest(int id)
        {
            IdStaffRequest = id;
        }
        public int GetIdPerson()
        {
            return StaffRequest.StaffRequestEmployee.IdPerson;
        }
    }
}
