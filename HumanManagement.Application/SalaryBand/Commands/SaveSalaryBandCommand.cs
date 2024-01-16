using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.SalaryBand.Contracts;
using HumanManagement.Domain.SalaryBand.Dto;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.SalaryBand.Commands
{
    public class SaveSalaryBandCommand : IRequest<Result>
    {

        public SaveSalaryBandDto newSalary { get; set; }
        public class SaveSalaryBandCommandHandler : IRequestHandler<SaveSalaryBandCommand, Result>
        {
            private readonly ISalaryBandRepository _salarybandRepository;
            private readonly IBaseRepository<Domain.SalaryBand.Models.SalaryBand> baseRepository;
            private readonly IUnitOfWork unitOfWork;
            public SaveSalaryBandCommandHandler(ISalaryBandRepository salarybandRepository,
                 IUnitOfWork unitOfWork,
                IBaseRepository<Domain.SalaryBand.Models.SalaryBand> baseRepository
                )
            {
                this._salarybandRepository = salarybandRepository;
                this.unitOfWork = unitOfWork;
                this.baseRepository = baseRepository;
            }

            
            public async Task<Result> Handle(SaveSalaryBandCommand request, CancellationToken cancellationToken)
            {
            
                var entity = await _salarybandRepository.FindSalaryBandById(request.newSalary.idBandBox);

                if (entity == null)
                {

                    var bandavigente = await _salarybandRepository.FindSalaryBandByGroupActive(request.newSalary.idgroup);
                    if (bandavigente != null)
                    {
                        bandavigente.Active = false;
                        await baseRepository.Update(bandavigente);
                    }


                    Domain.SalaryBand.Models.SalaryBand newSalaryBandBD = new Domain.SalaryBand.Models.SalaryBand();
                    
                    newSalaryBandBD.IdGroup= request.newSalary.idgroup;

                    newSalaryBandBD.NameGroup = request.newSalary.namegroup;
                    newSalaryBandBD.NameCategory = request.newSalary.namecategory;
                       

                    newSalaryBandBD.Points= request.newSalary.points;
                    newSalaryBandBD.MininumPoint = request.newSalary.minimunpoint;
                    newSalaryBandBD.MiddlePoint = request.newSalary.middlepoint;
                    newSalaryBandBD.MaximunPoint = request.newSalary.maximunpoint;
                    newSalaryBandBD.BandhWidth = request.newSalary.bandwidth;
                    newSalaryBandBD.Active = request.newSalary.active;

                    
                    await baseRepository.Add(newSalaryBandBD);
                }
                else
                {
                    entity.Points = request.newSalary.points;

                    entity.NameGroup = request.newSalary.namegroup;
                    entity.NameCategory = request.newSalary.namecategory;

                    entity.MininumPoint = request.newSalary.minimunpoint;
                    entity.MiddlePoint = request.newSalary.middlepoint;
                    entity.MaximunPoint = request.newSalary.maximunpoint;
                    entity.BandhWidth = request.newSalary.bandwidth;
                    entity.Active = request.newSalary.active;
                    await baseRepository.Update(entity);
                }

                await unitOfWork.Commit();
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    MessageError = new List<string>() { "Se guardó la banda de manera correcta." }
                };
            }
        }
    }
}
