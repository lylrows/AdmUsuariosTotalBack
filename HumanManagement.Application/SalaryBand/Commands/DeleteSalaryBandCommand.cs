using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.SalaryBand.Contracts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.SalaryBand.Commands
{
    public class DeleteSalaryBandCommand : IRequest<Result>
    {

        public int IdBandBox { get; set; }

        public class DeleteSalaryBandCommandHandler : IRequestHandler<DeleteSalaryBandCommand, Result>
        {
            
            private readonly IBaseRepository<Domain.SalaryBand.Models.SalaryBand> baseRepository;
            private readonly IUnitOfWork unitOfWork;
            public DeleteSalaryBandCommandHandler(ISalaryBandRepository salarybandRepository,
                 IUnitOfWork unitOfWork,
                IBaseRepository<Domain.SalaryBand.Models.SalaryBand> baseRepository
                )
            {   
                this.unitOfWork = unitOfWork;
                this.baseRepository = baseRepository;
            }

            
            public async Task<Result> Handle(DeleteSalaryBandCommand request, CancellationToken cancellationToken)
            {
                
                var entity = await baseRepository.Find(request.IdBandBox);

                if (entity == null)
                {
                    return new Result
                    {
                        StateCode = Constants.StateCodeResult.ERROR_EXCEPTION,
                        MessageError = new List<string>() { "No existe la banda." }
                    };
                }


                entity.Active = false;
                await baseRepository.Update(entity);


                await unitOfWork.Commit();
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    MessageError = new List<string>() { "Se anuló la banda de manera correcta." }
                };
            }
        }
    }
}
