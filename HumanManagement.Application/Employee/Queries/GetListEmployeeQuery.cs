using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Employee.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Employee.Queries
{
    public class GetListEmployeeQuery: IRequest<Result>
    {
        public string sidentification { get; set; }
        public string sfullname { get; set; }
        public int nid_company { get; set; }
        public int nid_position { get; set; }
        public int nid_state { get; set; }
        public int currentPage { get; set; }
        public int itemsPerPage { get; set; }
        public int totalItems { get; set; }
        public int totalPages { get; set; }
        public int totalRows { get; set; }
        public class GetListEmployeeQueryHandler : IRequestHandler<GetListEmployeeQuery, Result>
        {
            private readonly IEmployeeRepository _employeeRepository;
            public GetListEmployeeQueryHandler(IEmployeeRepository employeeRepository)
            {
                this._employeeRepository = employeeRepository;
            }

            public async Task<Result> Handle(GetListEmployeeQuery query, CancellationToken cancellationToken)
            {
                var output = new Result();
                var result = await _employeeRepository.GetListEmployee(query.sidentification, query.sfullname, query.nid_company, query.nid_position , query.nid_state, query.currentPage, query.itemsPerPage, query.totalItems, query.totalPages, query.totalRows);
                output.Data = result;
                return output;
            }
        }
    }
}
