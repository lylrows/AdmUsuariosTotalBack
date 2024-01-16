using AutoMapper;
using HumanManagement.Domain.MasterTable.Contracts;
using HumanManagement.Domain.MasterTable.Dto;
using HumanManagement.Domain.BaseRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HumanManagement.Application.Response;

namespace HumanManagement.Application.MasterTable.Queries
{
    public class GetByIdMasterTableQuery : IRequest<IEnumerable<MasterTableDto>>
    {
        public int nid_father { get; set; }
        public int nid_type { get; set; }
        public class GetByIdMasterTableQueryHandler : IRequestHandler<GetByIdMasterTableQuery, IEnumerable<MasterTableDto>>
        {
            private readonly IMasterTableRepository _masterTableRepository;
            private readonly IBaseRepository<Domain.MasterTable.Models.MasterTable> baseRepository;

            public GetByIdMasterTableQueryHandler(IMasterTableRepository masterTableRepository, 
                IBaseRepository<Domain.MasterTable.Models.MasterTable> baseRepository)
            {
                this._masterTableRepository = masterTableRepository;
                this.baseRepository = baseRepository;
            }
            public async Task<IEnumerable<MasterTableDto>> Handle(GetByIdMasterTableQuery request, CancellationToken cancellationToken)
            {
                var result = await _masterTableRepository.GetByIdFather(request.nid_father, request.nid_type);
                return result;
            }
        }
    }
}

