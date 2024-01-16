using HumanManagement.Domain.Empresa.Contracts;
using HumanManagement.Domain.Empresa.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Empresa.Queries
{
    public class GetEmpresaByUserQuery : IRequest<List<EmpresaDto>>
    {

        public int IdUser { get; set; }
        public class GetEmpresaByUserQueryHandler : IRequestHandler<GetEmpresaByUserQuery, List<EmpresaDto>>
        {
            private readonly IEmpresaRepository empresaRepository;
            public GetEmpresaByUserQueryHandler(IEmpresaRepository empresaRepository)
            {
                this.empresaRepository = empresaRepository;
            }
            public async Task<List<EmpresaDto>> Handle(GetEmpresaByUserQuery request, CancellationToken cancellationToken)
            {
                var result = await empresaRepository.GetEmpresaByUser(request.IdUser);
                return result;
            }
        }
    }
}
