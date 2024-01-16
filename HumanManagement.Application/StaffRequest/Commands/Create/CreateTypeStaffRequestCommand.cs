using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using HumanManagement.Domain.StaffRequest.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.StaffRequest.Commands.Create
{
    public class CreateTypeStaffRequestCommand : IRequest<Result>
    {
        public TypeStaffRequestDto TypeStaffRequest { get; set; }
    }

    public class CreateTypeStaffRequestCommandHandler : IRequestHandler<CreateTypeStaffRequestCommand, Result>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly ITypeStaffRequestRepository typeStaffRequestRepository;
        private readonly IBaseRepository<TypeStaffRequest> baseTypeStaffRequestRepository;
        private readonly IBaseRepository<TypeStaffRequestApprover> baseTypeStaffRequestApproverRepository;
        public CreateTypeStaffRequestCommandHandler(IMapper mapper,
                                                    IUnitOfWork unitOfWork,
                                                    ITypeStaffRequestRepository typeStaffRequestRepository,
                                                    IBaseRepository<TypeStaffRequest> baseTypeStaffRequestRepository,
                                                    IBaseRepository<TypeStaffRequestApprover> baseTypeStaffRequestApproverRepository
                                                    )
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.typeStaffRequestRepository = typeStaffRequestRepository;
            this.baseTypeStaffRequestRepository = baseTypeStaffRequestRepository;
            this.baseTypeStaffRequestApproverRepository = baseTypeStaffRequestApproverRepository;
        }
        public async Task<Result> Handle(CreateTypeStaffRequestCommand request, CancellationToken cancellationToken)
        {
            var typeStaffRequest = mapper.Map<TypeStaffRequest>(request.TypeStaffRequest);
            await baseTypeStaffRequestRepository.Add(typeStaffRequest);
            var typeStaffRequestApproverList = mapper.Map<List<TypeStaffRequestApprover>>(request.TypeStaffRequest.TypeStaffRequestApproverList);
            int idApprover = 0;
            typeStaffRequestApproverList.ForEach(x =>
            {
                x.IdTypeStaffRequest = typeStaffRequest.Id;
                x.IdApprover = ++idApprover;
            });
            await baseTypeStaffRequestApproverRepository.AddRange(typeStaffRequestApproverList);

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
