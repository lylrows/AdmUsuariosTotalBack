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
    public class SaveInformationLangPostulantCommand: IRequest<Result>
    {
        public InformationLangDto dto { get; set; }

        public class SaveInformationLangPostulantCommandHandle : IRequestHandler<SaveInformationLangPostulantCommand, Result>
        {
            private readonly IBaseRepository<InformationLangModel> baseRepositoryLang;
            private readonly IMapper mapper;
            public SaveInformationLangPostulantCommandHandle(IBaseRepository<InformationLangModel> baseRepositoryLang, IMapper mapper)
            {
                this.baseRepositoryLang = baseRepositoryLang;
                this.mapper = mapper;
            }
            public async Task<Result> Handle(SaveInformationLangPostulantCommand request, CancellationToken cancellationToken)
            {
                var entity = mapper.Map<InformationLangModel>(request.dto);
                if (entity.Id == 0 && entity.IdLanguage != 0)
                {
                    await baseRepositoryLang.Add(entity);
                }
                else if (entity.IdLanguage != 0)
                {
                    await baseRepositoryLang.Update(entity);
                }
                else {
                    if (entity.Id != 0)
                    {
                        await baseRepositoryLang.Delete(entity);
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
