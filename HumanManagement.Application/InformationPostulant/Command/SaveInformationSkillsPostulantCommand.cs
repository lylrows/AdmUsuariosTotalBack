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
    public class SaveInformationSkillsPostulantCommand: IRequest<Result>
    {
        public InformationComputerSkillsDto dto { get; set; }
        public class SaveInformationSkillsPostulantCommandHandle : IRequestHandler<SaveInformationSkillsPostulantCommand, Result>
        {
            private readonly IBaseRepository<InformationComputerSkillsModel> baseRepositorySkills;
            private readonly IMapper mapper;
            public SaveInformationSkillsPostulantCommandHandle(IBaseRepository<InformationComputerSkillsModel> baseRepositorySkills, IMapper mapper)
            {
                this.baseRepositorySkills = baseRepositorySkills;
                this.mapper = mapper;
            }
            public async Task<Result> Handle(SaveInformationSkillsPostulantCommand request, CancellationToken cancellationToken)
            {
                var entity = mapper.Map<InformationComputerSkillsModel>(request.dto);

                if (entity.Id == 0 && entity.Software != "")
                {
                    await baseRepositorySkills.Add(entity);
                }
                else if (entity.Software != "")
                {
                    await baseRepositorySkills.Update(entity);
                }
                else
                {
                    if (entity.Id !=0) {
                        await baseRepositorySkills.Delete(entity);
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
