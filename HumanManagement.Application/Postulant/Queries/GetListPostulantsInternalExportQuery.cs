using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Person.Contracts;
using HumanManagement.Domain.Person.QueryFilter;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace HumanManagement.Application.Postulant.Queries
{
    public class GetListPostulantsInternalExportQuery : IRequest<Result>
    {
        public PostulantQueryFilter queryFilter { get; set; }
        public class GetListPostulantsInternalExportQueryHandle : IRequestHandler<GetListPostulantsInternalExportQuery, Result>
        {
            private readonly IPersonRepository personRepository;

            public GetListPostulantsInternalExportQueryHandle(IPersonRepository personRepository)
            {
                this.personRepository = personRepository;
            }
            public async Task<Result> Handle(GetListPostulantsInternalExportQuery request, CancellationToken cancellationToken)
            {
                var dto = await personRepository.GetListPostulantExport(request.queryFilter);

                return new Result
                {
                    Data = dto,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
