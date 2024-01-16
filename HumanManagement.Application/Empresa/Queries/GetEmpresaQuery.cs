using HumanManagement.Domain.Empresa.Contracts;
using HumanManagement.Domain.Empresa.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Empresa.Queries
{
    public class GetEmpresaQuery : IRequest<List<EmpresaDto>>
    {
        public class GetEmpresaQueryHandler : IRequestHandler<GetEmpresaQuery, List<EmpresaDto>>
        {
            private readonly IEmpresaRepository empresaRepository;
            public GetEmpresaQueryHandler(IEmpresaRepository empresaRepository)
            {
                this.empresaRepository = empresaRepository;
            }
            public async Task<List<EmpresaDto>> Handle(GetEmpresaQuery request, CancellationToken cancellationToken)
            {
                var result = await empresaRepository.GetAll();
                return result;
            }
        }
    }
}
