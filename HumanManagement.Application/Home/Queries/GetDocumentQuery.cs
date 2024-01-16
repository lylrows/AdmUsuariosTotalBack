using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.Domain.Home.Contracts;
using HumanManagement.Domain.Home.Dto;
using HumanManagement.Domain.Home.QueryFilter;
using HumanManagement.Domain.BaseRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace HumanManagement.Application.Home.Queries
{
    public class GetDocumentQuery : IRequest<Result>
    {
        public DocumentQueryFilter documentQueryFilter { get; set; }
        public class GetDocumentQueryHandler : IRequestHandler<GetDocumentQuery, Result>
        {
            private readonly IBaseRepository<Domain.Home.Models.Document> baseRepository;
            private readonly IDocumentRepository documentRepository;
            private IMapper mapper;

            public GetDocumentQueryHandler(IBaseRepository<Domain.Home.Models.Document> baseRepository,
                                       IMapper mapper,
                                       IDocumentRepository documentRepository)
            {
                this.baseRepository = baseRepository;
                this.mapper = mapper;
                this.documentRepository = documentRepository;
            }
            public async Task<Result> Handle(GetDocumentQuery request, CancellationToken cancellationToken)
            {
                var output = new Result();
                var result = await documentRepository.GetListDocumentPagination(request.documentQueryFilter);
                output.Data = result;
                return output;
            }
        }
    }
}
