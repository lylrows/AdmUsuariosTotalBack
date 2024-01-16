using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.InformationPostulant.Dto;
using HumanManagement.Domain.InformationPostulant.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.InformationPostulant.Command
{
  
    public class SaveInformationWorkPostulantCommand : IRequest<Result>
    {
        public InformationWorkDto dto { get; set; }
        public class SaveInformationWorkPostulantCommandHandle : IRequestHandler<SaveInformationWorkPostulantCommand, Result>
        {
            private readonly IBaseRepository<InformationWorkModel> baseRepositoryWork;
            private readonly IMapper mapper;
            public SaveInformationWorkPostulantCommandHandle(IBaseRepository<InformationWorkModel> baseRepositoryWork, IMapper mapper)
            {
                this.baseRepositoryWork = baseRepositoryWork;
                this.mapper = mapper;
            }
            public async Task<Result> Handle(SaveInformationWorkPostulantCommand request, CancellationToken cancellationToken)
            {
                var entity = mapper.Map<InformationWorkModel>(request.dto);
                if (entity.Id == 0 && entity.Company != "")
                {
                    entity.Active = true;
                    await baseRepositoryWork.Add(entity);
                }
                else if (entity.Company != "")
                {
                    if ( string.IsNullOrEmpty( request.dto.DateStart))
                    {
                        entity.DateStart = null;
                    }

                    if (string.IsNullOrEmpty(request.dto.DateFinish))
                    {
                        entity.DateFinish = null;
                    }


                    await baseRepositoryWork.UpdatePartial(entity, x => x.DateStart,x => x.DateFinish,
                                                                                    x => x.Company,
                                                                                    x => x.LastPosition,
                                                                                    x => x.MainFunction,
                                                                                    x => x.Salary,
                                                                                    x => x.Reference);


                }
                else
                {
                    if (entity.Id != 0)
                    {
                        await baseRepositoryWork.Delete(entity);
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
