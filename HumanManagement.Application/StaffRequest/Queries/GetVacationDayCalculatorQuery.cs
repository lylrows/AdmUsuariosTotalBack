using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.MasterTable.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using HumanManagement.Domain.StaffRequest.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Queries
{
    public class GetVacationDayCalculatorQuery : IRequest<Result>
    {
        public VacationDayCalculatorFilter VacationDayCalculatorFilter { get; set; }
    }
    public class GetVacationDayCalculatorQueryHandler : IRequestHandler<GetVacationDayCalculatorQuery, Result>
    {
        private readonly IHoliDayRepository holiDayRepository;
        public GetVacationDayCalculatorQueryHandler(IHoliDayRepository holiDayRepository)
        {
            this.holiDayRepository = holiDayRepository;
        }
        public async Task<Result> Handle(GetVacationDayCalculatorQuery request, CancellationToken cancellationToken)
        {
            var holydayList = await holiDayRepository.GetListHoliDayActives();

            var vacationDaysCalculator = new VacationDaysCalculator(request.VacationDayCalculatorFilter.StartVacation,
                                                                    request.VacationDayCalculatorFilter.EndVacation,
                                                                    holydayList);
            vacationDaysCalculator.GenerateNumberCalendarDays();

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = new 
                {
                    vacationDaysCalculator.NumberCalendarDays,
                    NumberBusinessDays = vacationDaysCalculator.GetNumberBusinessDays()
                }
            };
        }
    }
}
