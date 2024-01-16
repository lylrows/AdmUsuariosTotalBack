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
    public class SaveInformationFamilyPostulantCommand: IRequest<Result>
    {
        public InformationFamilyDto dto { get; set; }
        public class SaveInformationFamilyPostulantCommandHandle : IRequestHandler<SaveInformationFamilyPostulantCommand, Result>
        {
            private readonly IBaseRepository<InformationFamilyModel> baseRepositoryFamily;
            private readonly IMapper mapper;
            public SaveInformationFamilyPostulantCommandHandle(IBaseRepository<InformationFamilyModel> baseRepositoryFamily, IMapper mapper)
            {
                this.baseRepositoryFamily = baseRepositoryFamily;
                this.mapper = mapper;
            }
            public async Task<Result> Handle(SaveInformationFamilyPostulantCommand request, CancellationToken cancellationToken)
            {
                var entity = mapper.Map<InformationFamilyModel>(request.dto);
                if (entity.Id == 0 && entity.FamilyType != "")
                {
                    entity.Active = true;
                    await baseRepositoryFamily.Add(entity);
                } else if(entity.FamilyType != "")
                {
                    await baseRepositoryFamily.UpdatePartial(entity, x => x.FullName,
                                                                     x => x.LastName,
                                                                     x => x.MotherLastName,
                                                                     x => x.FamilyType,
                                                                     x=> x.DocumentNumber,
                                                                     x => x.BirthDate,
                                                                     x => x.TypeDocument
                                                                     );
                }
                else
                {
                    if (entity.Id != 0)
                    {
                        await baseRepositoryFamily.Delete(entity);
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
