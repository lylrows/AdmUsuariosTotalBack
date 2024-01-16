using HumanManagement.Application.Response;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using HumanManagement.Domain.NineBox.Dto;
using HumanManagement.Domain.NineBox.Contracts;
using HumanManagement.CrossCutting.Utils;

namespace HumanManagement.Application.NineBox.Commands.Edit
{
    public class EditNineBoxCommand : IRequest<Result>
    {
        public NineBoxDto nineBoxDto { get; set; }
    }

    public class EditNineBoxCommandHandler : IRequestHandler<EditNineBoxCommand, Result>
    {
        
        private readonly INineBoxRepository _nineBoxRepository;
        public EditNineBoxCommandHandler(INineBoxRepository nineBoxRepository)
        {
            
            this._nineBoxRepository = nineBoxRepository;
        }
        public async Task<Result> Handle(EditNineBoxCommand request, CancellationToken cancellationToken)
        {
          

            var result = await _nineBoxRepository.EditConfigNineBox(request.nineBoxDto);
            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = result
            };

        }
    }
}
