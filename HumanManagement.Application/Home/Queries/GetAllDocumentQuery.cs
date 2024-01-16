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
    public class GetAllDocumentQuery : IRequest<IEnumerable<DocumentDto>>
    {
        
        public class GetAllDocumentQueryHandler : IRequestHandler<GetAllDocumentQuery, IEnumerable<DocumentDto>>
        {
            private readonly IDocumentRepository documentRepository;

            public GetAllDocumentQueryHandler(
                                       IDocumentRepository documentRepository)
            {
               this.documentRepository = documentRepository;
            }
            public async Task<IEnumerable<DocumentDto>> Handle(GetAllDocumentQuery request, CancellationToken cancellationToken)
            {
                var result = await documentRepository.GetAll();
                return result;
            }
        }
    }
}
