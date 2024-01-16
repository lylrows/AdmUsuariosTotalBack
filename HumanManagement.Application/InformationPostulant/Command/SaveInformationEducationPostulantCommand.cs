using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.InformationPostulant.Dto;
using HumanManagement.Domain.InformationPostulant.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.InformationPostulant.Command
{
    public class SaveInformationEducationPostulantCommand: IRequest<Result>
    {
        public InformationEducationDto dtos { get; set; }
        public class SaveInformationEducationPostulantCommandHandle : IRequestHandler<SaveInformationEducationPostulantCommand, Result>
        {
            private readonly IBaseRepository<InformationEducationModel> baseRepositoryEducation;
            private readonly IMapper mapper;
            public SaveInformationEducationPostulantCommandHandle(IMapper mapper, IBaseRepository<InformationEducationModel> baseRepositoryEducation)
            {
                this.mapper = mapper;
                this.baseRepositoryEducation = baseRepositoryEducation;
            }
            public async Task<Result> Handle(SaveInformationEducationPostulantCommand request, CancellationToken cancellationToken)
            {
                var entity = mapper.Map<InformationEducationModel>(request.dtos);
                entity.DateFinish = request.dtos.IsNoConcluido == true ? null : entity.DateFinish;
                var date = new DateTime();
                entity.DateStart = entity.DateStart == date ? null : entity.DateStart;
                entity.DateFinish = entity.DateFinish == date ? null : entity.DateFinish;
                if (entity.Id == 0 && entity.IdInstruction != 0)
                {
                    await baseRepositoryEducation.Add(entity);
                }
                else if (entity.IdInstruction != 0)
                {
                    await baseRepositoryEducation.Update(entity);
                }
                else
                {
                    if (entity.Id !=0)
                    {
                        await baseRepositoryEducation.Delete(entity);
                    }                    
                }
                    

                return new Result
                {
                    Data = entity,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
               
            }
        }
    }
}
