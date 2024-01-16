using HumanManagement.Domain.MasterTable.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HumanManagement.Domain.StaffRequest.Models
{
    public class VacationDaysCalculator
    {
        private DateTime dateStart;
        private DateTime dateEnd;
        private List<HoliDayDto> holiDayList;
        public int NumberCalendarDays { get; private set; }
        public VacationDaysCalculator(DateTime dateStart, 
                                      DateTime dateEnd,
                                      List<HoliDayDto> holiDayList)
        {
            this.dateStart = dateStart;
            this.dateEnd = dateEnd;
            this.holiDayList = holiDayList;
        }

        public void GenerateNumberCalendarDays()
        {
            NumberCalendarDays = Convert.ToInt32(dateEnd.Subtract(dateStart).TotalDays) + 1;
        }
        public int GetNumberBusinessDays()
        {
            int businessDays = Enumerable.Range(1, NumberCalendarDays)
                         .Select(i => dateStart.AddDays(i - 1))
                         .Count(i => i.DayOfWeek != DayOfWeek.Saturday 
                                    && i.DayOfWeek != DayOfWeek.Sunday);

            int numberHoliday = Enumerable.Range(1, NumberCalendarDays)
                         .Select(i => dateStart.AddDays(i - 1))
                         .Count(i => holiDayList.Any(x => x.Day == i.Day
                                                     && x.Month == i.Month));

            return businessDays - numberHoliday;
        }
    }
}
