using System;

namespace HumanManagement.Domain.StaffRequest.Dto
{
    public class VacationDayCalculatorFilter
    {
        public DateTime StartVacation { get; set; }
        public DateTime EndVacation { get; set; }
    }
}
