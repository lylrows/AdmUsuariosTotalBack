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

namespace HumanManagement.Application.StaffRequest.Commands.Update
{
    public class UpdateTypeStaffRequestCommand: IRequest<Result>
    {
        public TypeStaffRequestDto TypeStaffRequest { get; set; }
    }
    public class UpdateTypeStaffRequestCommandHandler : IRequestHandler<UpdateTypeStaffRequestCommand, Result>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly ITypeStaffRequestRepository typeStaffRequestRepository;
        private readonly IBaseRepository<TypeStaffRequest> baseTypeStaffRequestRepository;
        private readonly IBaseRepository<TypeStaffRequestApprover> baseTypeStaffRequestApproverRepository;
        private readonly ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository;
        public UpdateTypeStaffRequestCommandHandler(IMapper mapper,
                                                    IUnitOfWork unitOfWork,
                                                    ITypeStaffRequestRepository typeStaffRequestRepository,
                                                    IBaseRepository<TypeStaffRequest> baseTypeStaffRequestRepository,
                                                    IBaseRepository<TypeStaffRequestApprover> baseTypeStaffRequestApproverRepository,
                                                    ITypeStaffRequestApproverRepository typeStaffRequestApproverRepository)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.typeStaffRequestRepository = typeStaffRequestRepository;
            this.baseTypeStaffRequestRepository = baseTypeStaffRequestRepository;
            this.baseTypeStaffRequestApproverRepository = baseTypeStaffRequestApproverRepository;
            this.typeStaffRequestApproverRepository = typeStaffRequestApproverRepository;
        }
        public async Task<Result> Handle(UpdateTypeStaffRequestCommand request, CancellationToken cancellationToken)
        {
            var typeStaffRequest = mapper.Map<TypeStaffRequest>(request.TypeStaffRequest);
            await baseTypeStaffRequestRepository.UpdatePartialNotIncluding(typeStaffRequest, x => x.DateRegister,
                                                                                             x => x.IdUserRegister);
            var typeStaffRequestApproverList = mapper.Map<List<TypeStaffRequestApprover>>(request.TypeStaffRequest.TypeStaffRequestApproverList);
            int idApprover = 0;
            typeStaffRequestApproverList.ForEach(x =>
            {
                x.IdTypeStaffRequest = typeStaffRequest.Id;
                x.IdApprover = ++idApprover;
            });
            await typeStaffRequestApproverRepository.DeleteById(typeStaffRequest.Id);
            await baseTypeStaffRequestApproverRepository.AddRange(typeStaffRequestApproverList);

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
